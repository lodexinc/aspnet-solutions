using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Validation
{
    public class ValidationError
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}