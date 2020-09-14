namespace Fuzzy
{
    public interface IFuzz
    {
        int Next();
        T Build<T>(Fuzzy<T> fuzzy);
    }
}
