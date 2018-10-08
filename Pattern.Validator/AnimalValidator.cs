namespace Pattern.Validator
{
    using FluentValidation;

    using NullObject.Models;

    public class AnimalValidator : AbstractValidator<Animal>
    {
        public AnimalValidator()
        {
            this.RuleFor(a => a.Id).GreaterThan(0);
            this.RuleFor(a => a.Name).NotNull().Length(4, 50);
            this.RuleFor(a => a.Food).NotNull().Length(4, 50);
        }
    }
}