using System;
using Functions;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> ItsLengthIsGreaterThanThree = (str) => true;
            Console.WriteLine(Introduction.NegatePredicate(ItsLengthIsGreaterThanThree));
        }
    }
}
