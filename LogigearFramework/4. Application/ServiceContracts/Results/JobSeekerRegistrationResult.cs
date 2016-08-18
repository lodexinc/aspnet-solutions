using LogiGear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Application.ServiceContracts.Results
{
    public class JobSeekerRegistrationResult : ApplicationResult<JobSeeker>
    {
        public JobSeekerRegistrationResult(JobSeeker target) : base(target)
        {

        }
    }
}
