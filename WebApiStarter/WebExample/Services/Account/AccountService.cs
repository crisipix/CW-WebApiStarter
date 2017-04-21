using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExample.Services.Account
{
    public class AccountService : IAccountService
    {
        public AccountService() { }
        public IEnumerable<string> GetAccounts() {
            //return Enumerable.Empty<string>();
            return new List<string> { "A", "B", "C" };
        }
    }
}