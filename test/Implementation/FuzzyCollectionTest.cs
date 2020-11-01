using System;
using System.Collections;
using System.Collections.Generic;
using Inspector;
using NSubstitute;
using NSubstitute.Core;
using Xunit;

namespace Fuzzy.Implementation
{
    public class FuzzyCollectionTest: TestFixture
    {
        public class TestClass { }
        public interface ITestCollection:
            ICollection<TestClass>, ICollection,
            IEnumerable<TestClass>, IEnumerable,
            IList<TestClass>, IList,
            IReadOnlyCollection<TestClass>, IReadOnlyList<TestClass> { }

        readonly FuzzyCollection<ITestCollection, TestClass> sut;

        // Test fixture
        readonly ITestCollection collection = Substitute.For<ITestCollection>();

        public FuzzyCollectionTest() {
            sut = Substitute.ForPartsOf<FuzzyCollection<ITestCollection, TestClass>>(fuzzy);
            ConfiguredCall arrange = fuzzy.Build(sut).Returns(collection, Substitute.For<ITestCollection>());
            arrange = sut.Build().Returns(Substitute.For<ITestCollection>());
        }

        public class Constructor: FuzzyCollectionTest
        {
            [Fact]
            public void InitializesBaseClass() =>
                Assert.Same(fuzzy, sut.DeclaredBy<Fuzzy<ITestCollection>>().Field<IFuzz>().Value);
        }

        public class Add: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndAddsItemForICollectionOfT() {
                ICollection<TestClass> implementation = sut;
                var expected = new TestClass();

                implementation.Add(expected);
                implementation.Add(expected);

                collection.Received(2).Add(expected);
            }

            [Fact]
            public void BuildsCollectionOnceAndAddsItemForIList() {
                IList implementation = sut;
                object item1 = new TestClass();
                int expected1 = random.Next();
                var arrange = collection.Add(item1).Returns(expected1);
                object item2 = new TestClass();
                int expected2 = random.Next();
                arrange = collection.Add(item2).Returns(expected2);

                Assert.Equal(expected1, implementation.Add(item1));
                Assert.Equal(expected2, implementation.Add(item2));
            }
        }

        public class Clear: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndCallsClearForICollectionOfT() {
                ICollection<TestClass> implementation = sut;

                implementation.Clear();
                implementation.Clear();

                ((ICollection<TestClass>)collection).Received(2).Clear();
            }

