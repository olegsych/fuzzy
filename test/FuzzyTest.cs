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

        // Test fixture
        readonly Random random = new Random();

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
            public void ReturnsVaueBuiltFromSutOnce()
            {
                var expected = new TestClass();
                ConfiguredCall arrange = fuzz.Build(sut).Returns(expected, new TestClass());

                TestClass actual1 = sut;
                TestClass actual2 = sut;

                Assert.Same(expected, actual1);
                Assert.Same(expected, actual2);
            }
        }

        public new class ToString: FuzzyTest
        {
            [Fact]
            public void BuildsFuzzyValueOnceAndReturnsItsToStringResult() {
                int expected = random.Next();
                var actual = Substitute.ForPartsOf<Fuzzy<int>>(fuzz);
                ConfiguredCall arrange = fuzz.Build(actual).Returns(expected, random.Next());
                Assert.Equal(expected.ToString(), actual.ToString());
                Assert.Equal(expected.ToString(), actual.ToString());
            }
        }

        public class Value: FuzzyTest
        {
            [Fact]
            public void ReturnsVaueBuiltFromSutOnce() {
                var expected = new TestClass();
                ConfiguredCall arrange = fuzz.Build(sut).Returns(expected, new TestClass());

                Assert.Same(expected, sut.Value);
                Assert.Same(expected, sut.Value);
            }
        }

        public class TestClass {}
    }
}
