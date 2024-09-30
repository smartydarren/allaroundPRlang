using IdentityProject.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace IdentityProject.Services
{
    public interface IDataService
    {
        IMemoryCache _cache { get; }
        ApplicationDbContext _context { get; }
        UserManager<ApplicationUser> User { get; }

        Task<List<string>> GetMenuItemsAsync(ClaimsPrincipal principal);
    }
}