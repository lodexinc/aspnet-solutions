using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiGear.Application.ServiceContracts.Results
{
    public class ApplicationResult<T>
    {
        public ApplicationResult(T target)
        {
            this.Result = target;
        }

        public T Result { get; }

        public ApplicationStatus Status { get
            {
                if(this.Error != null)
                {
                    return ApplicationStatus.FAIL;
                }

                return ApplicationStatus.SUCCESS;
            }
        }

        public Exception Error { get; set; }
    }

    public enum ApplicationStatus
    {
        SUCCESS,
        FAIL
    }
}
