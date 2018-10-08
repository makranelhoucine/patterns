namespace Pattern.AntiCorruptionLayer.Adapters
{
    using System.Collections.Generic;
    using System.Linq;

    using Repository;

    using Specification;

    using Transforms;

    internal abstract class AnimalAdapter<TAnimal>
    {
        protected readonly Tranform<Animal, TAnimal> animalTransform;

        protected readonly IWriter<Animal> animalWriter;

        private readonly IReader<Animal> animalReader;

        private readonly Specification<Animal> animalsSpecification;

        protected AnimalAdapter(
            IReader<Animal> animalReader,
            IWriter<Animal> animalWriter,
            Tranform<Animal, TAnimal> animalTransform,
            Specification<Animal> animalsSpecification)
        {
            this.animalReader = animalReader;
            this.animalWriter = animalWriter;
            this.animalTransform = animalTransform;
            this.animalsSpecification = animalsSpecification;
        }

        public IReadOnlyList<TAnimal> Get()
        {
            var animals = this.animalReader.Get(this.animalsSpecification);
            return this.animalTransform.From(animals);
        }

        public TAnimal Get(int id)
        {
            var animal = this.animalReader.Get(Queryable.SingleOrDefault, a => a.Id == id, this.animalsSpecification);
            return this.animalTransform.From(animal);
        }
    }
}