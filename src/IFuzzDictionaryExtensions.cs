using System;
using System.Collections.Generic;
using System.Linq;
using Fuzzy.Implementation;

namespace Fuzzy
{
    /// <summary>
    /// Provides <see cref="IFuzz"/> extension methods that produce fuzzy dictionaries.
    /// </summary>
    public static class IFuzzDictionaryExtensions
    {
        /// <summary>Returns a fuzzy dictionary whose keys are produced by <paramref name="createKey"/>, values are produced by <paramref name="createValue"/>, and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> or <paramref name="createKey"/> is <see langword="null"/>.</exception>
        // TODO: When createValue is null, a NullReferenceException leaks from the captured lambda when the value factory
        // is invoked, instead of an ArgumentNullException with ParamName == "createValue".
        // TODO: When createKey is null, the ArgumentNullException thrown by FuzzyDictionary<TKey, TValue> has
        // ParamName == "keyFactory" instead of "createKey".
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TValue> createValue, Count? count = default)
            => fuzzy.Dictionary(createKey, k => createValue(), count);

        /// <summary>Returns a fuzzy dictionary whose keys are produced by <paramref name="createKey"/>, whose values are produced by <paramref name="createValue"/> from each key, and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/>, <paramref name="createKey"/>, or <paramref name="createValue"/> is <see langword="null"/>.</exception>
        // TODO: When createKey is null, the ArgumentNullException thrown by FuzzyDictionary<TKey, TValue> has
        // ParamName == "keyFactory" instead of "createKey".
        // TODO: When createValue is null, the ArgumentNullException thrown by FuzzyDictionary<TKey, TValue> has
        // ParamName == "valueFactory" instead of "createValue".
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, Func<TKey> createKey, Func<TKey, TValue> createValue, Count? count = default)
            => new FuzzyDictionary<TKey, TValue>(fuzzy, createKey, createValue, count ?? new Count());

        /// <summary>Returns a fuzzy dictionary whose key/value pairs are chosen from <paramref name="elements"/> and whose count is within <paramref name="count"/>, or a default <see cref="Count"/> if <see langword="null"/>.</summary>
        /// <exception cref="ArgumentNullException"><paramref name="fuzzy"/> is <see langword="null"/>, or <paramref name="elements"/> is <see langword="null"/> and the generated dictionary count is non-zero.</exception>
        // TODO: When elements is null and the generated dictionary count is non-zero, the ArgumentNullException
        // thrown by FuzzyElement<T> has ParamName == "candidates" instead of "elements".
        // TODO: When elements is empty and the generated dictionary count is non-zero, an internal ArgumentOutOfRangeException
        // (ParamName == "value") leaks from the FuzzyRange.Maximum setter via Between(0, -1), instead of a domain-appropriate
        // exception about elements.
        public static Dictionary<TKey, TValue> Dictionary<TKey, TValue>(this IFuzz fuzzy, IReadOnlyDictionary<TKey, TValue> elements, Count? count = default)
            => fuzzy.Dictionary(() => fuzzy.Element(elements).Key, k => elements[k], count);
    }
}
