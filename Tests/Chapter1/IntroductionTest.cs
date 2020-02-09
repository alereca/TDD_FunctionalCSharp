using System;
using Xunit;
using static Functions.Introduction;
using System.Collections.Generic;

namespace Tests.Chapter1
{
    public class IntroductionTest
    {
        // 1. Write a function that negates a given predicate: whenvever the given predicate
        // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
        [Fact]
        public void NegatePositivePredicateShouldEvaluateToNegativeTest()
        {
            // Arrange
            Func<int, bool> isAlwaysTruePredicate = (num) => true;
            // Act
            var isAlwaysTrueNegated = isAlwaysTruePredicate.NegatePredicate();
            // Assert
            Assert.False(isAlwaysTrueNegated(0));
        }


        // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
        // rather than sorting it in place).
        [Fact]
        public void QuicksortShouldReturnSortedListAndNotMutateTest()
        {   //Arrange
            var originalList = new List<int> { 7, 1, 3, 2 };
            //Act
            var sortedList = Quicksort(originalList);
            //Assert
            Assert.Equal(expected: new List<int> { 1, 2, 3, 7 }, actual: sortedList);
            Assert.Equal(expected: new List<int> { 7, 1, 3, 2 }, actual: originalList);
        }

        // 3. Generalize your implementation to take a `List<T>`, and additionally a 
        // `Comparison<T>` delegate.
        [Fact]
        public void GenericQuicksortShouldReturnSortedIntListAndNotMutateTest()
        {   //Arrange
            var originalList = new List<int> { 7, 1, 3, 2 };
            //Act
            var sortedList = GenericQuicksort(originalList, (a, b) => a - b);
            //Assert
            Assert.Equal(expected: new List<int> { 1, 2, 3, 7 }, actual: sortedList);
            Assert.Equal(expected: new List<int> { 7, 1, 3, 2 }, actual: originalList);
        }

        [Fact]
        public void GenericQuicksortShouldReturnSortedStringListAndNotMutateTest()
        {   //Arrange
            var originalList = new List<string> { "sam", "alex", "karl", "junior" };
            //Act
            var sortedList = GenericQuicksort(originalList, (a, b) => a.CompareTo(b));
            //Assert
            Assert.Equal(expected: new List<string> { "alex", "junior", "karl", "sam" }, actual: sortedList);
            Assert.Equal(expected: new List<string> { "sam", "alex", "karl", "junior" }, actual: originalList);
        }

        // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
        // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
        // takes a `Func<IDisposable>` as first
        // parameter, instead of the `IDisposable`. (This can be used to fix warnings
        // given by some code analysis tools about instantiating an `IDisposable` and
        // not disposing it.)
        [Fact]
        public void UsingMethodShouldTakeAnFuncReturningIDisposableAsArgumentAndReturnTheGenericTypeIndicated()
        {   //Arrange
            var disposable = new Disposable();
            //Act
            var result = Using<Disposable, bool>(() => disposable, d => true);
            //Assert
            Assert.True(result);
        }
    }
}
