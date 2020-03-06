using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter8
{
    public static class ElevatedValuesInApplyAndQueryPattern
    {
        public static Exceptional<R> Apply<T, R>(this Exceptional<Func<T, R>> fExt, Exceptional<T> tExt)
        => fExt.Match(
                Exception: (e) => e,
                Success: (f) => tExt.Match(
                    Exception: (e) => e,
                    Success: (t) => Exceptional(f(t))
                )
            );

        public static Exceptional<Func<T2,R>> Apply<T1,T2,R>(this Exceptional<Func<T1,T2,R>> fExt, Exceptional<T1> tExt)
            => Apply(fExt.Map(f => f.Curry()), tExt);        

        public static Exceptional<R> Select<T,R>(this Exceptional<T> exceptional, Func<T,R> func)
            => exceptional.Map(func);
        
        public static Exceptional<R> SelectMany<T,R>(this Exceptional<T> exceptional, Func<T,Exceptional<R>> func)
            => exceptional.Bind(func);
        
        public static Exceptional<RR> SelectMany<T,R,RR>(this Exceptional<T> exceptional, Func<T,Exceptional<R>> bind, Func<T,R,RR> project)
            => exceptional.Match(
                Exception: (e) => e,
                Success: (t) => bind(t).Match(
                    Exception: (e) => e,
                    Success: (r) => Exceptional(project(t,r))
                )
            );
    }
}