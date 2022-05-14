using DogShelterService.Api.Filters;
using DogShelterService.Api.ProblemDetails;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogShelterService.Api.Bases
{
    [ApiController]
    [Route("api/Dogs")]
    [ApiExplorerSettings(GroupName = "Dogs")]
    [ApiExceptionFilter]
    [ProducesResponseType(typeof(BusinessRuleProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiValidationProblemDetail), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ApiNotFoundProblemDetail), StatusCodes.Status404NotFound)]
    public class DogsControllerBase : ControllerBase
    {
    }
}
