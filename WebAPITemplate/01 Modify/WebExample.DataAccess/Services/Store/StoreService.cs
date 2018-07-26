using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;
using $safeprojectname$.Repositories;
using $safeprojectname$.Repositories.Dos;

namespace $safeprojectname$.Services.Store
{
    public class StoreService : IStoreService
    {
        private readonly IMapper _mapper;
        private BaseRepository<StoreDo> _repository;
        public StoreService(
            IMapper mapper,
            BaseRepository<StoreDo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<StoreModel> GetStores()
        {
            var stores = _mapper.Map<IEnumerable<StoreDo>, IEnumerable<StoreModel>>(_repository.GetAll());
            return stores;
        }

        public StoreModel GetStoreById(int id)
        {
            var store = _mapper.Map<StoreDo, StoreModel>(_repository.Get(id));
            return store;
        }

        public StoreModel InsertStore(StoreModel store)
        {
            var storeDo = _mapper.Map<StoreModel, StoreDo>(store);
            storeDo = _repository.Insert(storeDo);
            return _mapper.Map<StoreDo, StoreModel>(storeDo);
        }

        public StoreModel UpdateStore(StoreModel store)
        {
            var storeDo = _mapper.Map<StoreModel, StoreDo>(store);

            storeDo = _repository.Update(storeDo);

            return _mapper.Map<StoreDo, StoreModel>(storeDo);
        }

        public bool DeleteStore(int Id)
        {
            return _repository.Delete(Id);
        }

    }
}
