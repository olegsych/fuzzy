using System;
using System.Collections.Generic;

namespace Fuzzy
{
    public abstract class FuzzyRange<T>: Fuzzy<T> where T : struct, IComparable<T>, IEquatable<T>
    {
        public FuzzyRange(IFuzz fuzz) :
            base(fuzz) =>
            Included = new HashSet<T>();

        public ISet<T> Included { get; }
        public T? Maximum { get; set; }
        public T? Minimum { get; set; }
    }
}
