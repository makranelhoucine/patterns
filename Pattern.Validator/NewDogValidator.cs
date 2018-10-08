namespace Pattern.Validator
{
    using Domain.Dogs;
    using Domain.Models;

    using FluentValidation;

    public class NewDogValidator : AbstractValidator<NewDog>, INewDogValidator
    {
    }
}