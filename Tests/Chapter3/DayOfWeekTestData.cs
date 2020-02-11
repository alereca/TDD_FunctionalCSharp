using System.Collections;
using System.Collections.Generic;
using static Functions.Chapter3.MethodSignatures;
using static LaYumba.Functional.F;

namespace Tests.Chapter3
{
    public class DayOfWeekTestData : IEnumerable<object[]>
    {
        private List<object[]> _data = new List<object[]>
        {
            new object[] {"Monday", Some(DayOfWeek.Monday)},
            new object[] {"Friday", Some(DayOfWeek.Friday)},
            new object[] {"Saturday", Some(DayOfWeek.Saturday)},
            new object[] {"Sunday", Some(DayOfWeek.Sunday)},
            new object[] {"Sundayeeee", None},
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}