using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Produces fuzzy values for use in tests.
    /// </summary>
    /// <remarks>
    /// Implementations supply the source of randomness that powers the <c>Fuzzy</c> extension methods.
    /// Most consumers obtain fuzzy values through those extensions rather than calling members of this interface directly.
    /// </remarks>
    public interface IFuzz
    {
        /// <summary>
        /// Returns a non-negative, fuzzy <see langword="int"/>.
        /// </summary>
        int Next();

        /// <summary>
        /// Returns a fuzzy value of type <typeparamref name="T"/> built from the given specification.
        /// </summary>
        /// <typeparam name="T">The type of value to build.</typeparam>
        /// <param name="spec">The specification that describes how to build the value.</param>
        T Build<T>(Fuzzy<T> spec);
    }
}
