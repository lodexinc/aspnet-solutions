using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application.Responses
{
    public class CreateIssueResponse
    {
        public String IssueKey { get; set; }
        public String ProjectID { get; set; }
    }
}
