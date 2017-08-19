using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;
using WebGrease.Css.Extensions;

namespace Web.Halpers
{
    public class ValidationErrorHalper
    {
        private const string ErrorMessage = "The request is invalid.";

        public ValidationErrorHalper(ModelStateDictionary modelState)
        {
            Message = ErrorMessage;
            SerializeModelState(modelState);
        }

        public string Message { get; private set; }

        public IList<ValidationError> Errors { get; private set; }

        private void SerializeModelState(ModelStateDictionary modelState)
        {
            Errors = new List<ValidationError>();

            foreach (var keyModelStatePair in modelState)
            {
                var key = keyModelStatePair.Key;

                var errors = keyModelStatePair.Value.Errors;

                if (errors != null && errors.Count > 0)
                {
                    var errorMessages = new StringBuilder();
                    errors.ForEach(error => errorMessages.AppendLine(error.ErrorMessage));
                    Errors.Add(new ValidationError(key, errorMessages.ToString()));
                }
            }
        }
    }

    public struct ValidationError
    {
        public string Field { get; set; }

        public string Message { get; set; }

        public ValidationError(string field, string message)
        {
            Field = field;
            Message = message;
        }
    }
}