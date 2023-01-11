using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1;

namespace Cw3.Models
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string dateOfBirth { get; set; }
        public Studies studies {get; set;}
        public string email { get; set; }  
        public string fathersName { get; set; } 
        public string mothersName { get; set; }

        public override string ToString()
        {
            return FirstName + "," + LastName + "," + IndexNumber + "," + dateOfBirth + "," + studies.studiesName + "," + studies.studiesMode + "," + email + "," + fathersName + "," + mothersName;
        }

    }

    
}
