using System;
using System.Linq;
using Fuzzy.Implementation;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy
{
    public class StringExtensionsTest: TestFixture
    {
        // Method parameters
        readonly string value = random.Next().ToString();

        // Test fixture
        readonly FuzzyString spec;
        readonly string newValue = random.Next().ToString();

        public StringExtensionsTest() {
            spec = new FuzzyString(fuzzy);

            FuzzyContext.Set(value, spec);
            ConfiguredCall arrange = fuzzy.Build(spec).Returns(newValue);
        }

        public class LettersOrDigits: StringExtensionsTest
        {
            [Fact]
            public void ReturnsFuzzyStringConstrainedToTicks() {
                string returned = value.LettersOrDigits();

                Assert.Equal(newValue, returned);
                Assert.True(spec.Characters.All(c => char.IsLetterOrDigit(c)));
            }
        }
    }
}
