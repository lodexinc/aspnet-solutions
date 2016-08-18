using LogiGear.Application.Commands;
using LogiGear.Application.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EBox.MvcApp.Controllers
{
    public class JobSeekerController : Controller
    {
        private IJobSeekerRegistrationAppService _jobSeekerRegistrationService;
        public JobSeekerController(IJobSeekerRegistrationAppService jobSeekerRegistrationService)
        {
            this._jobSeekerRegistrationService = jobSeekerRegistrationService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            RegisterJobSeekerCommand model = new RegisterJobSeekerCommand(String.Empty, String.Empty, String.Empty);
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterJobSeekerCommand model)
        {
            this._jobSeekerRegistrationService.RegisterJobSeeker(model);
            return View(model);
        }
    }
}