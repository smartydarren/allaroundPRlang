using LearnIdentityAut.Models;
using LearnIdentityAut.Models.RoleModels;
using Microsoft.AspNetCore.Identity;

namespace LearnIdentityAut.Repository
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateRoleAsync(CreateRoleModel userModel);
        Task<bool> EditRole(EditRoleModel editRoleModel);
        Task<bool> EditUsersInRole(List<UserRoleViewModel> userList, string roleID);
        List<IdentityRole> ListOfRoles();
        List<ApplicationUserModel> ListOfUsers();
        Task<IdentityRole> ListRoleByID(string roleId);
        Task<List<ApplicationUserModel>> ListUsersByRole(string roleId);
        Task<List<UserRoleViewModel>> UsersInRoleCheck(string roleID);
    }
}