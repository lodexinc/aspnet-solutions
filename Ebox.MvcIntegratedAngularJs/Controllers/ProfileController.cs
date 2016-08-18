using Ebox.MvcIntegratedAngularJs.DatabaseModel;
using Ebox.MvcIntegratedAngularJs.Feature.UserProfile;
using Ebox.MvcIntegratedAngularJs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Ebox.MvcIntegratedAngularJs.Controllers
{
    public class ProfileController : Controller
    {
        private IAccountRepository _accountRepository;

        public ProfileController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        // GET: Profile
        public ActionResult EditProfile()
        {
            var email = ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email);
            User user = this._accountRepository.FindByEmail(email.Value);
            user.DateOfBirth = new DateTime(1985, 11, 16);

            return View(new EditProfileCommand
            { Email = user.Email, FirstName = user.FirsName, LastName = user.LastName, DateOfBirth = user.DateOfBirth });
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileCommand editProfileCommand)
        {
            User user = this._accountRepository.FindByEmail(editProfileCommand.Email);
            user.DateOfBirth = editProfileCommand.DateOfBirth;
            user.FirsName = editProfileCommand.FirstName;
            user.LastName = editProfileCommand.LastName;

            return View(editProfileCommand);
        }
    }
}