using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExample.Models;
using WebExample.Services.Person;

namespace WebExample.Controllers
{
    [RoutePrefix("api/Person")]
    public class PersonController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IPersonService _service;

        public PersonController(IPersonService service) {
            _service = service;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PersonModel>> GetPeople()
        {
            Log.Debug("Get Person");

            return await Task.Run(() =>  _service.GetPeople());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<PersonModel> GetPersonById(int Id)
        {
            Log.Debug("Get Person");

            return await Task.Run(() => _service.GetPersonById(Id));
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<PersonModel> InsertPerson(PersonModel person)
        {
            Log.Debug("Insert Person");

            return await Task.Run(() => _service.InsertPerson(person));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<PersonModel> UpdatePerson(PersonModel person)
        {
            Log.Debug("Update Person");

            return await Task.Run(() => _service.UpdatePerson(person));
        }
    }
}