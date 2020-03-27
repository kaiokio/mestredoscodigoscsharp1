using System;
using System.Collections.Generic;
using System.Text;

namespace Commom.Extensions
{
    public static class NumbersExtension
    {
        public static bool IsPar(this int number) => number % 2 == 0;

        public static double GetRandomNumber(this Random random, double minimum, double maximum)
        {
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
