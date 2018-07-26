using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Repositories.Dos
{
    public class AccountDo
    {   
        public int Id { get; set; }
        public string Code { get; set; }
        public int OwnerId { get; set; }
    }
}