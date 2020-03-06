using System.Collections;
using System.Collections.Generic;
using static LaYumba.Functional.F;

namespace Tests.Chapter8
{
    public class QueryPatternForEitherTestData : IEnumerable<object[]>
    {
        private List<object[]> _dta = new List<object[]>
        {
            new object[] {"2","3","4", 9},
            new object[] {"2","3","tw",Left("Parse operation failed")},
            new object[] {"wqda","3","7",Left("Parse operation failed")}
        };
        
        public IEnumerator<object[]> GetEnumerator() => _dta.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}