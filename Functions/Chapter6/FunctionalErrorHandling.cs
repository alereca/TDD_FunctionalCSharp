using System;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter6
{
    public static class FunctionalErrorHandling
    {
        public static Option<R> ToOption<L, R>(this Either<L, R> either)
            => either.Match((l) => None, (r) => Some(r));

        public static Either<L, R> ToEither<L, R>(this Option<R> opt, L left)
            => opt.Match<Either<L, R>>(() => Left(left), (r) => Right(r));

        public static Option<R> Bind<T, L, R>(this Option<T> opt, Func<T, Either<L, R>> f)
            => opt.Match(
                () => None,
                (t) => f(t).ToOption());

        public static Option<RR> Bind<L, R, RR>(this Either<L, R> either, Func<R, Option<RR>> f)
            => either.Match(
                (l) => None,
                (r) => f(r));

        public static Either<L, R> Safely<L, R>(Func<R> f, Func<Exception, L> l)
        {
            try
            {
                return Right(f());
            }
            catch (Exception ex)
            {
                return Left(l(ex));
            }
        }

        public static Exceptional<T> Try<T>(Func<T> f)
        {
            try
            {
                return f();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}