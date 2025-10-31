using IdentityProject.Data;
using IdentityProject.Data.Procs;
using IdentityProject.Models.ViewModels.Access;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityProject.Controllers
{   
    public class AccessMngmtController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<Access_ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public AccessMngmtController(ApplicationDbContext dbcon, RoleManager<Access_ApplicationRole> _Role
            , UserManager<ApplicationUser> _userManager)
        {
            this.dbContext = dbcon;
            this.roleManager = _Role;
            this.userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? returnUrl = null)
        {
            var listOfDbUsers = await dbContext.db_UsersIdentity.ToListAsync();
            List<Access_UserListViewModel> modelUsersList = new List<Access_UserListViewModel>();

            foreach (var user in listOfDbUsers)
            {
                var addUser = new Access_UserListViewModel
                {
                    Id = user.Id,
                    Name = user.Name
                };
                modelUsersList.Add(addUser);
            }

            return View(modelUsersList);
        }

        [HttpGet]
        public async Task<IActionResult> CreateUserRoleMap(int userId = 0, bool IsSuccess = false, string? IsError = null)
        {
            //var LoginuserIDGet = new Access_GetUserID().GetUserID(HttpContext);
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                ViewBag.UserNotFound = true;
                return View();
            }

            ViewBag.UserName = user.Name;
            List<UserRoleMapCreateViewModel> modelList = new List<UserRoleMapCreateViewModel>();

            foreach (var record in await dbContext.db_RolesIdentity.ToListAsync())
            {
                var model = new UserRoleMapCreateViewModel
                {
                    UserId = userId,
                    RoleID = record.Id,
                    RoleName = record.Name,
                    isChecked = false
                };
                modelList.Add(model);
            };
            //Existing Rights filling checkboxes
            var existingRights = await dbContext.db_UserRolesIdentity.Where(x => x.UserId == userId).ToListAsync();
            if (existingRights != null)
            {
                foreach (var item in modelList)
                {
                    var result = existingRights.Find(x => x.RoleId == item.RoleID);
                    if (result != null)
                    {
                        item.isChecked = true;
                    }
                }
            }
            ViewBag.userID = userId;
            ViewBag.IsError = IsError;
            ViewBag.Success = IsSuccess;
            return View(modelList);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserRoleMap(List<UserRoleMapCreateViewModel> pageModel, int userId = 0, bool IsSuccess = false)
        {
            var LoginUser = new Access_GetUserID().GetUserID(HttpContext);
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                ViewBag.UserNotFound = true;
                return View();
            }

            if (!ModelState.IsValid)
            {               
                return RedirectToAction("CreateUserRoleMap", new { userId = userId, IsError= "Error while Mapping User Roles" });
            }
            else
            {
                var modifiedDate = DateTime.Now;
                var batchId = await dbContext.db_UserRolesIdentity.Where(u => u.UserId == userId)
                        .Select(b => b.BatchNo).DefaultIfEmpty().MaxAsync();
                if (batchId > 0)
                {
                    batchId = batchId + 1;
                }
                else
                {
                    var batchIdAudit = await dbContext.db_UserRoleMap_Audit.Where(u => u.UserId == userId)
                    .Select(b => b.BatchNo).DefaultIfEmpty().MaxAsync();
                    if (batchIdAudit > 0)
                    {
                        batchId = batchIdAudit + 1;
                    }
                    else
                    {
                        batchId = 1;
                    }
                }
                var existingRoles = await dbContext.db_UserRolesIdentity.Where(u => u.UserId == userId).ToListAsync();
                var newRolesForUser = new List<Access_ApplicationUserRoles>();
                foreach (var record in pageModel.Where(ic => ic.isChecked == true))
                {
                    var dbModel = new Access_ApplicationUserRoles()
                    {
                        UserId = record.UserId,
                        RoleId = record.RoleID,
                        ModifiedDate = modifiedDate,
                        ModifiedBy = LoginUser,
                        BatchNo = batchId
                    };
                    newRolesForUser.Add(dbModel);
                }
                //Mapping Roles if Main Table is empty!
                if (existingRoles == null)
                {
                    await dbContext.db_UserRolesIdentity.AddRangeAsync(newRolesForUser);
                    var result = await dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        return RedirectToAction("CreateUserRoleMap", new { userId = userId, IsSuccess = true });
                    }
                    else
                    {
                        return View(pageModel);
                    }
                }else
                {
                    //Mapping Roles and auditing Main Table if not empty!
                    var auditingExistingRoles = new List<Access_UserRolesMap_Audit>();
                    foreach (var eRoles in existingRoles)
                    {
                        var addItem = new Access_UserRolesMap_Audit()
                        {
                            UserId = eRoles.UserId,
                            RoleId = eRoles.RoleId,
                            BatchNo = eRoles.BatchNo,
                            ModifiedBy = eRoles.ModifiedBy,
                            ModifiedDate = eRoles.ModifiedDate,
                        };
                        auditingExistingRoles.Add(addItem);
                    }
                    await dbContext.db_UserRoleMap_Audit.AddRangeAsync(auditingExistingRoles);
                    dbContext.db_UserRolesIdentity.RemoveRange(existingRoles);
                    await dbContext.db_UserRolesIdentity.AddRangeAsync(newRolesForUser);
                    var result = await dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        return RedirectToAction("CreateUserRoleMap", new { userId = userId, IsSuccess = true });
                    }
                    else
                    {
                        return View(pageModel);
                    }
                }

            }

        }

        public async Task<IActionResult> ResetPassword(int userId = 0)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                ViewBag.UserNotFound = true;
                return View();
            }
            else
            {
                var newPass = "Relo@2022";
                await userManager.RemovePasswordAsync(user);
                var result = await userManager.AddPasswordAsync(user, newPass);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                return View();
            }
            
        }
    }
}
