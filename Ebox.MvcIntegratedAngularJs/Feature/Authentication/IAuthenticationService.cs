using Ebox.MvcIntegratedAngularJs.Feature.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.Authentication
{
    public interface IAuthenticationService
    {
        bool Validate(String email, String password);
    }
}