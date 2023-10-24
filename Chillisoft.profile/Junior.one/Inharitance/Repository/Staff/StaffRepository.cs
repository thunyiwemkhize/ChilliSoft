using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Junior.one.Inharitance.Repository.Staff;

namespace Junior.one.Generics.Repository.Staff
{
    public class StaffRepository: IStaffRepository
    {
        public List<Inharitance.Staff> _personList = new();

        public void Create(Inharitance.Staff entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Position) || string.IsNullOrEmpty(entity.StaffNumber))
                throw new ArgumentNullException();
            _personList.Add(entity);
        }
    }
}
