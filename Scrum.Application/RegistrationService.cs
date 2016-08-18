using Scrum.Application.Commands;
using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepo;
        public RegistrationService(IUserRepository userRepo)
        {
            this._userRepo = userRepo;
        }
        public void Register(RegisterCommand registerCommand)
        {
            User user = new User
            {
                Email = registerCommand.Email,
                FirsName = registerCommand.FirstName,
                LastName = registerCommand.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerCommand.Password)
            };

            this._userRepo.Save(user);
        }
    }
}
