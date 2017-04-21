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
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<string>> GetAccounts()
        {
            return await Task.Run(() =>_service.GetAccounts());
        }

        [HttpGet]
        [Route("FirstAccount")]
        public async Task<string> GetAccount()
        {
            return await Task.Run(() => { return "Test"; });
        }


    }
}