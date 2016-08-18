using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application.Commands
{
    public class RegisterCommand
    {
        [Required]
        [Display(Name = "User name")]
        public String Email { get; set; }

        [Required]
        public String Password { get; set; }

        [Required]
        [Display(Name = "First name")]
        public String FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public String LastName { get; set; }
    }
}
