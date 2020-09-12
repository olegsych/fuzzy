using Fuzzy.Implementation;
using Inspector;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class IFuzzExtensionsTest
    {
        // Common method parameters
        readonly IFuzz fuzzy = Substitute.For<IFuzz>();

        public class Boolean: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyBoolean() {
                var actual = Assert.IsType<FuzzyBoolean>(fuzzy.Boolean());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Byte: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyByte() {
                var actual = Assert.IsType<FuzzyByte>(fuzzy.Byte());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Char: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyChar() {
                var actual = Assert.IsType<FuzzyChar>(fuzzy.Char());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Int32: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyInt32() {
                var actual = Assert.IsType<FuzzyInt32>(fuzzy.Int32());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }
    }
}
