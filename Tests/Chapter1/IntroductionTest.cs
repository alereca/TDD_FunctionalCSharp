using System;
using Xunit;
using static Functions.Introduction;
using System.Collections.Generic;

namespace Tests
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
            Assert.False(isAlwaysTrueNegated(1));
        }


        // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
        // rather than sorting it in place).
        [Fact]
        public void QuicksortShouldReturnSortedListAndNotMutateTest()
        {   //Arrange
            var originalList = new List<int> { 7, 1, 3, 2 };
            //Act
            var sortedList = Quicksort(originalList);
            //Assert,
            Assert.Equal(expected: new List<int> { 1, 2, 3, 7 }, actual: sortedList);
            Assert.Equal(expected: new List<int> { 7, 1, 3, 2 }, actual: originalList);
        }
    }
}
