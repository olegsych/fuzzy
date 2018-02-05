using System;
using System.Linq;
using System.Reflection;
using Inspector;
using NSubstitute;
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
            readonly ConstructorInfo constructor = typeof(Fuzzy<TestClass>).Constructors().Single();

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNullToFailFast()
            {
                var thrown = Assert.Throws<ArgumentNullException>(() => new Fuzzy<TestClass>(null, factory));
                Assert.Equal(constructor.Parameter<IFuzz>().Name, thrown.ParamName);
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenFactoryIsNullToFailFast()
            {
                var thrown = Assert.Throws<ArgumentNullException>(() => new Fuzzy<TestClass>(fuzz, null));
                Assert.Equal(constructor.Parameter<Func<IFuzz, TestClass>>().Name, thrown.ParamName);
            }
        }

        class TestClass {}
    }
}
