using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application.Commands
{
    public class CreateIssueCommand
    {
        public String ProjectID { get; set; }
        public String IssueTypeID { get; set; }
        public String Summary { get; set; }
        public String ReporterID { get; set; }
        public String Description { get; set; }
        public String PriorityID { get; set; }
        public String Attachment { get; set; }
        public String AssigneeID { get; set; }
        public String SprintID { get; set; }
    }
}
