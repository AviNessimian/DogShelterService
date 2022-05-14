using Domain.Entities;
using Domain.Enums;

namespace Application.Contracts
{
    public interface IDogRepository
    {
        Task AddAsync(DogEntity dogEntity, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<DogEntity>> GetBySizeAsync(DogSizeTypes size, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<DogEntity>> GetByTemperamentAsync(string temperament, CancellationToken cancellationToken = default(CancellationToken));
        Task<DogEntity> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}
