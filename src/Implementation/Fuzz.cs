namespace Fuzzy.Implementation
{
    /// <summary>
    /// Provides a base class for <see cref="IFuzz"/> implementations that supply fuzzy <see langword="int"/> values through <see cref="Next"/> and share the <see cref="IFuzz.Build{T}"/> implementation.
    /// </summary>
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
