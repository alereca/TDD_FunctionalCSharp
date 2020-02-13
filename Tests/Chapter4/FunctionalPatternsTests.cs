using System.Collections.Generic;
using Functions.Chapter4;
using Xunit;

namespace Tests.Chapter4
{
    public class FunctionalPatternsTests
    {
        // 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
        // the signature in arrow notation.)
        // (ISet<T>, T => R) => ISet<T>
        [Fact]
        public void MapSetT()
        {
            //Given
            var set = new HashSet<string> { "x", "y" };
            //When
            var result = set.Map(x => $"{x}:set");
            //Then
            Assert.Equal(expected: new HashSet<string> { "x:set", "y:set" }, actual: result);
        }

        // (IDictionary<K, T>, T => R) => IDictionary<R>
        [Fact]
        public void MapDictionaryKT()
        {
            //Given
            var dict = new Dictionary<string, string> {{ "ale", "nacion" }, { "pedro", "obligado" }};
            //Act
            var result = dict.Map(e => $"{e}/sn");
            //Then
            Assert.Equal(
                new Dictionary<string, string> { { "ale", "nacion/sn" }, { "pedro", "obligado/sn" } },
                actual: result
            );
        }
    }
}