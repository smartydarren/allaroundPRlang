using LearnIdentityAut.Models;
using LearnIdentityAut.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace LearnIdentityAut.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUserModel> _userManager;
        private readonly SignInManager<ApplicationUserModel> _signInManager;
        
        
        public AccountRepository(UserManager<ApplicationUserModel> userManager, SignInManager<ApplicationUserModel> signInManager
                                   )
        {
            _userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<IdentityResult> CreateUserAsync(SingUpUserModel userModel)
        {
            var userM = new ApplicationUserModel()
            {
                Email = userModel.Email,
                UserName = userModel.Email,
                Name = userModel.Name
                
            };

            var result = await _userManager.CreateAsync(userM, userModel.Password);
            return result;
        }

        public async Task<SignInResult> SignInSync(SignInModel model)
        {
            var result =  await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();

        }
        public async Task<ApplicationUserModel> IsEmailInUse(string email)
        {
           var result =  await _userManager.FindByEmailAsync(email);
            return result;
        }

        public List<ApplicationUserModel> ListOfUsers()
        {
            var UserList = new List<ApplicationUserModel>();
            var FullList = _userManager.Users.ToList();

            foreach(var user in FullList)
            {
                UserList.Add(user);
            }

            return UserList;         
        }

        public async Task<ApplicationUserModel> ListUserById_Db(string id)
        {
            var userFound = await _userManager.FindByIdAsync(id);

            if (userFound != null)
            {
                return userFound;
            }
            else
            {
                return null;
            }         
        }

        public async Task<bool> EditUser(EditUserViewModel model)
        {
            var result = await _userManager.FindByIdAsync(model.Id);
           
            if (result == null)
            {
                return false;
            }
            else
            {
                result.Id = model.Id;
                result.Name = model.Name;
                result.UserName = model.UserName;
                result.PhoneNumber = model.PhoneNo;

                    var result1 = await _userManager.UpdateAsync(result);

                    if (result1.Succeeded)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }                                             
            }

        }
    }
}
