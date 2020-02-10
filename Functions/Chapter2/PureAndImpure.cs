using System;
using static System.Math;

namespace Functions.Chapter2
{
    public class PureAndImpure
    {
        public enum BmiRange { Underweight, Healthy, Overweight }
        public static BmiRange CalculateBMI(double height, double weight)
        {
            double bmi = Round(weight / Pow(height, 2), 2);

            if (bmi < 18.5)
            {
                return BmiRange.Underweight;
            };
            if (bmi >= 25)
            {
                return BmiRange.Overweight;
            }
            return BmiRange.Healthy;
        }

        public static void ProcessBMI(Func<string, double> input, Action<BmiRange> output)
        {
            var height = input("height");
            var weight = input("weight");

            BmiRange result = CalculateBMI(height, weight);

            output(result);
        }
    }
}