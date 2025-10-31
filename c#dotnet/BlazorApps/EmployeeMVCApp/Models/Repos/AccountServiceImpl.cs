using AllModelsAndDB.Models;
using EmployeeMVCApp.Models.DBConn;

namespace EmployeeMVCApp.Models.Repos
{
    public class AccountServiceImpl : IAccountService
    {
        protected readonly AppDataConnection _context;

        public AccountServiceImpl(AppDataConnection db)
        {
            this._context = db;
        }
        public bool Login(string username, string password)
        {
            var userCred = _context.loginUser.SingleOrDefault(a => a.UserName == username && a.Password == password);
            
            if (userCred == null)
            {
                return false;
                //N1 = new Account() { UserName = null, Password = null };
            }
            else
            {
                return true;
                //N1 = new Account() { UserName = userCred.UserName, Password = userCred.Password };
            }
           
        }
    }
}
