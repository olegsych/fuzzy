using NSubstitute;

namespace Fuzzy
{
    public class FuzzyArrayTest
    {
        readonly Fuzzy<TestClass[]> sut;

        // Constructor parameters
        readonly IFuzz fuzz = Substitute.For<IFuzz>();

        FuzzyArrayTest() => sut = new FuzzyArray<TestClass>(fuzz);
    }

    class TestClass { }
}
