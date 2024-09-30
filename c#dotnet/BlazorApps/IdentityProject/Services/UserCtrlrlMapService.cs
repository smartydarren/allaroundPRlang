using IdentityProject.Data;
using IdentityProject.Models.ViewModels.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace IdentityProject.Services
{
    public class UserCtrlrlMapService : IUserCtrlrlMapService
    {
        public UserCtrlrlMapService()
        {
        }
        public List<string> GetMenuItems(ClaimsPrincipal principal)
        {
            var p1 = principal.Claims.Select(claim => new ListAllClaimsViewModel
            { cType = claim.Type, cValue = claim.Value }).ToList();

            List<string> listtoCache = new List<string>();

            if (p1.Any())
            {
                foreach (var claim in p1.Where(c => c.cType=="Controller"))
                {
                    string ctrl = claim.cValue;

                    listtoCache.Add(ctrl);
                }
            };

            return listtoCache;
        }
    }
}
