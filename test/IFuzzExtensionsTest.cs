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
            public void ReturnsValueBuiltByFuzzyByte() {
                FuzzyByte actualSpec = null;
                var expectedValue = (byte)(random.Next() % byte.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyByte>(spec => actualSpec = spec)).Returns(expectedValue);

                byte actualValue = fuzzy.Byte();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyDateTime() {
                FuzzyDateTime actualSpec = null;
                var expectedValue = new System.DateTime(random.Next());
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyDateTime>(spec => actualSpec = spec)).Returns(expectedValue);

                System.DateTime actualValue = fuzzy.DateTime();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }

            [Theory, InlineData(DateTimeKind.Unspecified), InlineData(DateTimeKind.Local), InlineData(DateTimeKind.Utc)]
            public void ReturnsValueBuiltByFuzzyDateTimeWithGivenKind(DateTimeKind expectedKind) {
                FuzzyDateTime actualSpec = null;
                var arrange = fuzzy.Build(Arg.Do<FuzzyDateTime>(spec => actualSpec = spec));

                System.DateTime verifiedByAnotherTest = fuzzy.DateTime(expectedKind);

                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
                Assert.Equal(expectedKind, actualSpec.Field<DateTimeKind?>().Value);
            }
        }

        public class DateTimeOffset: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyDateTimeOffset() {
                FuzzyDateTimeOffset actualSpec = null;
                var expectedValue = new System.DateTimeOffset(random.Next(), System.TimeSpan.Zero);
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyDateTimeOffset>(spec => actualSpec = spec)).Returns(expectedValue);

                System.DateTimeOffset actualValue = fuzzy.DateTimeOffset();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyInt64() {
                FuzzyInt64 actualSpec = null;
                var expectedValue = (long)random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyInt64>(spec => actualSpec = spec)).Returns(expectedValue);

                long actualValue = fuzzy.Int64();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class SByte: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzySByte() {
                FuzzySByte actualSpec = null;
                var expectedValue = (sbyte)(random.Next() % sbyte.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzySByte>(spec => actualSpec = spec)).Returns(expectedValue);

                sbyte actualValue = fuzzy.SByte();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
            public void ReturnsValueBuiltByFuzzyTimeSpan() {
                FuzzyTimeSpan actualSpec = null;
                var expectedValue = new System.TimeSpan(random.Next());
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyTimeSpan>(spec => actualSpec = spec)).Returns(expectedValue);

                System.TimeSpan actualValue = fuzzy.TimeSpan();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class UInt16: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyUInt16() {
                FuzzyUInt16 actualSpec = null;
                var expectedValue = (ushort)(random.Next() % ushort.MaxValue);
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyUInt16>(spec => actualSpec = spec)).Returns(expectedValue);

                ushort actualValue = fuzzy.UInt16();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class UInt32: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyUInt32() {
                FuzzyUInt32 actualSpec = null;
                var expectedValue = (uint)random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyUInt32>(spec => actualSpec = spec)).Returns(expectedValue);

                uint actualValue = fuzzy.UInt32();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
            }
        }

        public class UInt64: IFuzzExtensionsTest
        {
            [Fact]
            public void ReturnsValueBuiltByFuzzyUInt64() {
                FuzzyUInt64 actualSpec = null;
                var expectedValue = (ulong)random.Next();
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyUInt64>(spec => actualSpec = spec)).Returns(expectedValue);

                ulong actualValue = fuzzy.UInt64();

                Assert.Equal(expectedValue, actualValue);
                Assert.Same(fuzzy, actualSpec.Field<IFuzz>().Value);
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
