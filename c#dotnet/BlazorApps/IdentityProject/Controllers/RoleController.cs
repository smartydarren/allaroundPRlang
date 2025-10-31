using IdentityProject.Data;
using IdentityProject.Data.Procs;
using IdentityProject.Models.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IdentityProject.Controllers
{    
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly RoleManager<Access_ApplicationRole> roleManager;
        public RoleController(ApplicationDbContext dbcon, RoleManager<Access_ApplicationRole> _Role)
        {
            this.dbContext = dbcon;
            this.roleManager = _Role;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var roleDBTable = roleManager.Roles.ToList();

            var dateTime = DateTime.Now;
            var shortDateValue = dateTime.ToString("MM");

            //left outer join
            var roleView = (from roleTbl in roleDBTable
                            join usrs in dbContext.db_UsersIdentity on roleTbl.CreatedBy equals usrs.Id into roleview
                            from subpet in roleview.DefaultIfEmpty()

                            select new RoleIndexPageViewModel()
                            {
                                RoleId = roleTbl.Id,
                                RoleName = roleTbl.Name,
                                Description = roleTbl.Description,
                                LastUpdatedBy = subpet.Name,
                                LastUpdateDate = roleTbl.UpdatedDate.HasValue ? roleTbl.UpdatedDate.Value.ToString("dd/MMM/yyyy") : "NA"
                            });


            return View(roleView);
        }

        //Creating/Editing Roles

        [HttpGet]
        public async Task<IActionResult> Create(int _roleId = 0,bool _success=false)
        {
            var roleExists = await roleManager.Roles.FirstOrDefaultAsync(r => r.Id == _roleId);            

            if (_roleId != 0)
            {
                var roleReturn = new Access_RoleCreateViewModel
                {
                    RoleId = roleExists.Id,
                    Description = roleExists.Description,
                    RoleName = roleExists.Name
                };
                ViewBag.Success = _success;
                return View(roleReturn);
            }

            ViewBag.Success = _success;
            return View(new Access_RoleCreateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(Access_RoleCreateViewModel model,int _roleId=0)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unable to Add Role");
                return View(model);
            }
            else
            {
                var userID = new Access_GetUserID().GetUserID(HttpContext);

                if (_roleId == 0) //Adding new record
                {
                    Access_ApplicationRole newRole = new Access_ApplicationRole
                    {
                        Name = model.RoleName,
                        CreatedDate = DateTime.Now,
                        CreatedBy = userID,//FoundUser.Id,
                        Description = model.Description,
                        IsActive = true
                    };

                    if (await roleManager.RoleExistsAsync(newRole.Name))
                    {
                        ModelState.AddModelError("", "Role Already Exists");
                        return View(model);
                    }

                    var entity = await dbContext.Roles.AddAsync(newRole);
                    var result = await dbContext.SaveChangesAsync();

                    model.RoleId = entity.Entity.Id;
                    model.RoleName = entity.Entity.Name;
                    model.Description = entity.Entity.Description;

                    ViewBag.Success = true;
                    return RedirectToAction("Create", new { _roleId = model.RoleId, _success = true });

                }
                else //updating existing Record
                {
                    var res = await roleManager.FindByIdAsync(_roleId.ToString());
                    res.Description = model.Description;
                    res.UpdatedDate = DateTime.Now;
                    res.UpdatedBy = userID;
                    res.IsActive = true;

                    /*var updateRole = new Access_ApplicationRole
                    {
                        Id = (int)model.RoleId,
                        Name = model.RoleName,
                        Description = model.Description,
                        UpdatedDate = DateTime.Now,
                        UpdatedBy = userID,
                        IsActive = true
                    };*/                    
                  
                    var result = await roleManager.UpdateAsync(res);
                    if (result.Succeeded)
                    {                        
                        return RedirectToAction("Create", new { _roleId = _roleId, _success = true });
                    }

                    foreach (var errs in result.Errors)
                    {
                        ModelState.AddModelError("", errs.Description);
                    }
                    //ViewBag.Success = true;
                   // return View(model);
                }
                return View(model);
            }

        }

        [HttpGet]
        public async Task<IActionResult> ConfigureRole(int id = 0,bool _success = false)
        {
            var roleDetails = await dbContext.db_RolesIdentity.Where(r => r.Id == id).FirstOrDefaultAsync();
            ViewBag.RoleId = roleDetails.Id; ViewBag.Name = roleDetails.Name; ViewBag.Desc = roleDetails.Description;
            ViewBag.Success = _success;

            if (id == 0)
            {
                ViewBag.Success = false;
                return View();
            }            

            List<RoleConfigurationViewModel> modelList = new List<RoleConfigurationViewModel>();

            foreach (var items in await dbContext.db_Menu.Where(x => x.Controller != null).ToListAsync())
            {
                var model = new RoleConfigurationViewModel
                {
                    MenuName = items.MenuName,
                    MenuID = items.Id,
                    AllowCreate = false,
                    AllowView = false,
                    AllowUpdate = false,
                    AllowDelete = false
                };
                modelList.Add(model);
            };

            //Existing Rights filling checkboxes
            var existingRights = await dbContext.db_RoleMenuMap.Where(x => x.RoleId == id).ToListAsync();
            if (existingRights != null)
            {
                foreach (var item in modelList)
                {
                    var result = existingRights.Find(x => x.MenuId == item.MenuID);
                    if (result != null)
                    {
                        item.AllowView = result.AllowView; item.AllowCreate = result.AllowCreate;
                        item.AllowUpdate = result.AllowUpdate; item.AllowDelete = result.AllowDelete;
                    }
                }
            }

            return View(modelList);
        }

        [HttpPost]
        public async Task<IActionResult> ConfigureRole(List<RoleConfigurationViewModel> model, int roleId = 0)
        {
            var userID = new Access_GetUserID().GetUserID(HttpContext);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Unable to Configure Role");
                return View("ConfigureRole", model);
            }
            else
            {
                try
                {
                    List<Access_RoleMenuMap> menuMapAdd = new List<Access_RoleMenuMap>();
                    var updatedDate = DateTime.Now;
                    var batchId = await dbContext.db_RoleMenuMap.Where(c => c.RoleId == roleId)
                        .Select(a => a.BatchNo).DefaultIfEmpty().MaxAsync();
                    if (batchId > 0)
                    {
                        batchId = batchId + 1;
                    }
                    else
                    {
                        var batchIdAudit = await dbContext.db_RoleMenuMap_Audit.Where(c => c.RoleId == roleId)
                        .Select(a => a.BatchNo).DefaultIfEmpty().MaxAsync();
                        if (batchIdAudit > 0)
                        {
                            batchId = batchIdAudit + 1;
                        }
                        else
                        {
                            batchId = 1;
                        }
                    }

                    foreach (var item in model.Where(x => x.AllowView == true || x.AllowCreate == true
                        || x.AllowUpdate == true || x.AllowDelete == true))
                    {
                        var _model = new Access_RoleMenuMap()
                        {
                            RoleId = roleId,
                            MenuId = item.MenuID,
                            AllowView = item.AllowView,
                            AllowCreate = item.AllowCreate,
                            AllowUpdate = item.AllowUpdate,
                            AllowDelete = item.AllowDelete,
                            ModifiedBy = userID,
                            ModifiedDate = updatedDate,
                            BatchNo = batchId
                        };

                        menuMapAdd.Add(_model);

                    }
                    var DS = await dbContext.db_RoleMenuMap.Where(x => x.RoleId == roleId).ToListAsync();
                    if (DS != null)
                    {
                        var AuditDS = new List<Access_RoleMenuMap_Audit>();
                        foreach (var item in DS)
                        {
                            var _model1 = new Access_RoleMenuMap_Audit
                            {
                                RoleId = item.RoleId,
                                MenuId = item.MenuId,
                                ModifiedDate = item.ModifiedDate,
                                ModifiedBy = item.ModifiedBy,
                                BatchNo = item.BatchNo,
                                AllowView = item.AllowView,
                                AllowCreate = item.AllowCreate,
                                AllowUpdate = item.AllowUpdate,
                                AllowDelete = item.AllowDelete
                            };

                            AuditDS.Add(_model1);
                        }
                        await dbContext.db_RoleMenuMap_Audit.AddRangeAsync(AuditDS);
                        //var resultAudit = await dbContext.SaveChangesAsync();

                        dbContext.db_RoleMenuMap.RemoveRange(DS);
                        //var outcome = await dbContext.SaveChangesAsync();
                    }

                    menuMapAdd.Distinct();
                    await dbContext.db_RoleMenuMap.AddRangeAsync(menuMapAdd);
                    var result = await dbContext.SaveChangesAsync();

                    if (result > 0)
                    {
                        ViewBag.Success = true;
                        return RedirectToAction("ConfigureRole", new { id = roleId, _success = true });
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return RedirectToAction("ConfigureRole", new { id = roleId });
            }
            //return RedirectToAction("Index");
        }
    }
}
