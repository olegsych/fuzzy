using System;
using NSubstitute;

namespace Fuzzy
{
    public abstract class TestFixture
    {
        protected readonly Random random = new Random();
        protected readonly IFuzz fuzzy = Substitute.For<IFuzz>();
    }
}
