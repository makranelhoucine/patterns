namespace Pattern.Domain.DogsAndHyenas
{
    using System.Collections.Generic;
    using System.Linq;

    using Command;

    using NullObject.Models;

    public sealed class GetDogsAndHyenas : Command<Dictionary<string, IReadOnlyList<Animal>>>
    {
        private readonly IDogsAndHyenasAdapter dogsAndHyenasAdapter;

        public GetDogsAndHyenas(IDogsAndHyenasAdapter dogsAndHyenasAdapter)
        {
            this.dogsAndHyenasAdapter = dogsAndHyenasAdapter;
        }

        protected override void OnExecute(Next<Dictionary<string, IReadOnlyList<Animal>>> next)
        {
            var animals = this.dogsAndHyenasAdapter.Get();

            var groupByTypeOfAnimal = animals.GroupBy(a => a.GetType());
            var result = groupByTypeOfAnimal.ToDictionary(
                g => g.Key.Name,
                g => g.ToList() as IReadOnlyList<Animal>);
            next(result);
        }
    }
}