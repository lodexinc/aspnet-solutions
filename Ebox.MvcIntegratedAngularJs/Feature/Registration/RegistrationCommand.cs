using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.Registration
{
    public class RegistrationCommand
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