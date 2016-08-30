using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scrum.Application.Commands
{
    public class CreateSprintCommand
    {
        public String ProjectID { get; set; }
        public String Name { get; set; }
        public String Goal { get; set; }
    }
}
