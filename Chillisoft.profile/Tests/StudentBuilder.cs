using Junior.one.Inharitance.Repository;

namespace Tests
{
    public class StudentBuilder
    {
        public Student student = new Student();

        public StudentBuilder WithFullName(string fullName)
        {
            student.FullName = fullName;
            return this;
        }
        public StudentBuilder WithStudentNumber(string studentNumber)
        {
            student.StudentNumber = studentNumber;
            return this;
        }
        public StudentBuilder WithStudentCourse(string course)
        {
            student.Course = course;
            return this;
        }
        public StudentBuilder WithId()
        {
            student.Id = Guid.NewGuid();
            return this;
        }

        public Student Build()
        {
            return student;
        }
    }
    
}
