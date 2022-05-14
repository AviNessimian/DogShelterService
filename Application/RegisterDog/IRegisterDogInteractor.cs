
using Domain.Entities;

namespace Application.RegisterDog
{
    public interface IRegisterDogInteractor
    {
        Task<DogEntity> Handle(RegisterDogRequest request, CancellationToken cancellationToken);
    }
}