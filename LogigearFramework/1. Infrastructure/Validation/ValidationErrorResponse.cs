using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure.Validation
{
    public class ValidationErrorResponse
    {
        public string Type { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }

        public ValidationErrorResponse()
        {
            Errors = new List<ValidationError>();
        }
    }
}