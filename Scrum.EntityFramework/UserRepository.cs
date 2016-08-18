using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.EntityFramework
{
    public class UserRepository : IUserRepository
    {
        private readonly ScrumDbContext _scrumDbContext = new ScrumDbContext();

        public List<User> AllUsers()
        {
            return this._scrumDbContext.Users.ToList();
        }

        public void Save(User user)
        {
            this._scrumDbContext.Set<User>().Add(user);
            this._scrumDbContext.SaveChanges();
        }

        public void Update(User dirtyUser)
        {
            this._scrumDbContext.Entry(dirtyUser).State = EntityState.Modified;
            this._scrumDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            this._scrumDbContext.Entry(user).State = EntityState.Deleted;
            this._scrumDbContext.SaveChanges();
        }

        public User FindByEmail(string email)
        {
            return this._scrumDbContext.Users.SingleOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
    }
}
