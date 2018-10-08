namespace Pattern.AntiCorruptionLayer.Transforms
{
    using System.Collections.Generic;
    using System.Linq;

    internal abstract class Tranform<TIn, TOut>
    {
        public abstract TOut From(TIn entity);

        public IReadOnlyList<TOut> From(IQueryable<TIn> queryable)
        {
            return queryable.AsEnumerable().Select(this.From).ToList();
        }

    }
}