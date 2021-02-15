using System;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzTest
    {
        readonly IFuzz sut = Substitute.For<Fuzz>();

        public class Build: FuzzTest
        {
            readonly Fuzzy<TestClass> spec;

            public Build() => spec = Substitute.ForPartsOf<Fuzzy<TestClass>>(sut);

            [Fact]
            public void ReturnsValueBuiltBySpec() {
                var expected = new TestClass();
                ConfiguredCall arrange = spec.Build().Returns(expected);

                TestClass actual = sut.Build(spec);

                Assert.Same(expected, actual);
            }

            [Fact]
            public void StoresValueAndSpecInFuzzyContext() {
                var value = new TestClass();
                ConfiguredCall arrange = spec.Build().Returns(value);

                TestClass act = sut.Build(spec);

                Assert.Same(spec, FuzzyContext.Get<TestClass, Fuzzy<TestClass>>(value));
            }

            [Fact]
            public void ThrowsDescriptiveExceptionWhenSpecIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => sut.Build<TestClass>(null!));
                Assert.Equal("spec", thrown.ParamName);
            }
        }

        public class TestClass { }
    }
}
