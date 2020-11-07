using System;
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
            public void ReturnsNewValueBuiltFromSut()
            {
                var expected1 = new TestClass();
                var expected2 = new TestClass();
                ConfiguredCall arrange = fuzz.Build(sut).Returns(expected1, expected2);

                TestClass actual1 = sut;
                TestClass actual2 = sut;

                Assert.Same(expected1, actual1);
                Assert.Same(expected2, actual2);
            }
        }

        public class TestClass {}
    }
}
