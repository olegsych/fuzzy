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
                FuzzyRange<byte> actual = fuzzy.Byte();
                Assert.IsType<FuzzyByte>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Char: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyChar() {
                FuzzyRange<char> actual = fuzzy.Char();
                Assert.IsType<FuzzyChar>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class DateTime: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyDateTime() {
                FuzzyRange<System.DateTime> actual = fuzzy.DateTime();
                Assert.IsType<FuzzyDateTime>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Element: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyElement() {
                Fuzzy<TestStruct> actual = fuzzy.Element(new[] { new TestStruct(default) });
                Assert.IsType<FuzzyElement<TestStruct>>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Enum: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyEnum() {
                Fuzzy<TestEnum> actual = fuzzy.Enum<TestEnum>();
                Assert.IsType<FuzzyEnum<TestEnum>>(actual);
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
                FuzzyRange<int> actual = fuzzy.Int32();
                Assert.IsType<FuzzyInt32>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Int64: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyInt64() {
                FuzzyRange<long> actual = fuzzy.Int64();
                Assert.IsType<FuzzyInt64>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class SByte: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzySByte() {
                FuzzyRange<sbyte> actual = fuzzy.SByte();
                Assert.IsType<FuzzySByte>(actual);
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
                FuzzyRange<System.TimeSpan> actual = fuzzy.TimeSpan();
                Assert.IsType<FuzzyTimeSpan>(actual);
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
                FuzzyRange<uint> actual = fuzzy.UInt32();
                Assert.IsType<FuzzyUInt32>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class UInt64: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyUInt64() {
                FuzzyRange<ulong> actual = fuzzy.UInt64();
                Assert.IsType<FuzzyUInt64>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }
    }
}
