using IdentityProject.Data;
using IdentityProject.Models;
using IdentityProject.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;


namespace IdentityProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(ApplicationDbContext dbcon,
                UserManager<ApplicationUser> _user, SignInManager<ApplicationUser> _signInManager)
        {

            this.dbContext = dbcon;
            this.userManager = _user;
            this.signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register(string? returnUrl = null)
        {
            Access_UserCreationViewModel registerUser = new Access_UserCreationViewModel();
            registerUser.ReturnUrl = returnUrl;
            ViewBag.Success = false;
            return View(registerUser);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Access_UserCreationViewModel model, string? returnUrl = null)
        {
            model.ReturnUrl = returnUrl;
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var usercheckIdent = userManager.Users.Where(u => u.Email == model.Email || u.UserName == model.UserId).FirstOrDefault();
                //var usercheck = dbContext.db_Users.Where(u => u.Email == model.Email).FirstOrDefault();
                if (usercheckIdent != null)
                {
                    ModelState.AddModelError(string.Empty, model.Email + " Already exists");
                }
                else
                {
                    var CreateUser = new ApplicationUser
                    {
                        Name = model.Name,
                        UserName = model.UserId,
                        Email = model.Email
                        //PasswordHash = model.Password                       
                    };

                    var result = await userManager.CreateAsync(CreateUser, model.Password); //dbContext.AddAsync(CreateUser);
                    //var result1 = await dbContext.SaveChangesAsync();

                    if (result.Succeeded)
                    {
                        //await signInManager.SignInAsync(user, isPersistent: false);
                        ModelState.Clear();
                        ViewBag.Success = true;
                        return View();
                    }
                }
                ModelState.AddModelError("Email", "User could not be created");
            }
            return View(model);
        }

        [HttpGet]
        //[Authorize(Policy = "RBAC")]
        [AllowAnonymous]
        public IActionResult Login(string? returnurl = null)
        {
            returnurl ??= Url.Content("~/");
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return LocalRedirect(returnurl);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        //[Authorize(Policy ="RBAC")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Access_LoginViewModel model, string? returnurl = null)
        {
            returnurl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var userDetails = userManager.Users.Where(u => u.UserName == model.UserName).FirstOrDefault();

                //var usercheck = dbContext.db_Users.Where(u => u.Email == model.UserName && u.Password == model.Password).FirstOrDefault();
                var usercheck = await userManager.CheckPasswordAsync(userDetails, model.Password);

                if (!usercheck == true)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Email or Password");
                    //ModelState.Clear();
                    return View();
                }
                else
                {
                    var customNameClaimType = "custom-name-claim";
                    var claims = new List<Claim>
                {
                    new Claim(customNameClaimType, userDetails.Email),
                    new Claim(ClaimTypes.UserData, userDetails.NormalizedEmail.ToString()),
                    new Claim(ClaimTypes.Authentication, userDetails.UserName),
                    new Claim("UserID",userDetails.Id.ToString()),
                    new Claim("CreatedBy", "Darren"),
                    new Claim("CreateDate",DateTime.Now.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, userDetails.Email),
                };
                   
                    var listOfRolesIDs = dbContext.db_UserRolesIdentity.Where(x => x.UserId == userDetails.Id)
                        .Select(r => r.RoleId).ToList();
                    var Menu_BasedOnUserRoles = await dbContext.db_RoleMenuMap.Include(m => m.Menu)
                    .Where(x => listOfRolesIDs.Contains(x.RoleId))
                    .ToListAsync();

                    List<string> listtoCache = new List<string>();

                    foreach (var item in Menu_BasedOnUserRoles)
                    {
                        listtoCache.Add(item.Menu.Controller.ToString());
                    };

                    foreach (var role in listtoCache)
                    {
                        var ccc = new Claim("Controller", role);
                        claims.Add(ccc);
                    }

                    var identity1 = new ClaimsIdentity(claims: claims, CookieAuthenticationDefaults.AuthenticationScheme);                    
                    var identities = new List<ClaimsIdentity>();
                    identities.Add(identity1); identities.Add(identity1);

                    var principal = new ClaimsPrincipal(identities);

                    await signInManager.SignInWithClaimsAsync(userDetails, true, claims);// SignInWithClaimsAsync(userDetails,false,claims);

                    //await HttpContext.SignInAsync(principal, new AuthenticationProperties { IsPersistent = false, IssuedUtc = DateTime.Now, AllowRefresh = true });

                   // await Context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = false, IssuedUtc = DateTime.Now });                   

                    //getting the Menu


                    //TempData["MenuMaster"] = menus; //Bind the _menus list to MenuMaster session  

                    return LocalRedirect(returnurl);
                }
            }
            ModelState.Clear();
            return View(model);
        }
        

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()//string? returnurl = null)
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
            /*if (returnurl != null)
            {
                return LocalRedirect(returnurl);
            }
            else
            {
                return RedirectToAction("Login");
            }*/
        }

        [HttpGet]
        [AllowAnonymous]
        //[Authorize(Policy = "RBAC")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }   
}
