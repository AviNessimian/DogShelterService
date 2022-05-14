using Application.RegisterDog;
using DogShelterService.Api.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DogShelterService.Api.Dogs
{
    public class RegisterDogController : DogsControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Post(
            [FromServices] IRegisterDogInteractor interactor,
            [FromBody] RegisterDogRequest request,
            CancellationToken cancellationToken)
        {
            var createdDog = await interactor.Handle(request, cancellationToken);
            //var fullCreatedEntityUrl = Url.Action("Get", "GetDogsByCategory", new { createdDog.Id }, Request.Scheme);
            //return Created(fullCreatedEntityUrl, createdDog);
            return Ok();
        }
    }
}
