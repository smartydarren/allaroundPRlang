namespace LearnIdentityAut.ViewModels.UserAccess
{
    public class UserClaimsViewModel
    {
        public string UserID { get; set; }
        public List<UserClaim> claims { get; set; }

        public UserClaimsViewModel()
        {
            claims = new List<UserClaim>();
        }
    }
}
