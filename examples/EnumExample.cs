using System;
using Xunit;

namespace Fuzzy
{
    public class EnumExample
    {
        static readonly IFuzz fuzzy = new RandomFuzz();

        [Fact]
        public void GetFuzzyValue() {
            TypeCode value = fuzzy.Enum<TypeCode>();
        }
    }
}
