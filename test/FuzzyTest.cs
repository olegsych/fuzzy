using NSubstitute;
using System;
using Xunit;

namespace Fuzzy
{
    public class FuzzyTest
    {
        readonly Fuzzy<TestClass> sut;

        // Constructor parameters
        readonly IFuzz fuzz = Substitute.For<IFuzz>();
        readonly Func<IFuzz, TestClass> factory = Substitute.For<Func<IFuzz, TestClass>>();

        public FuzzyTest() => sut = new Fuzzy<TestClass>(fuzz, factory);

        public class Constructor : FuzzyTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNullToFailFast()
            {
                Assert.Throws<ArgumentNullException>(() => new Fuzzy<TestClass>(null, factory));
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFactoryIsNullToFailFast()
            {
                Assert.Throws<ArgumentNullException>(() => new Fuzzy<TestClass>(fuzz, null));
            }
        }

        class TestClass {}
    }
}
