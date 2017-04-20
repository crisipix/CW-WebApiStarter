using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WebExample.Controllers
{

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        public AccountController()
        { }

        [HttpGet]
        [Route("Main")]
        public async Task<string> GetAccount()
        {
            return await Task.Run(() => { return "Test"; });
        }
    }
}