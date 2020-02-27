using System;

namespace Functions.Chapter7
{
    public class CountryCode
    {
        private string Value { get;}
        public CountryCode(string value)
        {
            Value = value;
        }

        public static implicit operator CountryCode(string value) => new CountryCode(value);
        public static implicit operator string(CountryCode code) => code.Value;

        public override string ToString() => this.Value;

        public override bool Equals(object obj)
        {
            return obj is CountryCode code &&
                   Value == code.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}