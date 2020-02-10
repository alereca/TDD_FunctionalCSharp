using System;
using Xunit;
using static Functions.Chapter2.PureAndImpure;

namespace Tests.Chapter2
{
    public class PureAndImpureTests
    {
        // 1. Write a console app that calculates a user's Body-Mass Index:
        //   - prompt the user for her height in metres and weight in kg
        //   - calculate the BMI as weight/height^2
        //   - output a message: underweight(bmi<18.5), overweight(bmi>=25) or healthy weight
        // 3. Unit test the pure parts
        [Fact]
        public void CalculateBMI_ShouldReturnTheExpectedResult()
        {   //Arrange
            double height = 1.86;
            double weight = 85;
            //Act
            BmiRange result = CalculateBMI(height, weight);
            //Assert
            Assert.Equal(expected: BmiRange.Healthy, actual: result);
        }

        // 2. Structure your code so that structure it so that pure and impure parts are separate
        // 4. Unit test the impure parts using the HOF-based approach
        [Theory]
        [InlineData(1.86, 85, BmiRange.Healthy)]
        [InlineData(1.60, 95, BmiRange.Overweight)]
        [InlineData(2.04, 70, BmiRange.Underweight)]
        public void HOF_ProcessBMI_ShouldBeProvidedWithImpureFunctionsForIO(double height, double weight, BmiRange expected)
        {
            //Arrange
            BmiRange result = default;
            Func<string, double> input = (str) => str == "height" ? height : weight;
            Action<BmiRange> output = (str) => result = str;
            //Act
            ProcessBMI(input, output);
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }
    }
}