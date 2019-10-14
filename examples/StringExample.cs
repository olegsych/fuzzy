using Fuzzy;
using Xunit;

namespace Example
{
    public class StringExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetValue() {
            string s;
            s = fuzzy.String();
            s = fuzzy.String(Length.Between(41, 43));
            s = fuzzy.String().Format("foo{0}");
            s = fuzzy.String(Length.Between(42, 43)).Format("foo{0}");
        }

        [Fact]
        public void GetArray() {
            string[] s = fuzzy.Array(fuzzy.String);
        }
    }
}
