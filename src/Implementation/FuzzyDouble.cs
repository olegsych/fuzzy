using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzyDouble: Fuzzy<double>
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#floating-point-types
        const ulong minMantissa = 1;                // 0 + 1
        const ulong maxMantissa = 0x1FFFFFFFFFFFFF; // 2 ^ 53 - 1
        const short minExponent = -1075 - 1;        // -1 to allow positive and negative 0
        const short maxExponent = 971 + 1;          // +1 to allow positive and negative infinity

        public FuzzyDouble(IFuzz fuzzy) : base(fuzzy) { }

        protected internal override double Build() {
            bool positive = fuzzy.Boolean();
            int sign = positive ? 1 : -1;
            ulong mantissa = fuzzy.UInt64().Between(minMantissa, maxMantissa);
            short exponent = fuzzy.Int16().Between(minExponent, maxExponent);
            return sign * (long)mantissa * Math.Pow(2, exponent);
        }
    }
}
