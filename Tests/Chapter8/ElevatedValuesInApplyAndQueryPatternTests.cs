using System;
using Xunit;
using static LaYumba.Functional.F;
using Functions.Chapter8;
using Functions.Chapter6;

namespace Tests.Chapter8
{
    public class ElevatedValuesInApplyAndQueryPatternTests
    {
        // Implement apply for either and exceptional  
        [Theory]
        [InlineData(2, 1, true)]
        [InlineData(666, 1, false)]
        [InlineData(2, 666, false)]
        public void ApplyForExceptional(int x, int y, bool success)
        {
            //Arrange
            Func<int,LaYumba.Functional.Exceptional<int>> numOrDevil = (i) => i switch {
                666 => new Exception("The number of the devil"),
                _ => i
            };
            Func<int, int, int> difference = (x, y) => x - y;
            //Act
            var result = Exceptional(difference)
                .Apply(numOrDevil(x))
                .Apply(numOrDevil(y));

            //Assert
            Assert.Equal(expected: success, actual: result.Success);            
        }


        // Implement the query pattern for `Either` and `Exceptional`. 
        // Try to write down the signatures for `Select` and `SelectMany` without looking at any examples. 
        // For the implementation, just follow the types—if it type checks, it’s probably right!
        [Theory]
        [InlineData(2, 1, 1, true)]
        [InlineData(666, 1, 33, false)]
        [InlineData(2, 666, 17, false)]
        public void QueryPatternForExceptional(int x1, int y1, int z1, bool expected)
        {
            //Arrange
            Func<int,LaYumba.Functional.Exceptional<int>> numOrDevil = (i) => i switch {
                666 => new Exception("The number of the devil"),
                _ => i
            };
            //Act
            var result =
                from x in numOrDevil(x1)
                from y in numOrDevil(y1)
                from z in numOrDevil(z1)
                select x * y * z;
            //Assert
            Assert.Equal(expected: expected, actual: result.Success);
        }

        [Theory]
        [ClassData(typeof(QueryPatternForEitherTestData))]
        public void QueryPatternForEither(string xStr, string yStr, string zStr, LaYumba.Functional.Either<string, int> expected)
        {
            //Act
            var result =
                from x in LaYumba.Functional.Int.Parse(xStr).ToEither("Parse operation failed")
                from y in LaYumba.Functional.Int.Parse(yStr).ToEither("Parse operation failed")
                from z in LaYumba.Functional.Int.Parse(zStr).ToEither("Parse operation failed")
                select x + y + z;
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }

        /*
        // Come up with a scenario in which various `Either`-returning operations are chained with `Bind`. 
        // (If you’re short of ideas, you can use the favorite-dish example from chapter 6.) 
        // Rewrite the code using a LINQ expression.
        [Fact]
        public void EitherReturningOperationsChainedByBind()
        {
            var result = LaYumba.Functional.Int.Parse("4")
                .ToEither("Parse operation failed")
                .Bind(i => (LaYumba.Functional.Either<string, int>)Right(i * 2))
                .Bind(i => (LaYumba.Functional.Either<string, int>)Right(i - 2));

            Assert.Equal(expected: 6, actual: result);
        }
        */
    }
}
