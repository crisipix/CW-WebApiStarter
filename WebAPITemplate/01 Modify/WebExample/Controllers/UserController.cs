using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace $safeprojectname$.Controllers
{
   
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly ILog _log;

        public UserController(ILog log)
        {
            _log = log;
        }

        [HttpGet]
        [Route("")]
        public async Task<string> GetUser()
        {
            _log.Debug("Get User");

            return User.Identity.Name;
        }
 
    }
}