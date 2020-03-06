using System;
using Xunit;
using static LaYumba.Functional.F;
using Functions.Chapter8;
using Functions.Chapter6;

namespace Tests.Chapter8.Ex1_2
{
    public class ElevatedValuesInApplyAndQueryPatternTests
    {
        // Implement apply for either and exceptional  
        [Theory]
        [InlineData(2, 1, true)]
        [InlineData(666, 1, false)]
        [InlineData(2, 666, false)]
        public void ApplyForExceptionalTest(int x, int y, bool success)
        {
            //Arrange
            Func<int, LaYumba.Functional.Exceptional<int>> numOrDevil = (i) => i switch
            {
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
        public void QueryPatternForExceptionalTest(int x1, int y1, int z1, bool expected)
        {
            //Arrange
            Func<int, LaYumba.Functional.Exceptional<int>> numOrDevil = (i) => i switch
            {
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
        public void QueryPatternForEitherTest(string xStr, string yStr, string zStr, LaYumba.Functional.Either<string, int> expected)
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
    }
}

namespace Tests.Chapter8.Ex3
{
    using LaYumba.Functional;
    using static Math;

    public class ElevatedValuesInApplyAndQueryPatternTests
    {
        // Come up with a scenario in which various `Either`-returning operations are chained with `Bind`. 
        // (If you’re short of ideas, you can use the favorite-dish example from chapter 6.) 
        // Rewrite the code using a LINQ expression.
        [Theory]
        [ClassData(typeof(EitherReturningOperationsChainedByBindOrQueryPatternTestData))]
        public void EitherReturningOperationsChainedByBindTest(
            string nroStr, int divisor, int numBase, Either<string, int> expected
        )
        {
            //Arrange
            Func<int, int, Either<string, int>> div = (x, y) =>
                  y == 0 ?
                      (Either<string, int>)Left("Division by zero error")
                    : (Either<string, int>)Right(x / y);

            Func<int, int, Either<string, int>> log = (x, y) =>
            y <= 0 ?
                  (Either<string, int>)Left("Domain error in log function")
                : (Either<string, int>)Right((int)Log(x, y));
            //Act
            var result = Int.Parse(nroStr)
                .ToEither("Invalid input")
                .Bind(i => div(i, divisor))
                .Bind(i => log(i, numBase));
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }

        [Theory]
        [ClassData(typeof(EitherReturningOperationsChainedByBindOrQueryPatternTestData))]
        public void EitherReturningOperationsChainedByUsingQueryPatternTest(
            string nroStr, int divisor, int numBase, Either<string, int> expected
        )
        {
            //Arrange
            Func<int, int, Either<string, int>> div = (x, y) =>
                  y == 0 ?
                      (Either<string, int>)Left("Division by zero error")
                    : (Either<string, int>)Right(x / y);

            Func<int, int, Either<string, int>> log = (x, y) =>
            y <= 0 ?
                  (Either<string, int>)Left("Domain error in log function")
                : (Either<string, int>)Right((int)Log(x, y));
            //Act
            var result =
                from i in Int.Parse(nroStr).ToEither("Invalid input")
                from x in div(i, divisor)
                from j in log(x, numBase)
                select j;
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }
    }
}
