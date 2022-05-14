using Application.Contracts;
using Domain.Entities;
using Domain.Enums;

namespace Application.GetDogsByCategory
{
    public class GetDogsByCategoryInteractor : IGetDogsByCategoryInteractor
    {
        private readonly IDogRepository _dogRepository;

        public GetDogsByCategoryInteractor(
            IDogRepository dogRepository)
        {
            _dogRepository = dogRepository;
        }

        public async Task<IEnumerable<DogEntity>> GetBySize(DogSizeTypes category, CancellationToken cancellationToken)
        {
            //input validation
            return await _dogRepository.GetBySizeAsync(category, cancellationToken);
        }

        public async Task<IEnumerable<DogEntity>> GetByTemperament(string temperament, CancellationToken cancellationToken)
        {
            //input validation
            return await _dogRepository.GetByTemperamentAsync(temperament, cancellationToken);
        }
    }
}