namespace Pattern.Domain.Dogs
{
    using System.Collections.Generic;

    using Command;

    using NullObject.Models;

    public sealed class GetDogs : Command<IReadOnlyList<Dog>>
    {
        private readonly IDogAdapter dogAdapter;

        public GetDogs(IDogAdapter dogAdapter)
        {
            this.dogAdapter = dogAdapter;
        }

        protected override void OnExecute(Next<IReadOnlyList<Dog>> next)
        {
            var dogs = this.dogAdapter.Get();
            next(dogs);
        }
    }
}