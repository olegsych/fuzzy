using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyStringTest: TestFixture
    {
        readonly Fuzzy<string> sut;

        // Constructor parameters
        readonly Length length = new Length();
        readonly IEnumerable<char> characters = Substitute.For<IEnumerable<char>>();

        public FuzzyStringTest() => sut = new FuzzyString(fuzzy, length, characters);

        public class Constructor: FuzzyStringTest
        {
            [Fact]
            public void initializesLengthWithGivenArgument() => Assert.Same(length, sut.Field<Length>().Value);

            [Fact]
            public void InitializesLengthWithNewLengthByDefault() {
                var expected = new Length();

                var actual = new FuzzyString(fuzzy, default, characters);

                Assert.Equal(expected, actual.Field<Length>().Value);
            }

            [Fact]
            public void InitializesCharactersWithGivenCollection() => Assert.Same(characters, ((FuzzyString)sut).Characters);

            [Fact]
            public void InitializesCharactersWithPrintableAsciiCharactersByDefault() {
                int space = ' ';
                int tilde = '~';
                IEnumerable<char> expected = Enumerable.Range(space, tilde - space + 1).Select(n => (char)n);

                var actual = new FuzzyString(fuzzy, length, default);

                Assert.Equal(expected, actual.Characters);
            }
        }

        public class Build: FuzzyStringTest
        {
            // Arrange
            readonly char[] expectedCharacters = Enumerable.Range(0, 8 + random.Next() % 5).Select(n => (char)(random.Next() % char.MaxValue)).ToArray();
            FuzzyArray<char>? actualSpec = null;
            readonly string actualString;

            public Build() {
                ConfiguredCall arrange = fuzzy.Build(Arg.Do<FuzzyArray<char>>(spec => actualSpec = spec)).Returns(expectedCharacters);

                // Act
                actualString = sut.Build();
            }

            [Fact]
            public void ReturnsStringCreatedFromFuzzyArrayOfCharacters() =>
                Assert.Equal(new string(expectedCharacters), actualString);

            [Fact]
            public void ReturnsStringCreatedWithGivenCharacters() {
                var expected = (char)(random.Next() % char.MaxValue);
                Expression<Predicate<FuzzyElement<char>>> fuzzyElement = f => ReferenceEquals(characters, f.Field<IEnumerable<char>>().Value);
                ConfiguredCall arrange = fuzzy.Build(Arg.Is(fuzzyElement)).Returns(expected);

                char actual = actualSpec!.Field<Func<char>>().Value!();

                Assert.Equal(expected, actual);
            }

            [Fact]
            public void ReturnsStringCreatedWithGivenLength() =>
                Assert.Same(length, actualSpec!.Field<Length>().Value);
        }

        public class Characters: FuzzyStringTest
        {
            new readonly FuzzyString sut;

            public Characters() => sut = (FuzzyString)base.sut;

            [Fact]
            public void ThrowsDescriptiveExceptionWhenValueIsNull() {
                var thrown = Assert.Throws<ArgumentNullException>(() => sut.Characters = null!);
                Assert.Equal("value", thrown.ParamName);
            }
        }
    }
}
