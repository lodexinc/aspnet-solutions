using Ebox.MvcIntegratedAngularJs.Feature.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebox.MvcIntegratedAngularJs.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationCommand command)
        {
            System.Threading.Thread.Sleep(5000);
            return View();
        }
    }
}