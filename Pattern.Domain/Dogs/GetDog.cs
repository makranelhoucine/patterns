namespace Pattern.Domain.Dogs
{
    using Command;

    using NullObject.Models;

    public class GetDog : Command<int, Dog>
    {
        private readonly IDogAdapter dogAdapter;

        public GetDog(IDogAdapter dogAdapter)
        {
            this.dogAdapter = dogAdapter;
        }

        protected override void OnExecute(int input, Next<Dog> next)
        {
            var dogs = this.dogAdapter.Get(input);
            next(dogs);
        }
    }
}