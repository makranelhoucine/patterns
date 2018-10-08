namespace Pattern.AntiCorruptionLayer.Transforms
{
    using NullObject.Models;

    using Animal = Repository.Animal;

    internal sealed class AnimalToDogTransform : Tranform<Animal, Dog>
    {
        public override Dog From(Animal entity)
        {
            if (entity == null)
            {
                return Dog.Null;
            }

            return new Dog { Food = entity.Food, Legs = entity.Legs, Name = entity.Name };
        }
    }
}