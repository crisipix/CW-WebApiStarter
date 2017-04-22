using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebExample.Models;

namespace WebExample.Services.Person
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetPeople();
        PersonModel GetPersonById(int id);

        PersonModel InsertPerson(PersonModel person);
        PersonModel UpdatePerson(PersonModel person);
    }
}
