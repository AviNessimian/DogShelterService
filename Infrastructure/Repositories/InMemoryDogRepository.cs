using Application.Contracts;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Concurrent;

namespace Infrastructure.Repositories
{
    public class InMemoryDogRepository : IDogRepository
    {
        private static ConcurrentBag<DogEntity> InMemoryCollection = new ConcurrentBag<DogEntity>();
        public Task AddAsync(DogEntity dogEntity, CancellationToken cancellationToken = default)
        {
            InMemoryCollection.Add(dogEntity);
            return Task.CompletedTask;
        }

        public Task<DogEntity> GetByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(InMemoryCollection.FirstOrDefault(x => x.Name == name));

        public Task<IEnumerable<DogEntity>> GetBySizeAsync(DogSizeTypes size, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(InMemoryCollection.Where(x => x.Size == size));

        public Task<IEnumerable<DogEntity>> GetByTemperamentAsync(string temperament, CancellationToken cancellationToken = default(CancellationToken))
            => Task.FromResult(InMemoryCollection.Where(x => x.Temperaments.Contains(temperament)));
    }
}
