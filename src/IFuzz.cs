using System;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Produces fuzzy values for use in tests.
    /// </summary>
    /// <remarks>
    /// Implementations supply the source of values that powers the <c>Fuzzy</c> extension methods.
    /// Most consumers obtain fuzzy values through those extensions rather than calling members of this interface directly.
    /// </remarks>
    public interface IFuzz
    {
        /// <summary>
        /// Returns the next fuzzy <see langword="int"/>.
        /// </summary>
        int Next();

        /// <summary>
        /// Returns a fuzzy value of type <typeparamref name="T"/> built from the given specification.
        /// </summary>
        /// <typeparam name="T">The type of value to build.</typeparam>
        /// <param name="spec">The specification that describes how to build the value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="spec"/> is <see langword="null"/>.</exception>
        T Build<T>(Fuzzy<T> spec);
    }
}
