namespace Pattern.Validator
{
    using Domain.Dogs;

    using FluentValidation;

    using NullObject.Models;

    public sealed class DogValidator : AbstractValidator<Dog>, IDogValidator
    {
        public DogValidator()
        {
            this.Include(new AnimalValidator());
            this.Include(new QuadrupedValidator());
        }
    }
}