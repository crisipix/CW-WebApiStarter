using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStarter.Specs.Common;
using WebExample.DataAccess.Repositories;
using WebExample.DataAccess.Repositories.Dos;

namespace WebApiStarter.Specs.Repository
{

    [TestClass]
    public class StoreRepositorySpecs : TestBase
    {
        protected BaseRepository<StoreDo> StoreRepository;
        public StoreRepositorySpecs()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            StoreRepository = Resolve<BaseRepository<StoreDo>>();
            base.BeforeEachTest();
        }

        [TestCleanup]
        public void TearDown()
        {
            StoreRepository = null;
            base.AfterEachTest();
            ShutdownIoC();
        }


        [TestMethod]
        public void When_retrieving_stores()
        {
            var stores = StoreRepository.GetAll();
            Assert.IsTrue(stores.Any());
        }

        [TestMethod]
        public void When_retrieving_store_by_id()
        {
            var store = StoreRepository.Get(3);
            Assert.IsNotNull(store);
            Assert.AreEqual(3, store.Id);
        }


        [TestMethod]
        public void When_updatinging_stores()
        {
            var code = "Updated";
            var updatedStore = new StoreDo { Id = 3, Code = code };
            updatedStore = StoreRepository.Update(updatedStore);
            Assert.IsNotNull(updatedStore);
            Assert.AreEqual(code, updatedStore.Code);
            Assert.AreEqual(3, updatedStore.Id);
        }

        [TestMethod]
        public void When_insertinging_stores()
        {
            var code = "Test Insert";
            var insertStore = new StoreDo { Code = code };
            insertStore = StoreRepository.Insert(insertStore);
            Assert.IsNotNull(insertStore);
            Assert.IsTrue(insertStore.Id > 0);
            Assert.AreEqual(code, insertStore.Code);
        }
    }
}
