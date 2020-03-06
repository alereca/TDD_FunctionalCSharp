using System.Collections;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Tests.Chapter8
{
    public class EitherReturningOperationsChainedByBindOrQueryPatternTestData : IEnumerable<object[]>
    {
        private List<object[]> _dta = new List<object[]>
        {
            new object[]{"4", 2, 2, Right(1)},
            new object[]{"4", 0, 0, Left("Division by zero error")},
            new object[]{"4", 4, 0, Left("Domain error in log function")},
            new object[]{"hgh", 4, 0, Left("Invalid input")}
        };

        public IEnumerator<object[]> GetEnumerator() => _dta.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}