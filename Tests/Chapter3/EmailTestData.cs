using System.Collections;
using System.Collections.Generic;
using Functions.Chapter3;
using static LaYumba.Functional.F;

namespace Tests.Chapter3
{
    public class EmailTestData : IEnumerable<object[]>
    {
        private List<object[]> _data = new List<object[]>
        {
            new object[] {"ale@test", None},
            new object[] {"aletest.com", None},
            new object[] {"ale@test.com", Some(new Email("ale@test.com"))}
        };
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}