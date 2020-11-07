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

        protected void ArrangeBuildOfFuzzyInt64() {
            ConfiguredCall arrange = fuzzy.Build(Arg.Any<FuzzyRange<long>>())
                .Returns(call => {
                    var initial = (long)random.Next();
                    FuzzyContext.Set(initial, (FuzzyRange<long>)call[0]);
                    return initial;
                });
        }
    }
}
