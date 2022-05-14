using FluentValidation;

namespace Application.RegisterDog
{
    public class RegisterDogRequest
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public void Validate()
        {
            var validationResult = new RegisterDogValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}