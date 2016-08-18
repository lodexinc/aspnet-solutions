using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Entities
{
    public class ResumeProfile
    {
        public String ReferenceNumber { get; set; }
        public String CareerLevel { get; set; }
        public String JobTitle { get; set; }
        public JobSeeker JobSeeker { get; private set; }        
    }
}
