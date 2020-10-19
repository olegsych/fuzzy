using System;
using System.Collections;
using System.Collections.Generic;

namespace Fuzzy.Implementation
{
    /// <summary>
    /// Enables use of fuzzy collections where standard collection interfaces are expected, i.e. LINQ.
    /// </summary>
    public abstract class FuzzyCollection<TCollection, TItem>: Fuzzy<TCollection>,
        ICollection<TItem>, ICollection, IEnumerable<TItem>, IEnumerable, IList<TItem>, IList, IReadOnlyCollection<TItem>, IReadOnlyList<TItem>
        where TCollection : IList<TItem>, IList
    {
        protected FuzzyCollection(IFuzz fuzzy) : base(fuzzy) {}

        #region IEnumerable
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)Value).GetEnumerator();
        #endregion

        #region IEnumerable<TItem>
        IEnumerator<TItem> IEnumerable<TItem>.GetEnumerator() => Value.GetEnumerator();
        #endregion

        #region ICollection
        int ICollection.Count => ((ICollection)Value).Count;
        bool ICollection.IsSynchronized => Value.IsSynchronized;
        object ICollection.SyncRoot => Value.SyncRoot;
        void ICollection.CopyTo(Array array, int index) => Value.CopyTo(array, index);
        #endregion

        #region ICollection<TItem>
        int ICollection<TItem>.Count => ((ICollection<TItem>)Value).Count;
        bool ICollection<TItem>.IsReadOnly => ((ICollection<TItem>)Value).IsReadOnly;
        void ICollection<TItem>.Add(TItem item) => Value.Add(item);
        void ICollection<TItem>.Clear() => ((ICollection<TItem>)Value).Clear();
        bool ICollection<TItem>.Contains(TItem item) => Value.Contains(item);
        void ICollection<TItem>.CopyTo(TItem[] array, int index) => Value.CopyTo(array, index);
        bool ICollection<TItem>.Remove(TItem item) => Value.Remove(item);
        #endregion

        #region IList
        object IList.this[int index] { get => ((IList)Value)[index]; set => ((IList)Value)[index] = value; }
        bool IList.IsReadOnly => ((IList)Value).IsReadOnly;
        bool IList.IsFixedSize => Value.IsFixedSize;
        int IList.Add(object item) => Value.Add(item);
        void IList.Clear() => ((IList)Value).Clear();
        bool IList.Contains(object item) => Value.Contains(item);
        int IList.IndexOf(object item) => Value.IndexOf(item);
        void IList.Insert(int index, object item) => Value.Insert(index, item);
        void IList.Remove(object item) => Value.Remove(item);
        void IList.RemoveAt(int index) => ((IList)Value).RemoveAt(index);
        #endregion

        #region IList<TItem>
        TItem IList<TItem>.this[int index] { get => ((IList<TItem>)Value)[index]; set => ((IList<TItem>)Value)[index] = value; }
        int IList<TItem>.IndexOf(TItem item) => Value.IndexOf(item);
        void IList<TItem>.Insert(int index, TItem item) => Value.Insert(index, item);
        void IList<TItem>.RemoveAt(int index) => ((IList<TItem>)Value).RemoveAt(index);
        #endregion

        #region IReadOnlyCollection<TItem>
        int IReadOnlyCollection<TItem>.Count => ((IReadOnlyCollection<TItem>)Value).Count;
        #endregion

        #region IReadOnLyList<TItem>
        TItem IReadOnlyList<TItem>.this[int index] => ((IReadOnlyList<TItem>)Value)[index];
        #endregion
    }
}
