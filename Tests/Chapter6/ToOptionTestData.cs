using System.Collections;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Tests.Chapter6
{
    public class ToOptionTestData : IEnumerable<object[]>
    {
        private List<object[]> _dta = new List<object[]>
        {
            new object[] {Right("sth"), Some("sth")},
            new object[] {Left("error"), None}
        };

        public IEnumerator<object[]> GetEnumerator() => _dta.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}