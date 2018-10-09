namespace Pattern.AntiCorruptionLayer.Adapters
{
    using Domain.DogsAndHyenas;

    using Repository;

    using Specifications;

    using Transforms;

    using Animal = NullObject.Models.Animal;

    internal class DogsAndHyenasAdapter : AnimalAdapter<Animal>, IDogsAndHyenasAdapter
    {
        public DogsAndHyenasAdapter(
            IReader<Repository.Animal> animalReader,
            IWriter<Repository.Animal> animalWriter,
            AnimalToAnimalModelTransform animalModelTransform,
            DogsSpecification dogSpecification,
            HyenaSpecification hyenaSpecification)
            : base(animalReader, animalWriter, animalModelTransform, dogSpecification.Or(hyenaSpecification))
        {
        }
    }
}