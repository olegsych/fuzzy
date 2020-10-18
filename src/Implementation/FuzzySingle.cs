using System;

namespace Fuzzy.Implementation
{
    sealed class FuzzySingle: Fuzzy<float>
    {
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#floating-point-types
        const uint minMantissa = 1;         // 0 + 1
        const uint maxMantissa = 0xFFFFFF;  // 2 ^ 24 - 1
        const short minExponent = -149 - 1; // -1 to allow positive and negative 0
        const short maxExponent = 104 + 1;  // +1 to allow positive and negative infinity

        public FuzzySingle(IFuzz fuzzy) : base(fuzzy) { }

        protected internal override float Build() {
            bool positive = fuzzy.Boolean();
            int sign = positive ? 1 : -1;
            uint mantissa = fuzzy.UInt32().Between(minMantissa, maxMantissa);
            short exponent = fuzzy.Int16().Between(minExponent, maxExponent);
            return sign * mantissa * (float)Math.Pow(2, exponent);
        }
    }
}
