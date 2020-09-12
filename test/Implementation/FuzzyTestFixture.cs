using System;
using NSubstitute;

namespace Fuzzy.Implementation
{
    public abstract class FuzzyTestFixture
    {
        protected readonly Random random = new Random();
        protected readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        protected int EvenNumber() {
            int value = random.Next();
            return value % 2 == 0 ? value : value + 1;
        }

        protected int OddNumber() {
            int value = random.Next();
            return value % 2 == 1 ? value : value + 1;
        }
    }
}
