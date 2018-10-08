namespace Pattern.Domain.Dogs
{
    using System.Threading.Tasks;

    using Command;

    using Models;

    using NullObject.Models;

    public class UpdateDog : CommandAsync<Dog, Dog>
    {
        private readonly IDogAdapter dogAdapter;

        private readonly INewDogValidator newDogValidator;

        public UpdateDog(INewDogValidator newDogValidator, IDogAdapter dogAdapter)
        {
            this.newDogValidator = newDogValidator;
            this.dogAdapter = dogAdapter;
        }

        protected override bool OnCanExecute(Dog input)
        {
            var canExecute = base.OnCanExecute(input);
            if (!canExecute)
            {
                return false;
            }

            var validationResult = this.newDogValidator.Validate(input);
            var valid = validationResult.IsValid;
            return valid;
        }

        protected override async Task OnExecuteAsync(Dog input, Next<Dog> next)
        {
            var existingDog = this.dogAdapter.Get(input.Id);
            if (existingDog.IsNull)
            {
                next(existingDog);
            }

            var dog = await this.dogAdapter.Update(input);
            if (!dog.IsNull)
            {
                next(dog);
            }
        }
    }
}