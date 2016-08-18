using LogiGear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Services
{
    public interface IJobSeekerRegistrationService
    {
        JobSeeker Register(JobSeeker jobSeeker);
        JobSeeker FindJobSeeker(String email);
    }
}
