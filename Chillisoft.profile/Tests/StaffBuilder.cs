using Junior.one.Inharitance.Repository;

namespace Tests
{
    public class StaffBuilder
    {
        public Staff staff = null!;

        public StaffBuilder WithValidStaff()
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

    public class StudentBuilder
    {
        public Student student = null!;

        public StudentBuilder WithValidStaff()
        {
            student = new Student()
            {
                Id = Guid.Parse("af7c1fe6-d669-414e-b066-e9733f0de7a8"),
                FullName = "Prosper Mkhize",
                Course = "ND: IT",
                StudentNumber = "9485764"
            };
            return this;
        }
        public StudentBuilder WithInValidStudentFullName()
        {
            student = new Student()
            {
                Id = Guid.Parse("08c71152-c552-42e7-b094-f510ff44e9cb"),
                FullName = string.Empty,
                Course = "ND: Civil Eng",
                StudentNumber = "12321234"
            };
            return this;
        }

        public StudentBuilder WithInValidStudentNumber()
        {
            student = new Student()
            {
                Id = Guid.Parse("c558a80a-f319-4c10-95d4-4282ef745b4b"),
                FullName = "Julius Malema",
                Course = "PHD: Civil Eng",
                StudentNumber = string.Empty
            };
            return this;
        }

        public StudentBuilder WithInValidStudentCourse()
        {
            student = new Student()
            {
                Id = Guid.Parse("1ad1fccc-d279-46a0-8980-1d91afd6ba67"),
                FullName = "Julius Malema",
                Course = string.Empty,
                StudentNumber = "84763746"
            };
            return this;
        }

        public Student Build()
        {
            return student;
        }
    }
    
}
