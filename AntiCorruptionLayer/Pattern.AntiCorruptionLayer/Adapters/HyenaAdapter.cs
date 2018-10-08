namespace Pattern.AntiCorruptionLayer.Adapters
{
    using NullObject.Models;

    using Repository;

    using Specifications;

    using Transforms;

    using Animal = Repository.Animal;

    internal class HyenaAdapter : AnimalAdapter<Hyena>
    {
        public HyenaAdapter(IReader<Animal> animalReader,IWriter<Animal> animalWriter,AnimalToHyenaTransform animalTransform, HyenaSpecification specification)
            : base(animalReader, animalWriter, animalTransform, specification)
        {
        }
    }
}