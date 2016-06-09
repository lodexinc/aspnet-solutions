using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Me.Api.v1.Persistence.Repositories
{
    public class AuthRepository : IDisposable
    {
        protected AuthDbContextMySql _authDbContextMySql;
        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            this._authDbContextMySql = new AuthDbContextMySql();
            this._userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this._authDbContextMySql));
        }

        public async Task<IdentityResult> RegisterUser(RegisterAccountRequest registerAccountRequest)
        {
            IdentityUser account = new IdentityUser
            {
                UserName = registerAccountRequest.UserName,
                Email = registerAccountRequest.UserName
            };

            return await _userManager.CreateAsync(account, registerAccountRequest.Password);
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);
            return user;
        }

        public void Dispose()
        {
            _authDbContextMySql.Dispose();
            _userManager.Dispose();
        }
    }
}