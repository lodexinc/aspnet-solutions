using Ebox.MvcIntegratedAngularJs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountRepository _accountRepo;
        public AuthenticationService(IAccountRepository accountRepo)
        {
            this._accountRepo = accountRepo;
        }

        public bool Validate(String email, String password)
        {
            bool valid = false;
            var existedUser = this._accountRepo.FindByEmail(email);

            if(existedUser != null)
            {
                valid = BCrypt.Net.BCrypt.Verify(password, existedUser.PasswordHash);
            }

            return valid;
        }
    }
}