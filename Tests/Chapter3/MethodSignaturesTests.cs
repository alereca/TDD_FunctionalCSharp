using LaYumba.Functional;
using static LaYumba.Functional.F;
using Xunit;
using static Functions.Chapter3.MethodSignatures;

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
    }
}