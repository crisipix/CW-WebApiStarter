using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using $safeprojectname$.DataAccess.Models;
using $safeprojectname$.DataAccess.Services.Account;

namespace $safeprojectname$.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    { 
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;
        private readonly IAccountService _service;
        public AccountController(IAccountService service, ILog log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<AccountModel>> GetAccounts()
        {
            _log.Debug("GET Accounts");
            return await Task.Run(() =>_service.GetAccounts());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<AccountModel> GetAccount(int id)
        {
            _log.Debug("GET Account by id");
            return await Task.Run(() => {return _service.GetAccountById(id); });
        }


        [HttpPost]
        [Route("Insert")]
        public async Task<AccountModel> InsertPerson(AccountModel person)
        {
            _log.Debug("Insert Person");

            return await Task.Run(() => _service.InsertAccount(person));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<AccountModel> UpdatePerson(AccountModel person)
        {
            _log.Debug("Update Person");

            return await Task.Run(() => _service.UpdateAccount(person));
        }

        [HttpDelete]
        public async Task<bool> UpdatePerson(int Id)
        {
            _log.Debug("Delete Person");

            return await Task.Run(() => _service.DeleteAccount(Id));
        }

    }
}