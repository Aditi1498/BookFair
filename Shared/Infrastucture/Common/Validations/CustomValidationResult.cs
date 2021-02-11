using System.Collections.Generic;

namespace Shared
{
    public class CustomValidationResult
    {
        public IList<CustomValidationFailure> Errors { get; private set; }

        public bool IsValid
        {
            get { return Errors == null || Errors.Count == 0; }
        }

        public CustomValidationResult(IList<CustomValidationFailure> failures)
        {
            Errors = failures;
        }

        public CustomValidationResult()
        {
            Errors = new List<CustomValidationFailure>();
        }
    }
}

