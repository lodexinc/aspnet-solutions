using LogiGear.Application.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogiGear.Application.Commands;
using LogiGear.Domain.Repositories;
using LogiGear.Domain.Entities;
using LogiGear.Domain.Services;
using LogiGear.Application.ServiceContracts.Results;

namespace LogiGear.Application.Services
{
    public class JobSeekerRegistrationAppService : IJobSeekerRegistrationAppService
    {
        private IJobSeekerRepository _jobSeekerRepository;
        private IJobSeekerRegistrationService _jobSeekerRegistrationService;

        public JobSeekerRegistrationAppService(IJobSeekerRepository jobSeekerRepository,
            IJobSeekerRegistrationService jobSeekerRegistrationService)
        {
            this._jobSeekerRepository = jobSeekerRepository;
            this._jobSeekerRegistrationService = jobSeekerRegistrationService;
        }

        public JobSeekerRegistrationResult RegisterJobSeeker(RegisterJobSeekerCommand command)
        {
            JobSeeker jobSeeker = new JobSeeker(command.Email, command.FirstName, command.LastName, false);
            JobSeekerRegistrationResult result = new JobSeekerRegistrationResult(jobSeeker);
            try
            {
                this._jobSeekerRegistrationService.Register(jobSeeker);
                this._jobSeekerRepository.Save(jobSeeker);
            } catch(Exception ex)
            {
                result.Error = ex;
            }

            return result;
        }
    }
}
