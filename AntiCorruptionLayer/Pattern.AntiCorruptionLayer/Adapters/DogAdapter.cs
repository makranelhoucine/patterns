namespace Pattern.AntiCorruptionLayer.Adapters
{
    using System.Threading.Tasks;

    using Domain.Dogs;
    using Domain.Models;

    using NullObject.Models;

    using Repository;

    using Specifications;

    using Transforms;

    using Animal = Repository.Animal;

    internal class DogAdapter : AnimalAdapter<Dog>, IDogAdapter
    {
        private readonly DogToAnimalTransform dogToAnimalTransform;

        private readonly NewDogToAnimalTransform newDogToAnimalTransform;

        public DogAdapter(
            IReader<Animal> animalReader,
            IWriter<Animal> animalWriter,
            AnimalToDogTransform animalTransform,
            DogsSpecification dogsSpecification,
            NewDogToAnimalTransform newDogToAnimalTransform,
            DogToAnimalTransform dogToAnimalTransform)
            : base(animalReader, animalWriter, animalTransform, dogsSpecification)
        {
            this.newDogToAnimalTransform = newDogToAnimalTransform;
            this.dogToAnimalTransform = dogToAnimalTransform;
        }

        public async Task<Dog> Create(NewDog newDog)
        {
            var dog = this.newDogToAnimalTransform.From(newDog);
            this.animalWriter.Create(dog);
            await this.animalWriter.SaveAsync();

            return this.animalTransform.From(dog);
        }

        public async Task<Dog> Update(Dog updatedDog)
        {
            var dog = this.dogToAnimalTransform.From(updatedDog);
            this.animalWriter.Update(dog);
            await this.animalWriter.SaveAsync();

            return this.animalTransform.From(dog);
        }
    }
}