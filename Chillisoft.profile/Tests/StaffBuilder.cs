using Junior.one.Inharitance.Repository;

namespace Tests
{
    public partial class StaffRepositoryTest
    {
        public class StaffBuilder
        {
            public Staff staff = null;

            public StaffBuilder WithValidStudent()
            {
                staff = new Staff()
                {
                    Id = Guid.Parse("6dd40b2f-2631-4ce2-91da-e4c5a5d2b378"),
                    FullName = "John Snow",
                    Position = "Lecture",
                    StaffNumber = "84764756"
                };
                return this;
            }
            public StaffBuilder WithInvalidStaffFullName()
            {
                staff = new Staff()
                {
                    Id = Guid.NewGuid(),
                    FullName = string.Empty,
                    Position = "HOD",
                    StaffNumber = "123456787",
                };
                return this;
            }
            public StaffBuilder WithInvalidStaffPosition()
            {
                staff = new Staff()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Jessica Nkosi",
                    Position = string.Empty,
                    StaffNumber = "12345678",
                };
                return this;
            }
            public StaffBuilder WithInvalidStaffNumber()
            {
                staff = new Staff()
                {
                    Id = Guid.NewGuid(),
                    FullName = "Thunyiwe Mkhize",
                    Position = "Juinor HOD",
                    StaffNumber = string.Empty,
                };
                return this;
            }
            public Staff Build()
            {
                return staff;
            }
           
        }
    }
}
