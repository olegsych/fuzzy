using System;
using System.Collections.Generic;
using Fuzzy.Implementation;
using Inspector;
using NSubstitute;
using Xunit;

namespace Fuzzy
{
    public class IFuzzExtensionsTest
    {
        // Common method parameters
        readonly IFuzz fuzzy = Substitute.ForPartsOf<Fuzz>();

        // Test fixture
        readonly Random random = new Random();

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
                FuzzyRange<System.DateTime> returned = fuzzy.DateTime();
                var actual = Assert.IsType<FuzzyDateTime>(returned);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }

            [Fact]
            public void ReturnsFuzzyDateTimeOfGivenKind() {
                var expected = (DateTimeKind)(random.Next() % ((int)DateTimeKind.Local + 1));

                FuzzyRange<System.DateTime> returned = fuzzy.DateTime(expected);

                var actual = Assert.IsType<FuzzyDateTime>(returned);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
                Assert.Equal(expected, actual.Field<DateTimeKind?>().Value);
            }
        }

        public class DateTimeOffset: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyDateTimeOffset() {
                FuzzyRange<System.DateTimeOffset> actual = fuzzy.DateTimeOffset();
                Assert.IsType<FuzzyDateTimeOffset>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Double: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyDouble() {
                Fuzzy<double> actual = fuzzy.Double();
                Assert.IsType<FuzzyDouble>(actual);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Element: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyElement() {
                var elements = new TestStruct[0];
                Fuzzy<TestStruct> actual = fuzzy.Element(elements);
                Assert.Equal(typeof(FuzzyElement<TestStruct>), actual.GetType());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
                Assert.Same(elements, actual.Field<IEnumerable<TestStruct>>().Value);
            }
        }

        public class Enum: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyEnum() {
                TestEnum value = fuzzy.Enum<TestEnum>();
                FuzzyEnum<TestEnum> actual = FuzzyContext.Get<TestEnum, FuzzyEnum<TestEnum>>(value);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }

        public class Index: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyIndex() {
                var elements = new TestStruct[0];
                Fuzzy<int> actual = fuzzy.Index(elements);
                Assert.Equal(typeof(FuzzyIndex<TestStruct>), actual.GetType());
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
                Assert.Same(elements, actual.Field<IEnumerable<TestStruct>>().Value);
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

        public class Single: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzySingle() {
                Fuzzy<float> actual = fuzzy.Single();
                Assert.IsType<FuzzySingle>(actual);
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

        public class Uri: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyUri() {
                Fuzzy<System.Uri> returned = fuzzy.Uri();
                var actual = Assert.IsType<FuzzyUri>(returned);
                Assert.Same(fuzzy, actual.Field<IFuzz>().Value);
            }
        }
    }
}
