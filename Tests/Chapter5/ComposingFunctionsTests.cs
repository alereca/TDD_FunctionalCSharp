using System;
using Xunit;
using static Functions.Chapter5.ComposingFunctions;

namespace Tests.Chapter5
{
    public class ComposingFunctionsTests
    {
        // 3 Implement a general purpose Compose function that takes two unary functions
        // and returns the composition of the two.
        [Fact]
        public void Compose_ShouldReturnTheCompositionOfBothFunctions()
        {   //Arrange
            Func<int, string> numberToString = (i) => i.ToString();
            Func<string, bool> isTwoOrMoreDigitsLong = (str) => str.Length >= 2;
            //Act
            var composedFunction = isTwoOrMoreDigitsLong.Compose(numberToString);
            //Assert
            Assert.True(composedFunction(21));
            Assert.True(composedFunction(1245454545));
            Assert.False(composedFunction(2));
        }
    }
}