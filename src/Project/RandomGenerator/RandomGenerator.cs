using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.RandomGenerator
{
    public class RandomGenerator : IRandomGenerator
    {
        public int Generate(int min=0, int max=100)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
