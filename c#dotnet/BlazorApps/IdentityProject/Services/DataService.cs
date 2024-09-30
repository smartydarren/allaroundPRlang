using IdentityProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace IdentityProject.Services
{
    public class DataService : IDataService
    {
        public ApplicationDbContext _context { get; }
        public IMemoryCache _cache { get; }
        public UserManager<ApplicationUser> User { get; }
                

        public DataService(ApplicationDbContext context, IMemoryCache cache,
            UserManager<ApplicationUser> _user)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<string>> GetMenuItemsAsync(ClaimsPrincipal principal)
        {
            //List<Access_RoleMenuMap> CacheMenu;
            var userClaim = principal.FindFirst("UserID");
            var cacheKey = $"key-{userClaim}";
            List<string> cache;

            if (!_cache.TryGetValue(cacheKey, out cache)){

                
                var UserID = Convert.ToInt32(userClaim?.Value);
                var getUserRoles = await _context.db_UserRolesIdentity.Where(x => x.UserId == UserID).ToListAsync();
                var DistinctUserRoles = getUserRoles.Select(du => du.RoleId).ToList().Distinct();
                var Menu_BasedOnUserRoles = await _context.db_RoleMenuMap.Include(m => m.Menu)
                    .Where(x => DistinctUserRoles.Contains(x.RoleId))
                    .ToListAsync();
                
                List<string> listtoCache = new List<string>();    

                foreach (var item in Menu_BasedOnUserRoles)
                {
                    listtoCache.Add(item.Menu.Controller.ToString());
                };
                
                cache = listtoCache;

                _cache.Set(cacheKey, cache,
                    new MemoryCacheEntryOptions
                    {
                        SlidingExpiration = TimeSpan.FromSeconds(60),
                        AbsoluteExpiration = DateTimeOffset.UtcNow.AddSeconds(120)
                    });
                Console.WriteLine("Calling the DataBase");
            }

            /*var Menu_BasedOnUserRoles = await _cache.GetOrCreateAsync("userRoles",
                async x => await (
                _context.db_RoleMenuMap.Include(m => m.Menu)
                .Where(x => DistinctUserRoles.Contains(x.RoleId))
                .ToListAsync()));*/           

            return cache;
        }

    }
}