            [Fact]
            public void BuildsCollectionOnceAndCallsClearForIList() {
                IList implementation = sut;

                implementation.Clear();
                implementation.Clear();

                ((IList)collection).Received(2).Clear();
            }
        }

        public class Contains: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsBooleanForICollectionOfT() {
                ICollection<TestClass> implementation = sut;
                var expected = new TestClass();
                ConfiguredCall arrange = collection.Contains(expected).Returns(true);

                Assert.True(implementation.Contains(expected));
                Assert.True(implementation.Contains(expected));
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsBooleanForIList() {
                IList implementation = sut;
                object expected = new TestClass();
                ConfiguredCall arrange = collection.Contains(expected).Returns(true);

                Assert.True(implementation.Contains(expected));
                Assert.True(implementation.Contains(expected));
            }
        }

        public class CopyTo: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndCallsCopyToForICollection() {
                Array array = new TestClass[0];
                int index = random.Next();

                ICollection implementation = sut;
                implementation.CopyTo(array, index);
                implementation.CopyTo(array, index);

                collection.Received(2).CopyTo(array, index);
            }

            [Fact]
            public void BuildsCollectionOnceAndCallsCopyToForICollectionOfT() {
                var array = new TestClass[0];
                int index = random.Next();

                ICollection<TestClass> implementation = sut;
                implementation.CopyTo(array, index);
                implementation.CopyTo(array, index);

                collection.Received(2).CopyTo(array, index);
            }
        }

        public class Count: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsCountForICollection() {
                int expected = random.Next();
                ConfiguredCall arrange = ((ICollection)collection).Count.Returns(expected);

                ICollection actual = sut;

                Assert.Equal(expected, actual.Count);
                Assert.Equal(expected, actual.Count);
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsCountForICollectionOfT() {
                int expected = random.Next();
                ConfiguredCall arrange = ((ICollection<TestClass>)collection).Count.Returns(expected);

                ICollection<TestClass> actual = sut;

                Assert.Equal(expected, actual.Count);
                Assert.Equal(expected, actual.Count);
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsCountForIReadOnlyCollectionOfT() {
                int expected = random.Next();
                ConfiguredCall arrange = ((IReadOnlyCollection<TestClass>)collection).Count.Returns(expected);

                IReadOnlyCollection<TestClass> actual = sut;

                Assert.Equal(expected, actual.Count);
                Assert.Equal(expected, actual.Count);
            }
        }

        public class GetEnumerator: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsEnumeratorForIEnumerable() {
                var expected = Substitute.For<IEnumerator>();
                ConfiguredCall arrange = ((IEnumerable)collection).GetEnumerator().Returns(expected);

                IEnumerable actual = sut;

                Assert.Same(expected, actual.GetEnumerator());
                Assert.Same(expected, actual.GetEnumerator());
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsEnumeratorForIEnumerableOfT() {
                var expected = Substitute.For<IEnumerator<TestClass>>();
                ConfiguredCall arrange = collection.GetEnumerator().Returns(expected);

                IEnumerable<TestClass> actual = sut;

                Assert.Same(expected, actual.GetEnumerator());
                Assert.Same(expected, actual.GetEnumerator());
            }
        }

        public class IndexOf: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsIndexOfIList() {
                IList implementation = sut;
                object item = new TestClass();
                int expected = random.Next();
                ConfiguredCall arrange = collection.IndexOf(item).Returns(expected);

                Assert.Equal(expected, implementation.IndexOf(item));
                Assert.Equal(expected, implementation.IndexOf(item));
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsIndexOfIListOfT() {
                IList<TestClass> implementation = sut;
                var item = new TestClass();
                int expected = random.Next();
                ConfiguredCall arrange = collection.IndexOf(item).Returns(expected);

                Assert.Equal(expected, implementation.IndexOf(item));
                Assert.Equal(expected, implementation.IndexOf(item));
            }
        }

        public class Insert: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndCallsInsertForIList() {
                object item = new TestClass();
                int index = random.Next();

                IList implementation = sut;
                implementation.Insert(index, item);
                implementation.Insert(index, item);

                collection.Received(2).Insert(index, item);
            }

            [Fact]
            public void BuildsCollectionOnceAndCallsInsertForIListOfT() {
                var item = new TestClass();
                int index = random.Next();

                IList<TestClass> implementation = sut;
                implementation.Insert(index, item);
                implementation.Insert(index, item);

                collection.Received(2).Insert(index, item);
            }
        }

        public class IsFixedSize: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsValueFromIList() {
                ConfiguredCall arrange = collection.IsFixedSize.Returns(true);

                IList implementation = sut;

                Assert.True(implementation.IsFixedSize);
                Assert.True(implementation.IsFixedSize);
            }
        }

        public class IsReadOnly: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsValueFromIList() {
                ConfiguredCall arrange = ((IList)collection).IsReadOnly.Returns(true);

                IList implementation = sut;

                Assert.True(implementation.IsReadOnly);
                Assert.True(implementation.IsReadOnly);
            }

            [Fact]
            public void BuildsCollectionOnceAndReturnsValueFromICollectionOfT() {
                ConfiguredCall arrange = ((ICollection<TestClass>)collection).IsReadOnly.Returns(true);

                ICollection<TestClass> implementation = sut;

                Assert.True(implementation.IsReadOnly);
                Assert.True(implementation.IsReadOnly);
            }
        }

        public class IsSynchronized: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsValueFromICollection() {
                ConfiguredCall arrange = collection.IsSynchronized.Returns(true);

                ICollection implementation = sut;

                Assert.True(implementation.IsSynchronized);
                Assert.True(implementation.IsSynchronized);
            }
        }

        public class Remove: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsBooleanForICollectionOfT() {
                ICollection<TestClass> implementation = sut;
                var expected = new TestClass();
                ConfiguredCall arrange = collection.Remove(expected).Returns(true);

                Assert.True(implementation.Remove(expected));
                Assert.True(implementation.Remove(expected));
            }

            [Fact]
            public void BuildsCollectionOnceAndCallsRemoveForIList() {
                IList implementation = sut;
                object expected = new TestClass();

                implementation.Remove(expected);
                implementation.Remove(expected);

                collection.Received(2).Remove(expected);
            }
        }

        public class RemoveAt: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndCallsRemoveAtForIList() {
                int index = random.Next();

                IList implementation = sut;
                implementation.RemoveAt(index);
                implementation.RemoveAt(index);

                ((IList)collection).Received(2).RemoveAt(index);
            }

            [Fact]
            public void BuildsCollectionOnceAndCallsRemoveAtForIListOfT() {
                int index = random.Next();

                IList<TestClass> implementation = sut;
                implementation.RemoveAt(index);
                implementation.RemoveAt(index);

                ((IList<TestClass>)collection).Received(2).RemoveAt(index);
            }
        }

        public class SyncRoot: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndReturnsValueFromICollection() {
                var expected = new object();
                ConfiguredCall arrange = collection.SyncRoot.Returns(expected);

                ICollection implementation = sut;

                Assert.Same(expected, implementation.SyncRoot);
                Assert.Same(expected, implementation.SyncRoot);
            }
        }

        public class This: FuzzyCollectionTest
        {
            [Fact]
            public void BuildsCollectionOnceAndGetsItemFromIReadOnlyListOfT() {
                int index = random.Next();
                var expected = new TestClass();
                ConfiguredCall arrange = ((IReadOnlyList<TestClass>)collection)[index].Returns(expected);

                IReadOnlyList<TestClass> implementation = sut;
                Assert.Same(expected, implementation[index]);
                Assert.Same(expected, implementation[index]);
            }

            [Fact]
            public void BuildsCollectionOnceAndGetsItemFromIListOfT() {
                int index = random.Next();
                var expected = new TestClass();
                ConfiguredCall arrange = ((IList<TestClass>)collection)[index].Returns(expected);

                IList<TestClass> implementation = sut;
                Assert.Same(expected, implementation[index]);
                Assert.Same(expected, implementation[index]);
            }

            [Fact]
            public void BuildsCollectionOnceAndGetsItemFromIList() {
                int index = random.Next();
                object expected = new TestClass();
                ConfiguredCall arrange = ((IList)collection)[index].Returns(expected);

                IList implementation = sut;
                Assert.Same(expected, implementation[index]);
                Assert.Same(expected, implementation[index]);
            }

            [Fact]
            public void BuildsCollectionOnceAndSetsItemForIListOfT() {
                int index = random.Next();
                var item = new TestClass();

                IList<TestClass> implementation = sut;
                implementation[index] = item;
                implementation[index] = item;

                ((IList<TestClass>)collection).Received(2)[index] = item;
            }

            [Fact]
            public void BuildsCollectionOnceAndSetsItemForIList() {
                int index = random.Next();
                object item = new TestClass();

                IList implementation = sut;
                implementation[index] = item;
                implementation[index] = item;

                ((IList)collection).Received(2)[index] = item;
            }
        }
    }
}
