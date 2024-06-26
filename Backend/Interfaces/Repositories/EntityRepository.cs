namespace Backend.Interfaces
{
    public interface EntityRepository<T, TKey>
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T Get(TKey id);
        void Set(TKey id, T item);
        void Delete(TKey id);
    }
}