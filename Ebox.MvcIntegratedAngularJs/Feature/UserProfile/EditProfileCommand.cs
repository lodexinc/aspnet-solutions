using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.UserProfile
{
    public class EditProfileCommand
    {
        public String Email { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}