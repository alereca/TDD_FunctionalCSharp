using System;
using Xunit;
using static Functions.Chapter7.PartialApplicationAndCurrying;

namespace Tests.Chapter7
{
    public class PartialApplicationAndCurryingTests
    {
        // 1. Partial application with a binary arithmethic function:
        // Write a function `Remainder`, that calculates the remainder of 
        // integer division(and works for negative input values!). 
        [InlineData(5, 2, 1)]
        [InlineData(5, -2, 1)]
        [InlineData(9, 3, 0)]
        [InlineData(-15, 6, -3)]
        [InlineData(-15, -6, -3)]
        [Theory]
        public void Remainder_ShouldReturnTheModuleEvenForNegativeIntegers(int x, int y, int expected)
        {
            //Act
            var result = Remainder(x, y);
            //Assert
            Assert.Equal(expected, actual: result);
        }

        // Notice how the expected order of parameters is not the
        // one that is most likely to be required by partial application
        // (you are more likely to partially apply the divisor).
        // Write an `ApplyR` function, that gives the rightmost parameter to
        // a given binary function (try to write it without looking at the implementation for `Apply`).
        // Write the signature of `ApplyR` in arrow notation, both in curried and non-curried form
        // ApplyR: ((T1,T2) => R, T2) => T1 => R
        [Fact]
        public void ApplyR_OnBinaryFunction_ShouldReturnAPartiallyAppliedFunctionWithTheRightmostArgument()
        {
            //Arrange
            Func<int, int, double> exp = (x, y) => Math.Pow(x, y);
            //Act
            var sqr = exp.ApplyR(2);
            //Assert
            Assert.Equal(expected: 9, actual: sqr(3));
        }

        // Use `ApplyR` to create a function that returns the
        // remainder of dividing any number by 5. 
        [Theory]
        [InlineData(10, 0)]
        [InlineData(13, 3)]
        [InlineData(-26, -1)]
        public void ApplyR_OnRemainder_ShouldReturnAPartiallyAppliedFunctionThatReturnsTheRemainderOfAnyNumberDividedBy5(int x, int expected)
        {
            //Act
            var remainderOfAnIntDividedByFive = RemainderFuncFactoryMethod().ApplyR(5);
            //Assert
            Assert.Equal(expected, actual: remainderOfAnIntDividedByFive(x));
        }

        // Write an overload of `ApplyR` that gives the rightmost argument to a ternary function
        // ApplyR: ((T1,T2,T3) => R, T3) => (T1,T2) => R
        [Theory]
        [InlineData("Go for", "a beer", "Go for a beer Ricardo")]
        [InlineData("Call", "your wife", "Call your wife Ricardo")]
        public void ApplyR_OnTernaryFunction_ShouldReturnAPartiallyAppliedFunctionWithTheRightmostArgument(string s1, string s2, string expected)
        {
            //Arrange
            Func<string, string, string, string> composeString = (s1, s2, s3) => $"{s1} {s2} {s3}";
            //Act
            var simonSaysToRicardo = composeString.ApplyR("Ricardo");
            //Assert
            Assert.Equal(expected: expected, actual: simonSaysToRicardo(s1, s2));
        }
    }
}