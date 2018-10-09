namespace Pattern.AntiCorruptionLayer.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Repository;

    using Specification;

    internal sealed class HyenaSpecification : Specification<Animal>
    {
        public const int FamilyId = 2;

        public override Expression<Func<Animal, bool>> ToExpression() => animal => animal.FamilyId == FamilyId;

    }
}