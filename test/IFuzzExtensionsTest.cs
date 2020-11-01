using System;
using System.Collections.Generic;
using Fuzzy.Implementation;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class IFuzzExtensionsTest: TestFixture
    {
        public class Boolean: IFuzzExtensionsTest
        {
            [Theory, InlineData(true), InlineData(false)]
            public void ReturnsValueBuiltByFuzzyBoolean(bool expectedValue) {
                FuzzyBoolean actualSpec = null;
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyBoolean>(spec => actualSpec = spec)).Returns(expectedValue);

                bool actualValue = fuzzy.Boolean();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyChar() {
                FuzzyChar actualSpec = null;
                var expectedValue = (char)(random.Next() % char.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyChar>(spec => actualSpec = spec)).Returns(expectedValue);

                char actualValue = fuzzy.Char();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyDouble() {
                FuzzyDouble actualSpec = null;
                double expectedValue = random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyDouble>(spec => actualSpec = spec)).Returns(expectedValue);

                double actualValue = fuzzy.Double();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class Element: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyElement() {
                FuzzyElement<TestStruct> actualSpec = null;
                var expectedValue = new TestStruct(random.Next());
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyElement<TestStruct>>(spec => actualSpec = spec)).Returns(expectedValue);
                var elements = new TestStruct[0];

                TestStruct actualValue = fuzzy.Element(elements);

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
                Assert.Same(elements, actualSpec.Field<IEnumerable<TestStruct>>().Value);
            }
        }

        public class Enum: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyEnum() {
                FuzzyEnum<TestEnum> actualSpec = null;
                var expectedValue = (TestEnum)random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyEnum<TestEnum>>(spec => actualSpec = spec)).Returns(expectedValue);

                TestEnum actualValue = fuzzy.Enum<TestEnum>();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class Index: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyIndex() {
                FuzzyIndex<TestStruct> actualSpec = null;
                int expectedValue = random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyIndex<TestStruct>>(spec => actualSpec = spec)).Returns(expectedValue);
                var elements = new TestStruct[0];

                int actualValue = fuzzy.Index(elements);

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
                Assert.Same(elements, actualSpec.Field<IEnumerable<TestStruct>>().Value);
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
            public void ReturnsValueBuiltByFuzzySingle() {
                FuzzySingle actualSpec = null;
                float expectedValue = random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzySingle>(spec => actualSpec = spec)).Returns(expectedValue);

                float actualValue = fuzzy.Single();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyUri() {
                FuzzyUri actualSpec = null;
                var expectedValue = new System.Uri($"file://{random.Next()}");
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyUri>(spec => actualSpec = spec)).Returns(expectedValue);

                System.Uri actualValue = fuzzy.Uri();

                Assert.Same(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }
    }
}
