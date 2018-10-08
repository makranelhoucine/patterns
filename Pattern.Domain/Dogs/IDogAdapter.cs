namespace Pattern.Domain.Dogs
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models;

    using NullObject.Models;

    public interface IDogAdapter
    {
        Task<Dog> Create(NewDog newDog);

        IReadOnlyList<Dog> Get();


        Dog Get(int id);

        Task<Dog> Update(Dog updatedDog);
    }
}