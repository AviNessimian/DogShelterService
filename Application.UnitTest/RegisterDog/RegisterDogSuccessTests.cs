using Application.Contracts;
using Application.RegisterDog;
using Domain.Entities;
using Domain.Enums;
using Moq;
using System.Threading;
using Xunit;

namespace Application.UnitTest
{
    public class RegisterDogSuccessTests
    {
        [Fact]
        public void Should_RegisterDog_When_New()
        {
            //arrange
            var cToken = CancellationToken.None;
            var dogRepositoryMock = new Mock<IDogRepository>();


            DogEntity nullDogEntity = null;
            dogRepositoryMock
                .Setup(m => m.GetByNameAsync(It.IsAny<string>(), cToken))
                .ReturnsAsync(nullDogEntity);

            var breadDetailsContractMock = new Mock<IBreadDetailsContract>();
            var breadDetails = new BreadDetails
            {
                Id = 1,
                AverageHeight = 54.2f,
                Temperaments = new[] { "" }
            };

            breadDetailsContractMock
                .Setup(m => m.GetAsync(It.IsAny<string>(), cToken))
                .ReturnsAsync(breadDetails);

            var interactor = new RegisterDogInteractor(
                breadDetailsContractMock.Object,
                dogRepositoryMock.Object);

            var request = new RegisterDogRequest { Name = "GoodName", Breed = "GoodBreed" };

            //act
            var response = interactor.Handle(request, cToken).GetAwaiter().GetResult();

            //assert
            Assert.Equal(breadDetails.Id, response.ExternalId);
            Assert.Equal(breadDetails.AverageHeight, response.AverageHeight);
            Assert.Equal(DogSizeTypes.Medium, response.Size);
        }
    }
}