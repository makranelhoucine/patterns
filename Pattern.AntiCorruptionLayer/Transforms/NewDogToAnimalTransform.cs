namespace Pattern.AntiCorruptionLayer.Transforms
{
    using Domain.Models;

    using Specifications;

    using Animal = Repository.Animal;

    internal sealed class NewDogToAnimalTransform : Tranform<NewDog, Animal>
    {
        public override Animal From(NewDog entity)
        {
            return new Animal { FamilyId = DogsSpecification.FamilyId, Legs = entity.Legs, Name = entity.Name };
        }
    }
}