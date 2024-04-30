using System;
using System.Linq;

namespace Computation
{
    public class Calculator
    {
        public int SumNumbers(int start, int count)
        {
            // TODO #1: Get all tests passing
            /* int res = 0;
            for (int i = start; i < count + start; i++)
            {
                res += i;
            } */


            // TODO #2: Refactor so there are no loopss or if statements
            // int res = Enumerable.Range(start, count).Sum();

            // TODO #3: Refactor to use the Aggregate() LINQ method

            int res = Enumerable.Range(start, count).DefaultIfEmpty(0).Aggregate((a, b) => a + b);

            return res;
        }

    }
}
