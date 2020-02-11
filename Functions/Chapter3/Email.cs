using System;
using System.Text.RegularExpressions;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter3
{
    public class Email
    {
        private string Value { get; }
        // Smart Constructor (Checks some conditions before instanciating some(object) or none)
        public static Option<Email> Of(string email)
        {
            return IsValid(email) ? Some(new Email(email)) : None;
        }

        public Email(string value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException($"{value} is not a valid email");
            }

            Value = value;
        }

        private static bool IsValid(string email)
        {
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            return regex.Match(email).Success;
        }

        // Implicit Type Conversion
        public static implicit operator string(Email email) => email.Value;

        public override bool Equals(object obj)
        {
            return obj is Email email &&
                   this.Value == email.Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }
    }
}