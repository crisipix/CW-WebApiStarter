using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;

namespace $safeprojectname$.Services.Account
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> GetAccounts();
        AccountModel GetAccountById(int id);
        AccountModel InsertAccount(AccountModel account);
        AccountModel UpdateAccount(AccountModel account);
        bool DeleteAccount(int Id);
    }
}
