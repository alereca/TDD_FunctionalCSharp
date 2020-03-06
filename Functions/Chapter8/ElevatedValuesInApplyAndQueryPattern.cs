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

        public static Either<L,RR> Select<L,R,RR>(this Either<L,R> either, Func<R,RR> func)
            => either.Map(func);

        public static Either<L,RR> SelectMany<L,R,RR>(this Either<L,R> either, Func<R,Either<L,RR>> func)
            => either.Bind(func);

        public static Either<L,RRR> SelectMany<L,R,RR,RRR>(this Either<L,R> either, Func<R, Either<L,RR>> bind, Func<R,RR,RRR> project)  
            => either.Match(
                Left: (l) => l,
                Right: (r) => bind(r).Match(
                    Left: (l) => l,
                    Right: (rr) => (Either<L,RRR>) Right(project(r,rr))
                )
            );
    }
}