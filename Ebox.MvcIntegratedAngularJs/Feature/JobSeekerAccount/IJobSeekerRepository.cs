using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebox.MvcIntegratedAngularJs.Feature.JobSeekerAccount
{
    public interface IJobSeekerRepository
    {
        List<Resume> ResumesOfJobSeeker(String email);
    }
}
