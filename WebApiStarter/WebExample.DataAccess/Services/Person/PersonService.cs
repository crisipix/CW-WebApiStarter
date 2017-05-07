using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebExample.DataAccess.Repositories.Dos;
using WebExample.DataAccess.Repositories;
using WebExample.DataAccess.Models;

namespace WebExample.DataAccess.Services.Person
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private BaseRepository<PersonDo> _repository;
        public PersonService(
            IMapper mapper,
            BaseRepository<PersonDo> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public IEnumerable<PersonModel> GetPeople()
        {
            var people = _mapper.Map<IEnumerable<PersonDo>, IEnumerable<PersonModel>>(_repository.GetAll());
            return people;
            //return Enumerable.Empty<PersonModel>();
        }

        public PersonModel GetPersonById(int id)            
        {
            var person = _mapper.Map<PersonDo, PersonModel>(_repository.Get(id));
            return person;
            //return new PersonModel { };
        }

        public PersonModel InsertPerson(PersonModel person) {
            var personDo = _mapper.Map<PersonModel, PersonDo>(person);
            personDo =  _repository.Insert(personDo);
            return _mapper.Map<PersonDo, PersonModel>(personDo);
        }

        public PersonModel UpdatePerson(PersonModel person) {
            var personDo = _mapper.Map<PersonModel, PersonDo>(person);

            personDo = _repository.Update(personDo);

            return _mapper.Map<PersonDo, PersonModel>(personDo);
        }

        public bool DeletePerson(int Id)
        {
            return _repository.Delete(Id);
        }



    }
}