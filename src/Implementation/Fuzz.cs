namespace Fuzzy.Implementation
{
    /// <summary>
    /// Provides a base class for <see cref="IFuzz"/> implementations that derive every fuzzy value from a sequence of <see langword="int"/> values.
    /// </summary>
    /// <remarks>
    /// <see cref="RandomFuzz"/> and <see cref="SequentialFuzz"/> derive from this class, each supplying the sequence through its own <see cref="Next"/> override.
    /// </remarks>
    public abstract class Fuzz: IFuzz
    {
        /// <inheritdoc/>
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
