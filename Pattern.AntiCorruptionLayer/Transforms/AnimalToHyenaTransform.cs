namespace Pattern.AntiCorruptionLayer.Transforms
{
    using NullObject.Models;

    using Animal = Repository.Animal;

    internal sealed class AnimalToHyenaTransform : Tranform<Animal, Hyena>
    {
        public override Hyena From(Animal entity)
        {
            if (entity == null)
            {
                return Hyena.Null;
            }

            return new Hyena { Food = entity.Food, Legs = entity.Legs, Name = entity.Name };
        }
    }
}