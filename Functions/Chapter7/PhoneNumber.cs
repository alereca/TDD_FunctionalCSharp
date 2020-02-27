using System;
using System.Collections.Generic;

namespace Functions.Chapter7
{
    public class PhoneNumber
    {
        public PhoneNumber(CountryCode countryCode, string number, NumberType type)
        {
            CountryCode = countryCode;
            Number = number;
            Type = type;
        }

        public enum NumberType { Mobile, Home, Business }
        public NumberType Type { get; }
        public CountryCode CountryCode { get; }
        public string Number { get; }

        public override bool Equals(object obj)
        {
            return obj is PhoneNumber number &&
                   Type == number.Type &&
                   CountryCode.ToString() == number.CountryCode.ToString() &&
                   Number == number.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, CountryCode, Number);
        }
    }
}