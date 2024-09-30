namespace IdentityProject.Data.Procs
{
    public class Access_GetUserID
    {
        public int UserID = 0;

        public int GetUserID(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                var userClaim = context.User.FindFirst("UserID");
                var UserID = Convert.ToInt32(userClaim.Value);
                return UserID;
            }
            return 0;
            
        }
          
    }
}
