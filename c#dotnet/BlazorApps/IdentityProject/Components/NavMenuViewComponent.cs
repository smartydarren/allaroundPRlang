using IdentityProject.Data;
using IdentityProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityProject.Data.Procs;

namespace IdentityProject.Components
{
    public class NavMenuViewComponent : ViewComponent
    {
        protected ApplicationDbContext dbCon { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        public NavMenuViewComponent(ApplicationDbContext context,UserManager<ApplicationUser> _userManager)
        {
            this.dbCon = context;
            this.UserManager = _userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userID = new Access_GetUserID().GetUserID(HttpContext);
            var getUser = await UserManager.Users.Where(u => u.Id == userID).FirstOrDefaultAsync();
            
            if (getUser != null)
            {
                var getUserRoles = await dbCon.db_UserRolesIdentity.Where(x => x.UserId == userID).ToListAsync();
                var DistinctUserRoles = getUserRoles.Select(du => du.RoleId).ToList().Distinct();

                var CompleteMenu = await dbCon.db_Menu.ToListAsync();
                var Menu_BasedOnUserRoles = await dbCon.db_RoleMenuMap.Include(m => m.Menu)
                    .Where(x => DistinctUserRoles.Contains(x.RoleId))
                    .ToListAsync();                

                var dropDownMenus = CompleteMenu.Where(x => x.ParentMenuId == null && x.Controller == null & x.Action == null);               

                VC_NavMenuSingleTable menuTable = new VC_NavMenuSingleTable()
                {
                    UserMenu = Menu_BasedOnUserRoles.Select(mm => mm.Menu).ToList(),
                                        
                };

                menuTable.UserMenu.AddRange(dropDownMenus);
                return View(menuTable);
            }
            return View();
            
            /*var MenuListSingleTable = (from mainMenu in await dbCon.db_Menu.Where(e => e.Enabled == true && e.ParentMenu == 0).OrderBy(m => m.OrderBy).ToListAsync()
                                       join subMenu in dbCon.db_Menu.Where(s => s.Enabled == true && s.IsVisible == true && s.ParentMenu != 0).DefaultIfEmpty().OrderBy(s => s.OrderBy)
                                         on mainMenu.Id equals subMenu.ParentMenu into FullMenu

                                         
                                       //orderby mainMenu.OrderBy ascending, mainMenu.OrderBy

                                       //from CompMenu in FullMenu.DefaultIfEmpty()

                                       select new VC_NavMenuSingleTable()
                                       {
                                           //MainMenu = mainMenu,
                                           //submenu = FullMenu.ToList()
                                           //SubMenuName = CompMenu.SubMenu,
                                           //Contr = CompMenu.Controller,
                                           //ActionM = CompMenu.Action*/
                                       //})///.OrderBy(o => new {o.MainMenu.Id ,o.submenu.OrderBy(o => o.OrderBy) }); */            
           
        }
       
    }
}

