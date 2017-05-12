using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStarter.Specs.Common;
using WebExample.DataAccess.Models;
using WebExample.DataAccess.Services.Person;

namespace WebApiStarter.Specs.Servicce
{
    [TestClass]
    public class PersonServiceSpecs : TestBase
    {
        protected IPersonService PersonService;
        public PersonServiceSpecs()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            PersonService = Resolve<IPersonService>();
            base.BeforeEachTest();
        }

        [TestCleanup]
        public void TearDown()
        {
            PersonService = null;
            base.AfterEachTest();
            ShutdownIoC();
        }


        [TestMethod]
        public void When_retrieving_persons()
        {
            var people = PersonService.GetPeople();
            Assert.IsTrue(people.Any());
        }


        [TestMethod]
        public void When_updatinging_person()
        {
            var name = "Updated";
            var personId = 2;
            var updatedPerson = new PersonModel {  Id = personId , Age = 33, Name= name };
            updatedPerson = PersonService.UpdatePerson(updatedPerson);
            Assert.IsNotNull(updatedPerson);
            Assert.AreEqual(name, updatedPerson.Name);
            Assert.AreEqual(33, updatedPerson.Age);
            Assert.AreEqual(personId, updatedPerson.Id);
        }

        [TestMethod]
        public void When_insertinging_person()
        {
            var name = "Test Insert";
            var insertedPerson = new PersonModel { Age = 33, Name = name };
            insertedPerson = PersonService.InsertPerson(insertedPerson);
            Assert.IsNotNull(insertedPerson);
            Assert.IsTrue(insertedPerson.Id > 0);
            Assert.AreEqual(name, insertedPerson.Name);
            Assert.AreEqual(33, insertedPerson.Age);
        }
    }
    }
