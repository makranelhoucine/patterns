namespace Pattern.Validator
{
    using FluentValidation;

    using NullObject.Models;

    public sealed class QuadrupedValidator : AbstractValidator<Animal>
    {
        private const int FourLegs = 4;

        public QuadrupedValidator()
        {
            this.RuleFor(a => a.Legs).Must(this.HaveBeen4Legs);
        }

        protected bool HaveBeen4Legs(int legs)
        {
            return legs == FourLegs;
        }
    }
}