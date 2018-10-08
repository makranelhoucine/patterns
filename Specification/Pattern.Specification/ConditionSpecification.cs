namespace Pattern.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal sealed class ConditionSpecification<TEntity> : Specification<TEntity>
    {
        private readonly Specification<TEntity> left;

        private readonly Specification<TEntity> right;

        private readonly Func<Expression, Expression, Expression> conditionalFunc;

        public ConditionSpecification(Specification<TEntity> left, Specification<TEntity> right, Func<Expression, Expression, Expression> conditionalFunc)
        {
            this.left = left;
            this.right = right;
            this.conditionalFunc = conditionalFunc;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            var leftExpression = this.left.ToExpression();
            var rightExpression = this.right.ToExpression();

            var andExpression = this.conditionalFunc(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(andExpression, leftExpression.Parameters.Single());
        }
    }
}