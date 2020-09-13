namespace Fuzzy
{
    public interface IFuzz
    {
        int Next();
        T GetValue<T>(Fuzzy<T> fuzzy);
    }
}
