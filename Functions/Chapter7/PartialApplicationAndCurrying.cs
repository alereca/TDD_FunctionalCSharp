using System;

namespace Functions.Chapter7
{
    public static class PartialApplicationAndCurrying
    {
        /// params:
        /// x: dividend
        /// y: divisor
        public static int Remainder(int x, int y) => x - ((x / y) * y);

        public static Func<int,int,int> RemainderFuncFactoryMethod() => Remainder;

        public static Func<T1,R> ApplyR<T1,T2,R>(this Func<T1,T2,R> func, T2 t2) 
            => t1 => func(t1, t2);
        
        public static Func<T1,T2,R> ApplyR<T1,T2,T3,R>(this Func<T1,T2,T3,R> func, T3 t3)
            => (t1, t2) => func(t1, t2, t3);

        public static PhoneNumber PhoneNumberFactoryMethod(CountryCode code, PhoneNumber.NumberType type, string number)
            => new PhoneNumber(code, number, type);

        public static Func<CountryCode, PhoneNumber.NumberType, string, PhoneNumber> PhoneNumberFuncFactoryMethod()
            => PhoneNumberFactoryMethod;
    }
}