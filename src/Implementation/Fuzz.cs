namespace Fuzzy.Implementation
{
    /// <summary>For internal use.</summary>
    public abstract class Fuzz: IFuzz
    {
        /// <summary>For internal use.</summary>
        public abstract int Next();

        T IFuzz.Build<T>(Fuzzy<T> spec) {
            if(spec is null)
                throw new System.ArgumentNullException(nameof(spec));
            T value = spec.Build();
            FuzzyContext.Set(value, spec);
            return value;
        }
    }
}
