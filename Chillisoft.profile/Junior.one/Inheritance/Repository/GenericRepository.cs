namespace Junior.one.Inharitance.Repository
{
    public class GenericRepository<T> : IGenenricRepository<T>
    {
        private List<T> data = new List<T>();

        public void Create(T entity)
        {
            data.Add(entity);
        }
        public List<T> GetData()
        {
            return data;
        }
    }
}
