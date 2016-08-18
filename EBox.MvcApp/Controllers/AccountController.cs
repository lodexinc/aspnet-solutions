using EBox.MvcApp.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Net.Mail;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System.Net;

namespace EBox.MvcApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;
        private readonly object AppUserState;
        private const string XsrfKey = "XsrfId";

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public AccountController() { }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
            private set { _signInManager = value; }
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var jResult = new { success = true, IdentityMessage = "Login Failed. Please try again" };
            
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            switch (result)
            {
                case SignInStatus.Success:
                    //check user confirmed email or not
                    var user = await UserManager.FindByNameAsync(model.Email);
                    //var emailConfirmed = await UserManager.IsEmailConfirmedAsync(user.Id);
                    if (user.EmailConfirmed)
                    {
                        jResult = new { success = true, IdentityMessage = "" };
                    }
                    else
                    {
                        jResult = new { success = true, IdentityMessage = "Your account has not been active." };
                    }
                    break;
                default:
                    jResult = new { success = true, IdentityMessage = "Your account is invalid." };
                    break;
            }
            return Json(jResult);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PasswordHash =  model.Password };
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded) {
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                var callbackUrl = "http://localhost:18069/Account/Verify?t=" + user.Id + "&c=" + HttpUtility.UrlEncode(code);
                //  var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Context.Request.Scheme);

                //await _mailService.SendEmailAsync(user.Id, "Confirm your account",
                //     "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>");
                var bodyMail = "Please confirm your account by clicking this link: <a href=\"" + callbackUrl + "\">link</a>";

                await UserManager.EmailService.SendAsync(new IdentityMessage() {
                    Body = bodyMail,
                    Destination =user.Email,
                    Subject = "Confirm your account"
                });


                return Json(new { email = user.Email, success = true });
            }
            else {
                return null;
            }
           
        }

        [AllowAnonymous]
        public ActionResult RequireActiveEmail(string email)
        {

            ViewBag.Email = email;
            return View("RequireActiveEmail");
        }


        [AllowAnonymous]
        public async Task<ActionResult> Verify(string t, string c)
        {
            if (User.Identity.IsAuthenticated)
            {
                Logout();
                return RedirectToAction("Index", "Home");
            }

            if (t == null || c == null)
            {
                return View("Error");
            }

            var user = UserManager.FindById(t);

            if (user == null)
            {
                return View("Error");
            }

            //if (user.EmailConfirmed)
            //{
            //    return View("AlreadyConfirmed");
            //}

            var result = await UserManager.ConfirmEmailAsync(t, c);
            if (result.Succeeded)
            {
                user.EmailConfirmed = true;
                UserManager.Update(user);

                ViewBag.Id = t;
                return View("ConfirmEmail");
            }

            //AddErrors(result);

            return View("Error");
        }

        [Authorize]
        public bool Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return true;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> ResetPassword(string email)
        {
            var result = SignInStatus.Success;
            switch (result)
            {
                case SignInStatus.Success:
                    return true;
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return false;
            }
        }
        #region External Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult ExternalLinkLogin(string provider)
        {
            // Request a redirect to the external login provider
            var external = new ChallengeResult(provider, "/login-external");
            return external;
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return View("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
                var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        return View("~/Views/Home/Contact.cshtml");
                    case SignInStatus.LockedOut:
                        int i = 0;
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                    //return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                    case SignInStatus.Failure:
                    default:
                        // If the user does not have an account, then prompt the user to create an account
                        ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                        return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
                }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model)
        {
            var rs = false;

            if (User.Identity.IsAuthenticated)
            {
                rs = true;
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    rs = false;
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        rs = true;
                    }
                }
            }

            return rs;
        }

        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }

            IdentityResult result = await UserManager.ConfirmEmailAsync(userId, code);
            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }
            else
            {
                AddErrors(result);
                return View();
            }
        }
        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}
