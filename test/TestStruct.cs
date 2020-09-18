using System;

namespace Fuzzy
{
    public struct TestStruct: IComparable<TestStruct>
    {
        public readonly int Value;
        public TestStruct(int value) => Value = value;
        public int CompareTo(TestStruct other) => Value.CompareTo(other.Value);
        public bool Equals(TestStruct other) => Value.Equals(other.Value);
        public override string ToString() => Value.ToString();
    }
}
