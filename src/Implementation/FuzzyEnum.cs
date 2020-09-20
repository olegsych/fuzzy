using System;
using System.Linq;

namespace Fuzzy.Implementation
{
    sealed class FuzzyEnum<T>: Fuzzy<T> where T : Enum
    {
        public FuzzyEnum(IFuzz fuzzy) : base(fuzzy) { }
        public override T New() => fuzzy.Element(Enum.GetValues(typeof(T)).Cast<T>());
    }
}
