namespace Pattern.AntiCorruptionLayer.Specifications
{
    using System;
    using System.Linq.Expressions;

    using Repository;

    using Specification;

    internal sealed class DogsSpecification : Specification<Animal>
    {
        public const int FamilyId = 1;

        public override Expression<Func<Animal, bool>> ToExpression() => animal => animal.FamilyId == FamilyId;

    }
}