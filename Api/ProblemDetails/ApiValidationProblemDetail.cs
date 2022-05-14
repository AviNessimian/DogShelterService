using System.Collections.Generic;

namespace DogShelterService.Api.ProblemDetails
{
    public class ApiValidationProblemDetail
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public List<ValidationError> Errors { get; set; }

        public class ValidationError
        {
            public string PropertyName { get; set; }
            public string ErrorMessage { get; set; }
        }
    }
}
