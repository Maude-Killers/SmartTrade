namespace Backend.Interfaces
{
    public interface EntityRepository<T>
    {
        void Create(T item);
        IEnumerable<T> GetAll();
        T? Get(int id);
        void Set(int id, T item);
        void Delete(int id);
    }
}