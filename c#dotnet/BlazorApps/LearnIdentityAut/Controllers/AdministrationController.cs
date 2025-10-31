using LearnIdentityAut.Models;
using LearnIdentityAut.Models.RoleModels;
using LearnIdentityAut.Models.UserAccess;
using LearnIdentityAut.Models.UserModels;
using LearnIdentityAut.Repository;
using LearnIdentityAut.ViewModels.UserAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LearnIdentityAut.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly IRoleRepository roleRepository;
        private IAccountRepository AccountRepository { get; }
        private UserManager<ApplicationUserModel> userManager { get; }

        private IAuthorizationService _authorization;

        public AdministrationController(IRoleRepository repository, IAccountRepository accountRepository
            ,UserManager<ApplicationUserModel> _userManager, IAuthorizationService authorizationService)
        {
            this.roleRepository = repository;
            this.AccountRepository = accountRepository;
            this.userManager = _userManager;
            this._authorization = authorizationService;
        }

        [HttpGet]
        public IActionResult ListAllUsers()
        {
            var usersList = roleRepository.ListOfUsers();
            List<UserListModel> users = new List<UserListModel>();
            int i = 1;
            foreach (var user in usersList)
            {
                var u1 = new UserListModel
                {
                    sr = i,
                    UserID = user.Id,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber
                };
                i++;
                users.Add(u1);
            }
            //users.OrderBy(users => users.UserName);
            return View(users.OrderBy(users => users.UserName));
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string userID)
        {
            var result = await AccountRepository.ListUserById_Db(userID);
            var claimsFound = await userManager.GetClaimsAsync(result);
            var rolesFound = await userManager.GetRolesAsync(result);

            if (result == null)
            {
                ViewBag.ErrorMessage = $"User with- ID {userID} could not be found";
                return View("Not Found");
            }
            else
            {
                var model = new EditUserViewModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    PhoneNo = result.PhoneNumber,
                    UserName = result.UserName,
                    Roles = rolesFound.ToList(),
                    Claims = claimsFound.Select(c => c.Type + " : " + c.Value).ToList()
                };

                return View(model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var result = await AccountRepository.EditUser(model);

            if (result == true)
            {
                //ViewBag.IsSuccess = true;
                return RedirectToAction("ListAllUsers");
            }
            else
            {
                ViewBag.IsSuccess = false;
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var result = await roleRepository.CreateRoleAsync(roleModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListOfRoles", "Administration");
                    //ModelState.Clear();
                    //return View()
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(roleModel);
                }
            }
            else
            {
                return View(roleModel);
            }

            //RedirectToAction("ListOfRoles", "Administration");
        }

        [HttpGet]
        public IActionResult ListOfRoles()
        {
            var result = roleRepository.ListOfRoles();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleid)
        {
            var resultModel = await roleRepository.ListRoleByID(roleid);
            var resultUsers = await roleRepository.ListUsersByRole(roleid);

            var model = new EditRoleModel()
            {
                Id = resultModel.Id,
                RoleName = resultModel.Name
            };

            foreach (var u in resultUsers)
            {
                model.Users.Add(u.UserName);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleModel editRoleModel)
        {
            var updatedYesNo = await roleRepository.EditRole(editRoleModel);

            if (updatedYesNo == true)
            {
                return RedirectToAction("listofroles", "administration");
            }
            else
            {
                return View(editRoleModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleID)
        {
            ViewBag.RoleID = roleID;
            var role = await roleRepository.ListRoleByID(roleID);

            if (role == null)
            {

                ViewBag.ErrorMessage = $"Role with ID {roleID} not Found";
                return View("NotFound");
            }
            else
            {
                var result = await roleRepository.UsersInRoleCheck(roleID);
                return View(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> userList, string roleID)
        {
            ViewBag.RoleID = roleID;
            var role = await roleRepository.ListRoleByID(roleID);

            if (role == null)
            {

                ViewBag.ErrorMessage = $"Role with ID {roleID} not Found";
                return View("NotFound");
            }
            else
            {
                var result = await roleRepository.EditUsersInRole(userList, roleID);

                if (result == false)
                {
                    return RedirectToAction("EditUsersInRole", new { roleID = roleID });
                }
                ViewBag.IsError = true;
                return RedirectToAction("EditUsersInRole", new { roleID = roleID });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string UserID)
        {
            ViewBag.UserID = UserID;

            var user = await userManager.FindByIdAsync(UserID);
            ViewBag.UserName = user.UserName;

            if (user == null)
            {
                ViewBag.IsError = true;
                ViewBag.ErrorMessage = $"User with ID {UserID}/{user.UserName} not Found";
                return View("NotFound");
            }
            else
            {
                var roles = roleRepository.ListOfRoles();
                var model = new List<UserRolesViewModel>();

                foreach (var role in roles)
                {
                    var usrms = new UserRolesViewModel
                    {
                        RoleID = role.Id,
                        RoleName = role.Name,
                    };

                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        usrms.IsSelected = true;
                    }
                    else
                    {
                        usrms.IsSelected = false;
                    }

                    model.Add(usrms);
                }

                return View(model);
            }

        }

        [HttpPost]
        [Authorize(Policy = "EditRolePolicy")]
        public async Task<IActionResult> ManageUserRoles(string UserID, List<UserRolesViewModel> model)
        {
            //var allowed = await _authorization.AuthorizeAsync(User, "EditRolePolicy");
            //if (allowed == null)
            //{
              //  return RedirectToAction("AccessDenied","Home");
            //}

            ViewBag.UserID = UserID;

            var user = await userManager.FindByIdAsync(UserID);
            ViewBag.UserName = user.UserName;

            if (user == null)
            {
                ViewBag.IsError = true;
                ViewBag.ErrorMessage = $"User with ID {UserID}/{user.UserName} not Found";
                return View("NotFound");
            }
            else
            {
                var roles = await userManager.GetRolesAsync(user);
                var result = await userManager.RemoveFromRolesAsync(user, roles);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove existing roles");
                    return View(model);
                }

                result = await userManager.AddToRolesAsync(user,
                    model.Where(x => x.IsSelected).Select(y => y.RoleName)
                    );

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add existing roles");
                    return View(model);
                }

                return RedirectToAction("EditUser", new { userid = user.Id });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userID)
        {
            var user = await userManager.FindByIdAsync(userID);
            ViewBag.UserName = user.UserName;

            if (user == null)
            {
                ViewBag.IsError = true;
                ViewBag.ErrorMessage = $"User with ID {userID}/{user.UserName} not Found";
                return View("NotFound");
            }
            else
            {
                var existingUserClaims = await userManager.GetClaimsAsync(user);

                var model = new UserClaimsViewModel
                {
                    UserID = userID,
                };

                foreach (Claim cc in existingUserClaims)
                {
                    UserClaim userClaim = new UserClaim
                    {
                        ClaimType = cc.Type
                    };

                    if (existingUserClaims.Any(c => c.Type == cc.Type && cc.Value == "true"))
                    {
                        userClaim.IsSelected = true;
                    }

                    model.claims.Add(userClaim);
                }

                return View(model);
            }

        }

        [HttpPost]
        [Authorize(Roles="Admin")]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserID);
            ViewBag.UserName = model.UserID;

            if (user == null)
            {
                ViewBag.IsError = true;
                ViewBag.ErrorMessage = $"User with ID {model.UserID} not Found";
                return View("NotFound");
            }
            else
            {
                var claims = await userManager.GetClaimsAsync(user);
                var result = await userManager.RemoveClaimsAsync(user, claims);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot remove existing claims");
                    return View(model);
                }

                result = await userManager.AddClaimsAsync(user,
                    model.claims.Select(c => new Claim(c.ClaimType, c.IsSelected? "true" : "false"))
                    );

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Cannot add claims");
                    return View(model);
                }

                return RedirectToAction("EditUser", new { userid = model.UserID });
            }
            
        }



    } //End of Class
} //End of NameSpace
