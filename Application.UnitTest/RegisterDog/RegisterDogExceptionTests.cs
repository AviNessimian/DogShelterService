using Application.Contracts;
using Application.Exceptions;
using Application.RegisterDog;
using Domain.Entities;
using FluentValidation;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.UnitTest
{
    public class RegisterDogExceptionTests
    {
        [Fact]
        public void RegisterDogInteractor_ValidateNameNotExists_ThrowsBusinessRuleException()
        {
            //arrange
            var name = "Roki";

            var cToken = CancellationToken.None;
            var breadDetailsContractMock = Mock.Of<IBreadDetailsContract>();
            var dogRepositoryMock = new Mock<IDogRepository>();

            dogRepositoryMock
                .Setup(m => m.GetByNameAsync(name, cToken))
                .Returns(Task.FromResult(new DogEntity { Name = name }));

            var interactor = new RegisterDogInteractor(
                breadDetailsContractMock,
                dogRepositoryMock.Object);

            var request = new RegisterDogRequest{ Name = name, Breed = "Pug" };

            //act
            Action act = () => interactor.Handle(request, cToken).GetAwaiter().GetResult();

            //assert
            var exception = Assert.Throws<BusinessRuleException>(act);

            //More detailed assertions.
            Assert.Equal($"Dog with the name {request.Name} alrady exists", exception.Message);

        }

        [Fact]
        public void RegisterDogInteractor_ValidateInput_ThrowsValidationException()
        {
            var cToken = CancellationToken.None;
            var breadDetailsContractMock = Mock.Of<IBreadDetailsContract>();
            var dogRepositoryMock = new Mock<IDogRepository>();

            var interactor = new RegisterDogInteractor(
                breadDetailsContractMock,
                dogRepositoryMock.Object);

            var request = new RegisterDogRequest { Name = "", Breed = "" };

            //act
            Action act = () => interactor.Handle(request, cToken).GetAwaiter().GetResult();

            //assert
            Assert.Throws<ValidationException>(act);
        }
    }
}