using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebExample.DataAccess.Models
{
    public class AccountModel
    {
        public AccountModel() {
            Owner = new PersonModel();      
        }
        public int Id { get; set; }
        public string Code { get; set; }
        //public int OwnerId { get; set; }
        public PersonModel Owner { get; set; }
    }
}