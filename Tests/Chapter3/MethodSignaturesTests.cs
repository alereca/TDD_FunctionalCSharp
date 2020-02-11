using LaYumba.Functional;
using static LaYumba.Functional.F;
using Xunit;
using static Functions.Chapter3.MethodSignatures;
using System.Collections.Generic;
using Functions.Chapter3;
using System.Collections;

namespace Tests.Chapter3
{
    public class MethodSignaturesTests
    {
        // 1 Write a generic function that takes a string and parses it as a value of an enum. It
        // should be usable as follows:
        // Enum.Parse<DayOfWeek>("Friday") // => Some(DayOfWeek.Friday)
        // Enum.Parse<DayOfWeek>("Freeday") // => None
        [Theory]
        [ClassData(typeof(DayOfWeekTestData))]
        public void DayOfWeekParse_ShouldReturnTheCorrentEnumValue(string day, Option<DayOfWeek> expectedDay)
        {
            //Act
            var dayResult = DayOfWeekParse(day);
            //Assert
            Assert.Equal(expected: expectedDay, actual: dayResult);
        }

        // 2 Write a Lookup function that will take an IEnumerable and a predicate, and
        // return the first element in the IEnumerable that matches the predicate, or None
        // if no matching element is found. Write its signature in arrow notation:

        // bool isOdd(int i) => i % 2 == 1;
        // new List<int>().Lookup(isOdd) // => None
        // new List<int> { 1 }.Lookup(isOdd) // => Some(1)
        // Arrow Notation = Lookup: (IEnumerable, T => bool) => T
        [Fact]
        public void Lookup_ShouldReturnSomeWhenThePredicateIsSatisfiedOrNoneWhenItsNot()
        {
            //Arrange
            bool predicate(int i) => i % 2 == 1;
            //Act
            var someResult = new List<int> { 3, 2, 1, 4 }.Lookup(predicate);
            var noneResult = new List<int> { }.Lookup(predicate);
            //Assert
            Assert.Equal(expected: Some(3), actual: someResult);
            Assert.Equal(expected: None, actual: noneResult);
        }
    }
}