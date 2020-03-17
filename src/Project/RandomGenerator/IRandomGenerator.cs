using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.RandomGenerator
{
    public interface IRandomGenerator
    {
        int Generate(int min, int max);
    }
}
