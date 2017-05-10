using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiStarter.Specs.Common;
using WebExample.DataAccess.Services.Account;
using System.Linq;
using WebExample.DataAccess.Models;

namespace WebApiStarter.Specs
{
    [TestClass]
    public class AccountServiceSpecs : TestBase
    {
        protected IAccountService AccountService;
        public AccountServiceSpecs()
        {
               
        }

        [TestInitialize]
        public void Setup()
        {
            AccountService = Resolve<IAccountService>();
            base.BeforeEachTest();
        }

        [TestCleanup]
        public void TearDown()
        {
            AccountService = null;
            base.AfterEachTest();
            ShutdownIoC();
        }


        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void When_retrieving_accounts()
        {
            var accounts = AccountService.GetAccounts();
            Assert.IsTrue(accounts.Any());
        }


        [TestMethod]
        public void When_updatinging_accounts()
        {
            var code = "Updated";
            var personId = 2;
            var updatedAccount = new AccountModel { Id = 1, Code = code, Owner=new PersonModel { Id = personId} };
                updatedAccount= AccountService.UpdateAccount(updatedAccount);
            Assert.IsNotNull(updatedAccount);
            Assert.AreEqual(code, updatedAccount.Code);
            Assert.AreEqual(personId, updatedAccount.Owner.Id);
        }

        [TestMethod]
        public void When_insertinging_accounts()
        {
            var code = "Test Insert";
            var personId = 2;
            var insertedAccount = new AccountModel { Code = code, Owner = new PersonModel { Id = personId } };
            insertedAccount = AccountService.InsertAccount(insertedAccount);
            Assert.IsNotNull(insertedAccount);
            Assert.IsTrue(insertedAccount.Id >0);
            Assert.AreEqual(code, insertedAccount.Code);
            Assert.AreEqual(personId, insertedAccount.Owner.Id);
        }
    }
}
