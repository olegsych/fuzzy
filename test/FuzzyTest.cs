using System;
using System.Linq;
using System.Reflection;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class FuzzyTest
    {
        readonly Fuzzy<TestClass> sut;

        // Constructor parameters
        readonly IFuzz fuzz = Substitute.For<IFuzz>();

        public FuzzyTest() => sut = Substitute.ForPartsOf<Fuzzy<TestClass>>(fuzz);

        public class Constructor : FuzzyTest
        {
            [Fact]
            public void ThrowsDescriptiveExceptionWhenFuzzIsNullToFailFast()
            {
                var thrown = Assert.Throws<TargetInvocationException>(() => Substitute.ForPartsOf<Fuzzy<TestClass>>(default(IFuzz)));
                var actual = Assert.IsType<ArgumentNullException>(thrown.InnerException);
                Assert.Equal(sut.DeclaredBy<Fuzzy<TestClass>>().Constructor().Parameter<IFuzz>().Name, actual.ParamName);
            }

            [Fact]
            public void InitializesFuzzFieldWithGivenArgument() =>
                Assert.Same(fuzz, sut.Field<IFuzz>().Value);
        }

        public class ImplicitTypeConversionOperator : FuzzyTest
        {
            [Fact]
            public void ReturnsInstanceCreatedByFactory()
            {
                var expected = new TestClass();
                ConfiguredCall arrange = sut.New().Returns(expected);

                TestClass actual = sut;

                Assert.Same(expected, actual);
            }
        }

        public class TestClass {}
    }
}
