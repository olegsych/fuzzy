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
            readonly Fuzzy<TestClass> fuzzy;

            public Build() => fuzzy = Substitute.ForPartsOf<Fuzzy<TestClass>>(sut);

            [Fact]
            public void MyTestMethod() {
                var expected = new TestClass();
                ConfiguredCall arrange = fuzzy.New().Returns(expected);

                TestClass actual = sut.Build(fuzzy);

                Assert.Same(expected, actual);
            }

        }

        public class TestClass { }
    }
}
