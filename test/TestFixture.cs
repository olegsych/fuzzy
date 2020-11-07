using System;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;

namespace Fuzzy
{
    public abstract class TestFixture
    {
        protected static readonly Random random = new Random();
        protected readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        protected void ArrangeBuildOfFuzzyInt64() => ArrangeBuildOfFuzzyRange(() => (long)random.Next());
        protected void ArrangeBuildOfFuzzyInt16() => ArrangeBuildOfFuzzyRange(() => (short)(random.Next() % short.MaxValue));
        protected void ArrangeBuildOfFuzzyUInt16() => ArrangeBuildOfFuzzyRange(() => (ushort)(random.Next() % ushort.MaxValue));

        void ArrangeBuildOfFuzzyRange<T>(Func<T> generate) where T: struct, IComparable<T> {
            ConfiguredCall arrange = fuzzy.Build(Arg.Any<FuzzyRange<T>>())
                .Returns(call => {
                    T initial = generate();
                    FuzzyContext.Set(initial, (FuzzyRange<T>)call[0]);
                    return initial;
                });
        }
    }
}
