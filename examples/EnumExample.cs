using System;
using Fuzzy;
using Xunit;

namespace Example
{
    public class EnumExample
    {
        static readonly IFuzz fuzzy = new SequentialFuzz();

        [Fact]
        public void GetAnyEnum() {
            TypeCode e = fuzzy.Enum<TypeCode>();
        }

        [Fact]
        public void ControlEnumValue() {
            TypeCode e;
            e = fuzzy.Enum<TypeCode>().Not(TypeCode.SByte);
            e = fuzzy.Enum<TypeCode>().LessThan(TypeCode.UInt64).Not(TypeCode.SByte);
            e = fuzzy.Enum<TypeCode>().GreaterThan(TypeCode.Boolean).Not(TypeCode.SByte);
            e = fuzzy.Enum<TypeCode>().Between(TypeCode.Boolean, TypeCode.Int32).Not(TypeCode.SByte);
        }
    }
}
