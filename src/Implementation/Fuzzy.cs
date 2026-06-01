using System;

namespace Fuzzy.Implementation
{
    /// <summary>
    /// Specifies how a fuzzy value of type <typeparamref name="T"/> is produced.
    /// </summary>
    public abstract class Fuzzy<T>
    {
        /// <summary>
        /// The <see cref="IFuzz"/> used to build the fuzzy value.
        /// </summary>
        protected readonly IFuzz fuzzy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Fuzzy{T}"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>.</exception>
        public Fuzzy(IFuzz fuzzy) =>
            this.fuzzy = fuzzy ?? throw new ArgumentNullException(nameof(fuzzy));

        /// <summary>
        /// Returns a fuzzy value of type <typeparamref name="T"/> matching this specification.
        /// </summary>
        protected internal abstract T Build();

        /// <summary>
        /// Returns a fuzzy value of type <typeparamref name="T"/> built from <paramref name="spec"/>.
        /// </summary>
        // TODO: leaks NullReferenceException when spec is null; should throw ArgumentNullException instead.
        public static implicit operator T(Fuzzy<T> spec) => spec.fuzzy.Build(spec);
    }
}
