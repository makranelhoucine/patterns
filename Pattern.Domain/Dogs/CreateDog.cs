namespace Pattern.Domain.Dogs
{
    using System.Threading.Tasks;

    using Command;

    using Models;

    using NullObject.Models;

    public sealed class CreateDog : CommandAsync<NewDog, Dog>
    {
        private readonly IDogAdapter dogAdapter;

        private readonly INewDogValidator newDogValidator;

        public CreateDog(INewDogValidator newDogValidator, IDogAdapter dogAdapter)
        {
            this.newDogValidator = newDogValidator;
            this.dogAdapter = dogAdapter;
        }

        protected override bool OnCanExecute(NewDog input)
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

        protected override async Task OnExecuteAsync(NewDog input, Next<Dog> next)
        {
            var dog = await this.dogAdapter.Create(input);
            if (!dog.IsNull)
            {
                next(dog);
            }
        }
    }
}