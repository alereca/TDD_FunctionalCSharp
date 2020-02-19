using Xunit;
using static LaYumba.Functional.F;
using static Functions.Chapter3.MethodSignatures;
using Functions.Chapter6;
using LaYumba.Functional;
using System;
using System.Collections.Generic;

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
        public void ToOption_ShouldConvertAnEitherToAnOptionDisposingItsLeftValue(Either<string, string> either, Option<string> expected)
        {
            //Act
            var opt = either.ToOption();
            //Assert
            Assert.Equal(expected: expected, actual: opt);
        }

        [Theory]
        [ClassData(typeof(ToEitherTestData))]
        public void ToEither_ShouldCovertAnOptionToAnEitherTakingSomeLeftValueArgument(Option<string> opt, Either<string, string> expected)
        {
            //Act
            var either = opt.ToEither("error");
            //Assert
            Assert.Equal(expected: expected, actual: either);
        }

        // 2. Take a workflow where 2 or more functions that return an `Option`
        // are chained using `Bind`.

        // Then change the first one of the functions to return an `Either`.

        // This should cause compilation to fail. Since `Either` can be
        // converted into an `Option` as we have done in the previous exercise,
        // write extension overloads for `Bind`, so that
        // functions returning `Either` and `Option` can be chained with `Bind`,
        // yielding an `Option`.
        [Fact]
        public void OptionBind_ShouldBeChainableByFunctionsReturningEither()
        {
            // Note: type inference can't guess which type is the L in either<L,R>
            //Act
            var result =
            Some("ale")
            .Bind<string, string, string>(s => Right(s.Trim()))
            .Bind(s => Some(s.Length));

            //Assert
            Assert.Equal(expected: 3, actual: result);
        }

        [Fact]
        public void EitherBind_ShouldBeChainableByFunctionsReturningOption()
        {
            //Act
            var result =
            DayOfWeekParse("Friday")
            .ToEither("Day not valid")
            .Bind(d => Some(d.ToString()));

            //Assert
            Assert.Equal(expected: Some("Friday"), actual: result);
        }

        // 3. Write a function `Safely` of type ((() → R), (Exception → L)) → Either<L, R> that will
        // run the given function in a `try/catch`, returning an appropriately
        // populated `Either`.
        [Fact]
        public void Safely_ShouldReturnAnEitherPopulatedWithALeftValueIfAnExceptionOcurredOrARightValueOtherwise()
        {

            // Note: new List<int>()[4] will always throw System.ArgumentOutOfRangeException
            //Act
            var result = FunctionalErrorHandling.Safely(() => new List<int>()[4], e => "An exception ocurred");
            //Assert
            Assert.Equal(expected: Left("An exception ocurred"), actual: result);
        }

        // 4. Write a function `Try` of type (() → T) → Exceptional<T> that will
        // run the given function in a `try/catch`, returning an appropriately
        // populated `Exceptional`.
        [Fact]
        public void Try_ShouldReturnAnExceptionalPopulatedWithAnExceptionOrACorrectValueIfNoneOcurred()
        {
            // Note: new List<int>()[4] will always throw System.ArgumentOutOfRangeException
            //Act
            var result = FunctionalErrorHandling.Try(() => new List<int>()[4]);
            //Assert
            Assert.True(result.Exception);
        }
    }
}