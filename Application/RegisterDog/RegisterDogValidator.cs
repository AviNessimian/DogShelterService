using FluentValidation;

namespace Application.RegisterDog
{
    public class RegisterDogValidator : AbstractValidator<RegisterDogRequest>
    {
        public RegisterDogValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(x => x.Breed)
                .NotNull()
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(20);
        }
    }
}