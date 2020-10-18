using System;
using System.Linq;

namespace Fuzzy.Implementation
{
    sealed class FuzzyEnum<T>: Fuzzy<T> where T : Enum
    {
        public FuzzyEnum(IFuzz fuzzy) : base(fuzzy) { }
        protected internal override T Build() => fuzzy.Element(Enum.GetValues(typeof(T)).Cast<T>());
    }
}
