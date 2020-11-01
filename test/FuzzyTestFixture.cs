using System;
using NSubstitute;

namespace Fuzzy
{
    public abstract class FuzzyTestFixture
    {
        protected readonly Random random = new Random();
        protected readonly IFuzz fuzzy = Substitute.For<IFuzz>();
    }
}
