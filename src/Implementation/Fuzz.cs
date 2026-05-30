namespace Fuzzy.Implementation
{
    /// <summary>
    /// Provides a base class for <see cref="IFuzz"/> implementations that supplies <see cref="IFuzz.Build{T}(Fuzzy{T})"/>
    /// on top of a derived source of <see langword="int"/> values.
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
