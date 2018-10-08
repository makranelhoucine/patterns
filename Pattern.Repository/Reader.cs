namespace Pattern.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Specification;

    public interface IReader<TEntity>
        where TEntity : class
    {
        TResult Get<TResult, TPredicateResult>(
            Func<IQueryable<TEntity>, Expression<Func<TEntity, TPredicateResult>>, TResult> func,
            Expression<Func<TEntity, TPredicateResult>> predicate,
            Specification<TEntity> specification = null);

        IQueryable<TEntity> Get(Specification<TEntity> specification = null);
    }

    internal class Reader<TEntity> : IReader<TEntity>
        where TEntity : class
    {
        private readonly DbSet<TEntity> table;

        public Reader(IPatternContext context)
        {
            this.table = context.Set<TEntity>();
        }

        public TResult Get<TResult, TPredicateResult>(
            Func<IQueryable<TEntity>, Expression<Func<TEntity, TPredicateResult>>, TResult> func,
            Expression<Func<TEntity, TPredicateResult>> predicate,
            Specification<TEntity> specification = null)
        {
            var query = this.Get(specification);
            return func(query.AsNoTracking(), predicate);
        }

        public IQueryable<TEntity> Get(Specification<TEntity> specification = null)
        {
            IQueryable<TEntity> query = this.table;
            var entitySpecification = specification ?? Specification<TEntity>.All;
            query = entitySpecification.Includes.Aggregate(query, (current, include) => current.Include(include));
            query = query.Where(entitySpecification.ToExpression());
            return query.AsNoTracking();
        }
    }
}