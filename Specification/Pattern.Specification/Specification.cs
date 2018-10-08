namespace Pattern.Specification
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public abstract class Specification<TEntity>
    {
        public static readonly Specification<TEntity> All = new IdentitySpecification<TEntity>();

        private readonly List<Expression<Func<TEntity, object>>> includes =
            new List<Expression<Func<TEntity, object>>>();

        protected Specification()
        {
            this.AddRelation();
        }

        public IReadOnlyList<Expression<Func<TEntity, object>>> Includes => this.includes;

        public Specification<TEntity> And(Specification<TEntity> specification)
        {
            if (this == All)
            {
                return specification;
            }

            if (specification == All)
            {
                return this;
            }

            return new ConditionSpecification<TEntity>(this, specification, Expression.AndAlso);
        }

        public bool IsSatifyBy(TEntity entity)
        {
            var predicate = this.ToExpression().Compile();
            return predicate(entity);
        }

        public Specification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public Specification<TEntity> Or(Specification<TEntity> specification)
        {
            if (this == All || specification == All)
            {
                return All;
            }

            return new ConditionSpecification<TEntity>(this, specification, Expression.OrElse);
        }

        public abstract Expression<Func<TEntity, bool>> ToExpression();

        protected virtual void OnAddRelation(Action<Expression<Func<TEntity, object>>> addRelation)
        {
        }

        private void AddRelation()
        {
            this.OnAddRelation(this.includes.Add);
        }
    }
}