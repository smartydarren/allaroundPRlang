using AllModelsAndDB.Models;

namespace EmployeeMVCApp.Models.Repos
{
    public interface IAccountService
    {
        public bool Login(string username, string password);
    }
}
