using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern.Domain.DogsAndHyenas
{
    using NullObject.Models;

    public interface IDogsAndHyenasAdapter
    {
        IReadOnlyList<Animal> Get();
    }
}
