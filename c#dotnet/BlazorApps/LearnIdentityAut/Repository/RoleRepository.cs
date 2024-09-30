using LearnIdentityAut.Models;
using LearnIdentityAut.Models.RoleModels;
using Microsoft.AspNetCore.Identity;

namespace LearnIdentityAut.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private UserManager<ApplicationUserModel> UserManager { get; }

        public RoleRepository(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUserModel> userManager)
        {
            this.roleManager = roleManager;
            this.UserManager = userManager;
        }

        public List<ApplicationUserModel> ListOfUsers()
        {

            return UserManager.Users.ToList();
        }

        public async Task<IdentityResult> CreateRoleAsync(CreateRoleModel userModel)
        {
            var userM = new IdentityRole()
            {

                Name = userModel.RoleName

            };
            var result = await roleManager.CreateAsync(userM);
            return result;
        }

        public List<IdentityRole> ListOfRoles()
        {
            var ListOfRoles = roleManager.Roles.ToList();
            return ListOfRoles;
        }

        public async Task<IdentityRole> ListRoleByID(string roleId)
        {
            var result = await roleManager.FindByIdAsync(roleId);

            return result;
        }

        public async Task<List<ApplicationUserModel>> ListUsersByRole(string roleId)
        {
            var IdenRole = await ListRoleByID(roleId);
            var rolename = IdenRole.Name;

            List<ApplicationUserModel> UsersInRole = new List<ApplicationUserModel>();

            foreach(var appuser in UserManager.Users)
            {
                if((await UserManager.IsInRoleAsync(appuser, rolename)))
                {
                    UsersInRole.Add(appuser);
                };
            }
            return UsersInRole;
        }

        public async Task<bool> EditRole(EditRoleModel editRoleModel)
        {
            var roleCheck = await roleManager.FindByIdAsync(editRoleModel.Id);
            if (roleCheck != null)
            {
                roleCheck.Name = editRoleModel.RoleName;
                var result = await roleManager.UpdateAsync(roleCheck);

                if (result.Succeeded)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        public async Task<List<UserRoleViewModel>> UsersInRoleCheck(string roleID)
        {
            var role = await ListRoleByID(roleID);

            List<UserRoleViewModel> ListOfUsersInRole = new List<UserRoleViewModel>();

            foreach (var user in UserManager.Users)
            {
                UserRoleViewModel UserInRole = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if (await UserManager.IsInRoleAsync(user, role.Name))
                {
                    UserInRole.IsSelected = true;
                }
                else
                {
                    UserInRole.IsSelected = false;
                }

                ListOfUsersInRole.Add(UserInRole);

            }
            return ListOfUsersInRole;
        }

        public async Task<bool> EditUsersInRole(List<UserRoleViewModel> userList, string roleID)
        {
            IdentityRole roleName = await roleManager.FindByIdAsync(roleID);
            bool succ = true;

            for (int i = 0; i < userList.Count; i++)
            {
                var userRetr = await UserManager.FindByIdAsync(userList[i].UserId);

                IdentityResult result = null;

                if (userList[i].IsSelected && !(await UserManager.IsInRoleAsync(userRetr, roleName.Name)))
                {
                    result = await UserManager.AddToRoleAsync(userRetr, roleName.Name);
                }
                else if (!userList[i].IsSelected && (await UserManager.IsInRoleAsync(userRetr, roleName.Name)))
                {
                    result = await UserManager.RemoveFromRoleAsync(userRetr, roleName.Name);
                }
                else
                {
                    continue;
                }
                if (result.Succeeded)
                {
                    if (i < (userList.Count - 1))
                        continue;
                    else
                       succ = false;
                }  
            }
           return succ;

            
        }
    }
}
