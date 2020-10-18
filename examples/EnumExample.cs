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

        [Fact(Skip = Reason.NotImplemented)]
        public void ControlFuzzyValue() {
            TypeCode value;
            value = fuzzy.Enum<TypeCode>().Not(TypeCode.SByte);
            value = fuzzy.Enum<TypeCode>().LessThan(TypeCode.UInt64).Not(TypeCode.SByte);
            value = fuzzy.Enum<TypeCode>().GreaterThan(TypeCode.Boolean).Not(TypeCode.SByte);
            value = fuzzy.Enum<TypeCode>().Between(TypeCode.Boolean, TypeCode.Int32).Not(TypeCode.SByte);
        }
    }
}
