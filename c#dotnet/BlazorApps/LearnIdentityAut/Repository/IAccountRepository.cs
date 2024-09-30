using LearnIdentityAut.Models;
using LearnIdentityAut.Models.UserModels;
using Microsoft.AspNetCore.Identity;

namespace LearnIdentityAut.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SingUpUserModel userModel);
        Task<SignInResult> SignInSync(SignInModel model);
        Task SignOut();

        Task<ApplicationUserModel> IsEmailInUse(string email);
        List<ApplicationUserModel> ListOfUsers();
        Task<ApplicationUserModel> ListUserById_Db(string id);
        Task<bool> EditUser(EditUserViewModel model);
    }
}