using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Application.Commands
{
    public class RegisterJobSeekerCommand
    {
        public RegisterJobSeekerCommand()
        {

        }

        public RegisterJobSeekerCommand(String email, String firstName, String lastName)
        {
            this.Email = email;
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}
