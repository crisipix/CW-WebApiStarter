using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using $safeprojectname$.Models;

namespace $safeprojectname$.Services.Person
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> GetPeople();
        PersonModel GetPersonById(int id);

        PersonModel InsertPerson(PersonModel person);
        PersonModel UpdatePerson(PersonModel person);

        bool DeletePerson(int Id);
    }
}
