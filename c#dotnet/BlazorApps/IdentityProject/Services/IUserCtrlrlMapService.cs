using System.Security.Claims;

namespace IdentityProject.Services
{
    public interface IUserCtrlrlMapService
    {
        List<string> GetMenuItems(ClaimsPrincipal principal);
    }
}