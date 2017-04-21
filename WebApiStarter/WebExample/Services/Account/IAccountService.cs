using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebExample.Services.Account
{
    public interface IAccountService
    {
        IEnumerable<string> GetAccounts();
    }
}
