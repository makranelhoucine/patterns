// <auto-generated/>
namespace Pattern.NullObject.Models
{
	public partial class Dog : IValuable<NullDog>
	{
		public static NullDog Null { get; } = new NullDog();

		public virtual bool IsNull => false;
	}
}