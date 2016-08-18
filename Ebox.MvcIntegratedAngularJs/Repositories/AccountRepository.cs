using Ebox.MvcIntegratedAngularJs.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public User FindByEmail(string email)
        {
            return this.Users().Where(u => u.Email
            .Equals(email, StringComparison.CurrentCultureIgnoreCase))
            .SingleOrDefault();
        }

        public List<User> Users()
        {
            List<User> users = new List<User>();
            User user1 = new User
            {
                Email = "thanh.tran@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                FirsName = "Thanh",
                LastName = "Tran"
            };

            User user2 = new User
            {
                Email = "luong.mai@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                FirsName = "Luong",
                LastName = "Mai"
            };

            User user3 = new User
            {
                Email = "huy.ngo@gmail.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("123"),
                FirsName = "Huy",
                LastName = "Ngo"
            };

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            return users;

        }
    }
}