namespace Junior.one.Inharitance.Repository
{
    public interface IGenericRepository<T>
    {
        void Create(T entity);
        IEnumerable<T> GetData();
        //        void Remove(T entity);
        //        void Clear();
    }
}
