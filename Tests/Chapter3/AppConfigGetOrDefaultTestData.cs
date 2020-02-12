using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using static LaYumba.Functional.F;

namespace Tests.Chapter3
{
    public class AppConfigGetOrDefaultTestData : IEnumerable<object[]>
    {
        private List<object[]> _data = new List<object[]>
        {
            new object[] {GetCollection(), "x", "default"},
            new object[] {GetCollection(), "token", Some("asx")}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static NameValueCollection GetCollection()
        {
            var source = new NameValueCollection();
            source.Set("token", "asx");

            return source;
        }
    }
}