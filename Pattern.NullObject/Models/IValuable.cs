namespace Pattern.NullObject.Models
{
    public interface IValuable<TNullable> where TNullable : IValuable<TNullable>, new()
    {
        bool IsNull { get; }
    }
}