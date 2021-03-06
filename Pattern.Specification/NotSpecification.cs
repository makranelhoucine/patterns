﻿namespace Pattern.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal sealed class NotSpecification<TEntity> : Specification<TEntity>
    {
        private readonly Specification<TEntity> specification;

        public NotSpecification(Specification<TEntity> specification)
        {
            this.specification = specification;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            var expression = this.specification.ToExpression();
            var notExpression = Expression.Not(expression.Body);

            return Expression.Lambda<Func<TEntity, bool>>(notExpression, expression.Parameters.Single());
        }
    }
}