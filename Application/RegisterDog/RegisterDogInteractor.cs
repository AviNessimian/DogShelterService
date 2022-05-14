using Application.Contracts;
using Application.Exceptions;
using Domain.Entities;

namespace Application.RegisterDog
{
    public class RegisterDogInteractor : IRegisterDogInteractor
    {
        private readonly IBreadDetailsContract _breadDetailsContract;
        private readonly IDogRepository _dogRepository;

        public RegisterDogInteractor(
            IBreadDetailsContract breadDetailsContract,
            IDogRepository dogRepository)
        {
            _breadDetailsContract = breadDetailsContract;
            _dogRepository = dogRepository;
        }

        public async Task<DogEntity> Handle(RegisterDogRequest request, CancellationToken cancellationToken)
        {
            request.Validate();

            var dog = await _dogRepository.GetByNameAsync(request.Name);
            if (dog != null)
            {
                throw new BusinessRuleException($"Dog with the name {request.Name} alrady exists");
            }

            var breadDetails = await _breadDetailsContract.GetAsync(request.Breed, cancellationToken);
            _ = breadDetails ?? throw new NotFoundException($"The breed {request.Breed} not found!");

            var newDog = DogEntity.Factory.Create(
                request.Name,
                request.Breed,
                breadDetails.Id,
                breadDetails.AverageHeight,
                breadDetails.Temperaments);

            await _dogRepository.AddAsync(newDog, cancellationToken);
            return newDog;
        }
    }
}
