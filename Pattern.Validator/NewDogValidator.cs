namespace Pattern.Validator
{
    using Domain.Dogs;
    using Domain.Models;

    using FluentValidation;

    public sealed class NewDogValidator : AbstractValidator<NewDog>, INewDogValidator
    {
    }
}