using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models
{
    public class AccountModel: IRecordPermission
    {
        public AccountModel() {
            Owner = new PersonModel();      
        }
        public int Id { get; set; }
        public string Code { get; set; }
        //public int OwnerId { get; set; }
        public PersonModel Owner { get; set; }
        public string Identifier { get; set; }
    }
}