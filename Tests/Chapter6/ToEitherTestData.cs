using System.Collections;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Tests.Chapter6
{
    public class ToEitherTestData : IEnumerable<object[]>
    {
        private List<object[]> _dta = new List<object[]>
        {
            new object[] {Some("sth"), Right("sth")},
            new object[] {None, Left("error")}
        };

        public IEnumerator<object[]> GetEnumerator() => _dta.GetEnumerator();


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}