using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace Functions.Chapter6
{
    public static class FunctionalErrorHandling
    {
        public static Option<R> ToOption<L, R>(this Either<L, R> either)
            => either.Match((l) => None, (r) => Some(r));

        public static Either<L,R> ToEither<L,R>(this Option<R> opt, L left)
            => opt.Match<Either<L,R>>(() => Left(left), (r) => Right(r));
    }
}