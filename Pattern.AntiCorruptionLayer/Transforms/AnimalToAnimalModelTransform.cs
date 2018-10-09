namespace Pattern.AntiCorruptionLayer.Transforms
{
    using NullObject.Models;

    using Specifications;

    using Animal = Repository.Animal;

    internal sealed class AnimalToAnimalModelTransform : Tranform<Animal, NullObject.Models.Animal>
    {
        private readonly AnimalToDogTransform animalToDogTransform;

        private readonly AnimalToHyenaTransform animalToHyenaTransform;

        private readonly DogsSpecification dogsSpecification;

        private readonly HyenaSpecification hyenaSpecification;

        public AnimalToAnimalModelTransform(
            AnimalToDogTransform animalToDogTransform,
            AnimalToHyenaTransform animalToHyenaTransform,
            DogsSpecification dogsSpecification,
            HyenaSpecification hyenaSpecification)
        {
            this.animalToDogTransform = animalToDogTransform;
            this.animalToHyenaTransform = animalToHyenaTransform;
            this.dogsSpecification = dogsSpecification;
            this.hyenaSpecification = hyenaSpecification;
        }

        public override NullObject.Models.Animal From(Animal entity)
        {
            if (entity == null)
            {
                return Dog.Null;
            }

            if (this.dogsSpecification.IsSatifyBy(entity))
            {
                return this.animalToDogTransform.From(entity);
            }

            if (this.hyenaSpecification.IsSatifyBy(entity))
            {
                return this.animalToHyenaTransform.From(entity);
            }

            return Dog.Null;
        }
    }
}