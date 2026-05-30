namespace Fuzzy.Implementation
{
    /// <summary>
    /// Provides a base class for <see cref="IFuzz"/> implementations whose derived classes only need to implement
    /// <see cref="IFuzz.Next"/>; the shared <see cref="IFuzz.Build{T}(Fuzzy{T})"/> implementation is supplied here.
    /// </summary>
    public abstract class Fuzz: IFuzz
    {
        /// <inheritdoc/>
        public abstract int Next();

        /// <inheritdoc/>
        T IFuzz.Build<T>(Fuzzy<T> spec) {
            if(spec is null)
                throw new System.ArgumentNullException(nameof(spec));
            T value = spec.Build();
            FuzzyContext.Set(value, spec);
            return value;
        }
    }
}
