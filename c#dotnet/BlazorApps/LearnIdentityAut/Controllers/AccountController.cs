using LearnIdentityAut.Models;
using LearnIdentityAut.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnIdentityAut.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepo;

        public AccountController(IAccountRepository accountRepo)
        {
            this._accountRepo = accountRepo;
        }

        [AllowAnonymous]
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> SignUp(SingUpUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepo.CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(userModel);
                }
                bool Success = true;
                ViewBag.Success = Success;             
            }
            //Signing in the user if the ID is succcessfully created
            SignInModel user = new SignInModel { Email = userModel.Email, Password = userModel.Password, RememberMe = false };
            await _accountRepo.SignInSync(user);
            return RedirectToAction("listallusers", "Administration");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInModel userModel)
        {
            if (ModelState.IsValid)
            {
                var UserCheck =  await _accountRepo.SignInSync(userModel);

                if (UserCheck.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Credentials");
                    return View();
                }
                
            }
            //ModelState.Clear();
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await _accountRepo.SignOut();
            return RedirectToAction("SignIn","Account");
        }

        [HttpGet][HttpPost]
        [AllowAnonymous]
        //[AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsEmailInUseForNewUser(string email)
        {
            var user = await _accountRepo.IsEmailInUse(email);

            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }
    }
}
