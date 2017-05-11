using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.DataAccess.Models;

namespace WebExample.DataAccess.Services.Store
{
    public interface IStoreService
    {
        IEnumerable<StoreModel> GetStores();
        StoreModel GetStoreById(int id);

        StoreModel InsertStore(StoreModel store);
        StoreModel UpdateStore(StoreModel store);

        bool DeleteStore(int Id);
    }
}
