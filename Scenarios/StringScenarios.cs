using Xunit;
using static Fuzzy.Extensions;

namespace Fuzzy
{
    public class StringScenarios
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetAnyString() {
            string s = fuzzy.String();
        }

        [Fact]
        public void GetStringOfSpecificLength() {
            string s = fuzzy.String(Length.Between(41, 43));
        }

        [Fact]
        public void GetStringWithSpecificFormat() {
            string s = fuzzy.String(Format("foo{0}"));
        }

        [Fact]
        public void GetStringWithSpecificFormatAndLength() {
            string s = fuzzy.String(Format("foo{0}"), Length.Between(42, 43));
        }
    }
}
