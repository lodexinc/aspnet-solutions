using Scrum.EntityFramework;
using System;

namespace Scrum.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _accountRepo;
        public AuthenticationService(IUserRepository accountRepo)
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