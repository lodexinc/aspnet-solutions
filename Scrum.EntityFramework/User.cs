using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class User
    {
        public String Email { get; set; }
        public String PasswordHash { get; set; }
        public String FirsName { get; set; }
        public String LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
