﻿using System.Collections.Generic;

namespace Scrum.EntityFramework
{
    public interface IUserRepository
    {
        List<User> All();
        void Delete(User user);
        void Save(User user);
        void Update(User dirtyUser);
        User FindByEmail(string email);
    }
}