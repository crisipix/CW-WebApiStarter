using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WebExample.App_Start;

namespace WebApiStarter.Specs.Common
{
    [TestClass]
    public abstract class TestBase
    {
        /*
             https://juristr.com/blog/2011/12/writing-ioc-supported-integration-tests/
             http://www.petermorlion.com/integration-testing-in-memory-webapi-with-autofac/
             Tests in general
            http://www.codeproject.com/Articles/1083779/RESTful-Day-sharp-Unit-Testing-and-Integration-T

            Rollback sql
            http://www.programgood.net/2016/04/27/IntegrationTestingWithDapper.aspx
        */
        private IContainer container;
        // direct access to the db
        protected string ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        private TransactionScope scope;
        private DbConnection db;

        public TestBase()
        {
            var builder = new ContainerBuilder();

            // builder.RegisterModule(new TModule());
            AutoFacServiceConfig.RegisterServices(builder);
            container = builder.Build();
        }

        // before each test
        [TestInitialize]
        public void BeforeEachTest()
        {
            // direct access to the db
            db = new SqlConnection(ConnectionString);

            scope = new TransactionScope();

            // going through the repo
            //c = new DapperUserRepositoryTestContext();
        }
        // after each test
        [TestCleanup]
        public void AfterEachTest()
        {
            scope.Dispose();
            db.Dispose();
        }

        protected TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

        protected void ShutdownIoC()
        {
            container.Dispose();
        }
    }
}
