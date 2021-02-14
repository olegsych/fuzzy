using Xunit;

namespace Fuzzy
{
    class CustomType
    {
        public int Foo;
        public string? Bar;
    }

    static class IFuzzExtensions
    {
        public static CustomType CustomType(this IFuzz fuzzy) =>
            new CustomType {
                Foo = fuzzy.Int32(),
                Bar = fuzzy.String(),
            };
    }

    public class CustomTypeExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            CustomType value = fuzzy.CustomType();
        }
    }
}
