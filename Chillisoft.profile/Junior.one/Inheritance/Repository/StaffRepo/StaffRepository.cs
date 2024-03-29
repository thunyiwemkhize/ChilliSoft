﻿
namespace Junior.one.Inharitance.Repository.StaffRepo
{
    public class StaffRepository
    {
        private readonly IGenericRepository<Staff> _staffRepo;

        public StaffRepository(IGenericRepository<Staff> staffRepo) { 
            _staffRepo = staffRepo;
        }

        public void Create(Staff entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.FullName) || string.IsNullOrEmpty(entity.Position) || string.IsNullOrEmpty(entity.StaffNumber))
                throw new ArgumentNullException();
            _staffRepo.Create(entity);
        }

        public IEnumerable<Staff> GetData()
        {
            return _staffRepo.GetData();
        }
        public void Remove(Staff entity)
        {
            _staffRepo.Remove(entity);
        }
        public void Clear()
        {
            _staffRepo.Clear();
        }
    }
}
