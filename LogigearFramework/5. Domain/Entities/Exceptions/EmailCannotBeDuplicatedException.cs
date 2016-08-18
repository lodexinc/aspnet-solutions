using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Domain.Entities.Exceptions
{
    public class EmailCannotBeDuplicatedException : Exception
    {
        private JobSeeker target;
        public EmailCannotBeDuplicatedException(JobSeeker target) 
            : base("EmailCannotBeDuplicatedException")
        {
            this.target = target;
        }        
    }
}
