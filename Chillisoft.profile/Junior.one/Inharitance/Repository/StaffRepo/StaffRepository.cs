using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Inharitance.Repository.StaffRepo
{
    public class StaffRepository
    {
        private readonly IGenenricRepository<Staff> _staffRepo;

        public StaffRepository(IGenenricRepository<Staff> staffRepo) { 
            _staffRepo = staffRepo;
        }
        public List<Staff> _personList = new();

        public void Create(Staff entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Position) || string.IsNullOrEmpty(entity.StaffNumber))
                throw new ArgumentNullException();
            _staffRepo.Create(entity);
        }

        public List<Staff> GetData()
        {
            return _staffRepo.GetData();
        }
    }
}
