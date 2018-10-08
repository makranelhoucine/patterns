namespace Pattern.Repository
{
    using System.Data.Entity;
    using System.Xml.Schema;

    public partial interface IPatternContext
    {
        void SetState<TEntity>(TEntity entity, EntityState entityType)
            where TEntity : class;
    }

    public partial class PatternContext
    {
        public void SetState<TEntity>(TEntity entity, EntityState entityType)
            where TEntity : class
        {
            this.Entry(entity).State = entityType;
        }
    }
}