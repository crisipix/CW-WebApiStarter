using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Services.Store;

namespace WebExample.Controllers
{
   

    [RoutePrefix("api/Store")]
    public class StoreController : ApiController
    {
        //private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ILog _log;

        private readonly IStoreService _service;

        public StoreController(IStoreService service,
            ILog log)
        {
            _service = service;
            _log = log;
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<StoreModel>> GetStores()
        {
            _log.Debug("Get Store");

            return await Task.Run(() => _service.GetStores());
        }

        [HttpGet]
        [Route("Id")]
        public async Task<StoreModel> GetStoreById(int Id)
        {
            _log.Debug("Get Store");

            return await Task.Run(() => _service.GetStoreById(Id));
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<StoreModel> InsertStore(StoreModel Store)
        {
            _log.Debug("Insert Store");

            return await Task.Run(() => _service.InsertStore(Store));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<StoreModel> UpdateStore(StoreModel Store)
        {
            _log.Debug("Update Store");

            return await Task.Run(() => _service.UpdateStore(Store));
        }

        [HttpDelete]
        public async Task<bool> UpdateStore(int Id)
        {
            _log.Debug("Delete Store");

            return await Task.Run(() => _service.DeleteStore(Id));
        }
    }
}