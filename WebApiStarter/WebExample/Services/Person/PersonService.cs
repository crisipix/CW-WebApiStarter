using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Dos;
using WebExample.DataAccess.Repositories;
using WebExample.Models;

namespace WebExample.Services.Person
{
    public class PersonService : IPersonService
    {
        private BaseRepository<PersonDo> _repository;
        public PersonService(BaseRepository<PersonDo> repository)
        {
            _repository = repository;
        }

        public IEnumerable<PersonModel> GetPeople()
        {
            var people = Mapper.Map<IEnumerable<PersonDo>, IEnumerable<PersonModel>>(_repository.GetAll());
            return people;
            //return Enumerable.Empty<PersonModel>();
        }

        public PersonModel GetPersonById(int id)            
        {
            var person = Mapper.Map<PersonDo, PersonModel>(_repository.Get(id));
            return person;
            //return new PersonModel { };
        }

        public PersonModel InsertPerson(PersonModel person) {
            var personDo =  Mapper.Map<PersonModel, PersonDo>(person);
            personDo =  _repository.Insert(personDo);
            return Mapper.Map<PersonDo, PersonModel>(personDo);
        }

        public PersonModel UpdatePerson(PersonModel person) {
            var personDo = Mapper.Map<PersonModel, PersonDo>(person);

            personDo = _repository.Update(personDo);

            return Mapper.Map<PersonDo, PersonModel>(personDo);
        }

        public bool DeletePerson(int Id)
        {
            return _repository.Delete(Id);
        }



    }
}