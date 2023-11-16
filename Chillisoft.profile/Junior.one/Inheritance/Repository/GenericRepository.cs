namespace Junior.one.Inharitance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>
    {
        private T[] genericList = new T[0];

        public void Clear()
        {
            T[] emptyArray = new T[0];
            if (genericList.Any())
                genericList = emptyArray;
                
        }
        public void Create(T genericEntity)
        {
            if(genericEntity is null)
            {
                throw new ArgumentNullException();
            }
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
        public void Remove(T entity)
        {
           
            T[] newGenericListWithOneLessSpace = new T[genericList.Length - 1];
            int newIndex = 0;

            for (int i = 0; i < genericList.Length; i++)
            {
                if (genericList[i] == null)
                    continue;

                if (!genericList[i]!.Equals(entity))
                {
                    newGenericListWithOneLessSpace[newIndex] = genericList[i];
                    newIndex++;
                }
            }

            genericList = newGenericListWithOneLessSpace;
        }
    }
}
