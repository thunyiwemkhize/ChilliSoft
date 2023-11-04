using Junior.one.Inharitance.Repository;

namespace Tests
{
    public class StaffBuilder
    {
        public Staff staff = new Staff();

        public StaffBuilder WithFullName(string fullName)
        {
            staff.FullName = fullName;
            return this;
        }

        public StaffBuilder WithStaffNumber(string staffNumber)
        {
            staff.StaffNumber = staffNumber;
            return this;
        }
        public StaffBuilder WithPosition(string position)
        {
            staff.Position = position;
            return this;
        }
        public StaffBuilder WithId()
        {
            staff.Id = Guid.NewGuid();
            return this;
        }

        public StaffBuilder WithRandomFullName()
        {
            staff.FullName = Guid.NewGuid().ToString();
            return this;
        }
        public StaffBuilder WithEmptyStaff()
        {
            staff = new Staff();
            return this;
        }

        public StaffBuilder WithInvalidFullName()
        {
            staff.FullName = null;
            return this;
        }

        public Staff Build()
        {
            var result = staff;
            staff = new Staff();
            return result;
        }
    }
    
}
