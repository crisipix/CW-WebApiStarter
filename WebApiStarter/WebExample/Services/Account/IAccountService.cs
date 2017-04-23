using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Services.Account
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
