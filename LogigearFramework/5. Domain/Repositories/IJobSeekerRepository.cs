using LogiGear.Domain.Entities;
using LogiGear.Domain.Repositories.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Repositories
{
    public interface IJobSeekerRepository : IRepository<JobSeeker>
    {
        JobSeeker FindUniqueJobSeeker(String email);
    }
}
