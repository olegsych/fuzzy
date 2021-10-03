using Fuzzy.Implementation;

namespace Fuzzy
{
    public interface IFuzz
    {
        int Number();
        T Build<T>(Fuzzy<T> spec);
    }
}
