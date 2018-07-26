using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using $safeprojectname$.DataAccess.Models;
using $safeprojectname$.DataAccess.Services.Person;

namespace $safeprojectname$.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;

        private readonly IPersonService _service;

        public PersonController(IPersonService service,
            ILog log) {
            _service = service;
            _log = log;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PersonModel>> GetPeople()
        {
            _log.Debug("Get Person");

            return await Task.Run(() =>  _service.GetPeople());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<PersonModel> GetPersonById(int Id)
        {
            _log.Debug("Get Person");

            return await Task.Run(() => _service.GetPersonById(Id));
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<PersonModel> InsertPerson(PersonModel person)
        {
            _log.Debug("Insert Person");

            return await Task.Run(() => _service.InsertPerson(person));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<PersonModel> UpdatePerson(PersonModel person)
        {
            _log.Debug("Update Person");

            return await Task.Run(() => _service.UpdatePerson(person));
        }

        [HttpDelete]
        public async Task<bool> UpdatePerson(int Id)
        {
            _log.Debug("Delete Person");

            return await Task.Run(() => _service.DeletePerson(Id));
        }
    }
}