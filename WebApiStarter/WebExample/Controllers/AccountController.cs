using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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
        public async Task<IEnumerable<string>> GetAccounts()
        {
            Log.Debug("GET Accounts");
            return await Task.Run(() =>_service.GetAccounts());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<string> GetAccount(int id)
        {
            Log.Debug("GET Account by id");
            return await Task.Run(() => {return _service.GetAccountById(id); });
        }


    }
}