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

        public class Int16: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyInt16() {
                FuzzyRange<short> actual = fuzzy.Int16();
                Assert.IsType<FuzzyInt16>(actual);
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

        public class Int64: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyInt64() {
                var actual = Assert.IsType<FuzzyInt64>(fuzzy.Int64());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class SByte: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzySByte() {
                var actual = Assert.IsType<FuzzySByte>(fuzzy.SByte());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class String: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyString() {
                var actual = Assert.IsType<FuzzyString>(fuzzy.String());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class TimeSpan: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyTimeSpan() {
                var actual = Assert.IsType<FuzzyTimeSpan>(fuzzy.TimeSpan());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class UInt16: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyUInt16() {
                FuzzyRange<ushort> actual = fuzzy.UInt16();
                Assert.IsType<FuzzyUInt16>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class UInt32: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyUInt32() {
                var actual = Assert.IsType<FuzzyUInt32>(fuzzy.UInt32());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class UInt64: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyUInt64() {
                var actual = Assert.IsType<FuzzyUInt64>(fuzzy.UInt64());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }
    }
}
