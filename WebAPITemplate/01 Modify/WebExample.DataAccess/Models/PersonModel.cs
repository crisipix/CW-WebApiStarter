using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace $safeprojectname$.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public bool CanVote { get; set; }
    }
}