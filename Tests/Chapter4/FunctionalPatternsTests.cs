using System.Collections.Generic;
using Functions.Chapter4;
using Xunit;
using static LaYumba.Functional.F;
using static Functions.Chapter4.FunctionalPatterns;
using System;

namespace Tests.Chapter4
{
    public class FunctionalPatternsTests
    {
        // 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
        // the signature in arrow notation.)
        // (ISet<T>, T => R) => ISet<T>
        [Fact]
        public void MapSetTTest()
        {
            //Arrange
            var set = new HashSet<string> { "x", "y" };
            //Act
            var result = set.Map(x => $"{x}:set");
            //Assert
            Assert.Equal(expected: new HashSet<string> { "x:set", "y:set" }, actual: result);
        }

        // (IDictionary<K, T>, T => R) => IDictionary<R>
        [Fact]
        public void MapDictionaryKTTest()
        {
            //Arrange
            var dict = new Dictionary<string, string> { { "ale", "nacion" }, { "pedro", "obligado" } };
            //Act
            var result = dict.Map(e => $"{e}/sn");
            //Assert
            Assert.Equal(
                new Dictionary<string, string> { { "ale", "nacion/sn" }, { "pedro", "obligado/sn" } },
                actual: result
            );
        }

        // 2 Implement Map for Option and IEnumerable in terms of Bind and Return.
        [Theory]
        [ClassData(typeof(MapOptionUsingBindTestData))]
        public void MapOptionUsingBindTest(LaYumba.Functional.Option<string> opt, LaYumba.Functional.Option<string> expected)
        {
            //Act
            var result = opt.Map(x => $"{x}/more");
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }

        [Fact]
        public void MapIEnumerableUsingBindTest()
        {
            //Arrange
            var list = new List<int> { 1, 2, 3 };
            //Act
            var result = list.Map(x => x * 2);
            //Assert
            Assert.Equal(expected: new List<int> { 2, 4, 6 }, actual: result);
        }

        // 3 Use Bind and an Option-returning Lookup function (such as the one we defined
        // in chapter 3) to implement GetWorkPermit, shown below. 
        // Then enrich the implementation so that `GetWorkPermit`
        // returns `None` if the work permit has expired.
        [Theory]
        [ClassData(typeof(GetWorkPermitTestData))]
        public void GetWorkPermit_ShouldReturnAWorkPermitOrNoneIfWasExpiredOrNoneWasAvailable(
            Dictionary<string, Employee> people, string employeeId, LaYumba.Functional.Option<WorkPermit> expected)
        {
            //Act
            var result = GetWorkPermit(people, employeeId);
            //Assert
            Assert.Equal(expected: expected, actual: result);
        }

        // 4 Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
        // employees who have left should be included).
        [Fact]
        public void AverageYearsWorkedAtTheCompany_ShouldOnlyCountEmployeesWhoLeft()
        {
            //Arrange
            var employees = new List<Employee> {
                new Employee("sam", None, DateTime.Now.AddYears(-2), DateTime.Now),
                new Employee("alex", None, DateTime.Now.AddYears(-5), None),
                new Employee("gem", None, DateTime.Now.AddYears(-1), DateTime.Now),               
            };
            //Act
            double result = AverageYearsWorkedAtTheCompany(employees);
            //Assert
            Assert.Equal(expected: 1.5, actual: result);
        }
    }
}