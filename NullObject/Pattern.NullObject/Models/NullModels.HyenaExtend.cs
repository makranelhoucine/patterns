// <auto-generated/>
namespace Pattern.NullObject.Models
{
	public partial class Hyena : IValuable<NullHyena>
	{
		public static NullHyena Null { get; } = new NullHyena();

		public virtual bool IsNull => false;
	}
}