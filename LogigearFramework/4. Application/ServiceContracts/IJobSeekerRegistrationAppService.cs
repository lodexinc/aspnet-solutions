using LogiGear.Application.Commands;
using LogiGear.Application.ServiceContracts.Results;
using LogiGear.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Application.ServiceContracts
{
    public interface IJobSeekerRegistrationAppService
    {
        JobSeekerRegistrationResult RegisterJobSeeker(RegisterJobSeekerCommand command);
    }
}
