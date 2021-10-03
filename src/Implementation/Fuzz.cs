namespace Fuzzy.Implementation
{
    public abstract class Fuzz: IFuzz
    {
        public abstract int Number();

        public T Build<T>(Fuzzy<T> spec) {
            if(spec is null)
                throw new System.ArgumentNullException(nameof(spec));
            T value = spec.Build();
            FuzzyContext.Set(value, spec);
            return value;
        }
    }
}
