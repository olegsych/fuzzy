using System;
using NSubstitute;

namespace Fuzzy
{
    public abstract class TestFixture
    {
        protected static readonly Random random = new Random();
        protected readonly IFuzz fuzzy = Substitute.For<IFuzz>();
    }
}
