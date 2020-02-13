using System.Collections;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Tests.Chapter4
{
    public class MapOptionUsingBindTestData : IEnumerable<object[]>
    {
        private List<object[]> _data = new List<object[]>
        {
            new object[]{None, None},
            new object[]{Some("sth"), Some("sth/more")}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}