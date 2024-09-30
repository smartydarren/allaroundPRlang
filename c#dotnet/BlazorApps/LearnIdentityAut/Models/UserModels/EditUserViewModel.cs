using System.ComponentModel;

namespace LearnIdentityAut.Models.UserModels
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Roles = new List<string>(); Claims = new List<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PhoneNo { get; set; }

        public List<string> Roles { get; set; }
        public List<string> Claims { get; set; }
    }
}
