using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExample.Models;
using WebExample.Services.Account;

namespace WebExample.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AccountModel>> GetAccounts()
        {
            Log.Debug("GET Accounts");
            return await Task.Run(() =>_service.GetAccounts());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<AccountModel> GetAccount(int id)
        {
            Log.Debug("GET Account by id");
            return await Task.Run(() => {return _service.GetAccountById(id); });
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<AccountModel> InsertPerson(AccountModel person)
        {
            Log.Debug("Insert Person");

            return await Task.Run(() => _service.InsertAccount(person));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AccountModel> UpdatePerson(AccountModel person)
        {
            Log.Debug("Update Person");

            return await Task.Run(() => _service.UpdateAccount(person));
        }

        [HttpDelete]
        public async Task<bool> UpdatePerson(int Id)
        {
            Log.Debug("Delete Person");

            return await Task.Run(() => _service.DeleteAccount(Id));
        }

    }
}