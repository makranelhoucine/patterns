namespace Pattern.AntiCorruptionLayer.Transforms
{
    using NullObject.Models;

    using Specifications;

    using Animal = Repository.Animal;

    internal sealed class DogToAnimalTransform : Tranform<Dog, Animal>
    {
        public override Animal From(Dog entity)
        {
            return new Animal { FamilyId = DogsSpecification.FamilyId, Legs = entity.Legs, Name = entity.Name };
        }
    }
}