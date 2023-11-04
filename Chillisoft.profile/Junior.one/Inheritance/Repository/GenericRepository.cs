namespace Junior.one.Inharitance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private T[] genericList = new T[0];

        public void Create(T genericEntity)
        {
            T[] newGenericListWithOneExtraSpace = new T[genericList.Length + 1];

            for (int i = 0; i < genericList.Length; i++)
            {
                newGenericListWithOneExtraSpace[i] = genericList[i];
            }

            newGenericListWithOneExtraSpace[genericList.Length] = genericEntity;

            genericList = newGenericListWithOneExtraSpace;
        }
        public IEnumerable<T> GetData()
        {
            return genericList;
        }
    }
}
