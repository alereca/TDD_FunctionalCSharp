using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter8
{
    public static class ElevatedValuesInApplyAndQueryPattern
    {
        
        public static Exceptional<R> Apply<T, R>(this Exceptional<Func<T, R>> fExt, Exceptional<T> tExt)
        => fExt.Match<Exceptional<R>>(
                Exception: (e) => e,
                Success: (f) => tExt.Match<Exceptional<R>>(
                    Exception: (e) => e,
                    Success: (t) => f(t)
                )
            );

        public static Exceptional<Func<T2,R>> Apply<T1,T2,R>(this Exceptional<Func<T1,T2,R>> fExt, Exceptional<T1> tExt)
            => Apply(fExt.Map(f => f.Curry()), tExt);        
    }
}