using Domain.Entities;
using Domain.Enums;

namespace Application.GetDogsByCategory
{
    public interface IGetDogsByCategoryInteractor
    {
        Task<IEnumerable<DogEntity>> GetBySize(DogSizeTypes category, CancellationToken cancellationToken);
        Task<IEnumerable<DogEntity>> GetByTemperament(string temperament, CancellationToken cancellationToken);
    }
}