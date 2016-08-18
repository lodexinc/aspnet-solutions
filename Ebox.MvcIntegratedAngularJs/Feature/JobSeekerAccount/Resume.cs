using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebox.MvcIntegratedAngularJs.Feature.JobSeekerAccount
{
    public class Resume
    {
        public Resume(String email)
        {
            this.JobSeekerEmail = email;
        }

        public String JobSeekerEmail { get; private set; }

        public String Summary { get; private set; }

        public void CreateSummary(String summary)
        {
            this.Summary = summary;
        }
    }
}