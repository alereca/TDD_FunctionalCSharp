using System;
using Xunit;
using static LaYumba.Functional.F;
using static Functions.Chapter8.ElevatedValuesInApplyAndQueryPattern;

namespace Tests.Chapter8
{
    public class ElevatedValuesInApplyAndQueryPatternTests
    {
        // Implement apply for either and exceptional  
        [Fact]
        public void ApplyForExceptional()
        {
            //Arrange
            Func<int, int, int> difference = (x, y) => x - y;
            //Act
            var result = Exceptional(difference)
                .Apply(2)
                .Apply(1);

            //Assert
            Assert.Equal(expected: 1, actual: result);
        }


        // Implement the query pattern for `Either` and `Exceptional`. 
        // Try to write down the signatures for `Select` and `SelectMany` without looking at any examples. 
        // For the implementation, just follow the types—if it type checks, it’s probably right!
        [Fact]
        public void QueryPatternForExceptional()
        {
            //Act
            var result = 
                from x in Exceptional(2)
                from y in Exceptional(2)
                from z in Exceptional(2)
                select x*y*z;
            //Assert
            Assert.Equal(expected: 8, actual: result);
        }
    }
}
