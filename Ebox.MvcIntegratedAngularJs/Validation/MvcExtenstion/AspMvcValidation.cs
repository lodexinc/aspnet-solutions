using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebox.MvcIntegratedAngularJs.Validation.MvcExtenstion
{
    public static class AspMvcValidation
    {
        public static ValidationErrorResponse ValidationJsonResponse(this Controller controller)
        {
            var errorList = new List<ValidationError>();
            controller.ModelState.Keys.ToList().ForEach(key =>
            {
                ModelState modelState = null;
                if (controller.ModelState.TryGetValue(key, out modelState))
                {
                    errorList.AddRange(modelState.Errors.ToList()
                    .Select(err => new ValidationError
                    {
                        Key = key,
                        Message = err.ErrorMessage
                    }));
                }
            });

            return new ValidationErrorResponse()
            {
                Type = "Validation",
                Errors = errorList
            };
        }
    }
}