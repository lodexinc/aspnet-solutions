using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.Authentication
{
    public class LoginCommand
    {
        [Required(ErrorMessage = "Please enter your email")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public bool RememberMe { get; set; }

    }
}