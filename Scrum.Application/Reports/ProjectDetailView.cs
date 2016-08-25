using Scrum.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application.Reports
{
    public class ProjectDetailView
    {
        public String ProjectID { get; set; }
        public String ProjectName { get; set; }
        public String ProjectKey { get; set; }
        public String ProjectDisplayName
        {
            get
            {
                return String.Join(" - ", this.ProjectName, this.ProjectKey);
            }
        }

        public int TotalIssues
        {
            get
            {
                return IssueStatistics.Sum(i => i.Numbers);
            }
        }
        public List<IssueStatistics> IssueStatistics { get; set; }
    }

    public class IssueStatistics
    {
        public IssueType Type { get; set; }
        public int Numbers { get; set; }
    }
}
