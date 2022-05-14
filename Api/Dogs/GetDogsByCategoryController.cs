using Application.GetDogsByCategory;
using DogShelterService.Api.Bases;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace DogShelterService.Api.Dogs
{
    public class GetDogsByCategoryController : DogsControllerBase
    {
        private readonly IGetDogsByCategoryInteractor _interactor;

        public GetDogsByCategoryController(
            IGetDogsByCategoryInteractor interactor)
        {
            _interactor = interactor;
        }

        [HttpGet("Category/Size/{{size}}")]
        [ProducesResponseType(typeof(List<DogEntity>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(
            [FromQuery, Required] DogSizeTypes size,
            CancellationToken cancellationToken)
            => Ok(await _interactor.GetBySize(size, cancellationToken));


        [HttpGet("Category/Temperament/{{temperament}}")]
        [ProducesResponseType(typeof(List<DogEntity>), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(
            [FromQuery, Required] string temperament,
            CancellationToken cancellationToken)
            => Ok(await _interactor.GetByTemperament(temperament, cancellationToken));
    }
}
