namespace Fuzzy.Implementation
{
    public abstract class Fuzz: IFuzz
    {
        public abstract int Next();

        T IFuzz.Build<T>(Fuzzy<T> fuzzy) => fuzzy.Build();
    }
}
