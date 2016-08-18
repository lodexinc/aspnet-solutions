using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiGear.Domain.Entities;
using LogiGear.Domain.Repositories;
using LogiGear.Domain.Entities.Exceptions;

namespace LogiGear.Domain.Services
{
    public class JobSeekerRegistrationService : IJobSeekerRegistrationService
    {
        private IJobSeekerRepository _jobSeekerRepository;

        public JobSeekerRegistrationService(IJobSeekerRepository jobSeekerRepository)
        {
            this._jobSeekerRepository = jobSeekerRepository;
        }

        public JobSeeker FindJobSeeker(string email)
        {
            JobSeeker jobSeeker = this._jobSeekerRepository.FindUniqueJobSeeker(email);

            if (jobSeeker == null)
            {
                // TODO: Handle use case which job seeker does NOT exist.
                jobSeeker = JobSeeker.NOT_EXIST;
            }

            return jobSeeker;
        }

        public JobSeeker Register(JobSeeker jobSeeker)
        {
            JobSeeker existed = this.FindJobSeeker(jobSeeker.Email);
            if(!existed.Equals(JobSeeker.NOT_EXIST))
            {
                throw new EmailCannotBeDuplicatedException(jobSeeker);
            }

            // Default is not active.
            jobSeeker.DeActive();

            return jobSeeker;
        }
    }
}
