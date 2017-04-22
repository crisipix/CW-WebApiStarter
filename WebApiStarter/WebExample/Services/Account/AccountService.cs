using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExample.Services.Account
{
    public class AccountService : IAccountService
    {

        private IDictionary<int, string> Accounts;      
        
        public AccountService() {
            var accounts = new string[] { "A", "B", "C" };
            Accounts = accounts.Select((x, y) => new { Key = y, Value = x })
                                .GroupBy(x => x.Key)
                                .ToDictionary(x => x.Key, y => y.First()?.Value);
        }
        public IEnumerable<string> GetAccounts() {
            return Accounts.Values;
        }

        public string GetAccountById(int id) {
            string value;
            if (Accounts.TryGetValue(id, out value)) { return value; }
            return string.Empty;
        }
    }
}