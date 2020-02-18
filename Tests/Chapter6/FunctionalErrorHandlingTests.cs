using Xunit;
using static LaYumba.Functional.F;
using Functions.Chapter6;
using LaYumba.Functional;

namespace Tests.Chapter6
{
    public class FunctionalErrorHandlingTests
    {
        // 1. Write a `ToOption` extension method to convert an `Either` into an
        // `Option`. Then write a `ToEither` method to convert an `Option` into an
        // `Either`, with a suitable parameter that can be invoked to obtain the
        // appropriate `Left` value, if the `Option` is `None`. (Tip: start by writing
        // the function signatures in arrow notation)
        // ToOption: (Either<L,R>) => Option<R>
        // ToEither: (Option<R>, L) => Either<L,R>
        [Theory]
        [ClassData(typeof(ToOptionTestData))]
        public void ToOption_ShouldConvertAnEitherToAnOptionDisposingItsLeftValue(Either<string,string> either, Option<string> expected)
        {
            //Act
            var opt = either.ToOption();
            //Assert
            Assert.Equal(expected: expected, actual: opt);
        }

        [Theory]
        [ClassData(typeof(ToEitherTestData))]
        public void ToEither_ShouldCovertAnOptionToAnEitherTakingSomeLeftValueArgument(Option<string> opt, Either<string,string> expected)
        {
            //Act
            var either = opt.ToEither("error");
            //Assert
            Assert.Equal(expected: expected, actual: either);
        }
    }
}