using Junior.one.Inharitance.Repository;
using System.Text.Json;

namespace Junior.one
{
    public class TestPerson
    {
        public void testPerson()
        {

            var repo = new GenericRepository<Staff>();
            var studentRepo = new GenericRepository<Student>();

            Console.WriteLine("enter staff fullname");
            var staffName = Console.ReadLine();
            Console.WriteLine("Enter staff number");
            var staffNumber = Console.ReadLine();
            var staff = new Staff()
            {
                FullName = staffName!,
                Position = "position",
                StaffNumber = staffNumber!,
                Id = Guid.NewGuid()
            };

            Console.WriteLine("Enter student fullname");
            var studentName = Console.ReadLine();
            Console.WriteLine("Enter student number");
            var studentNumber = Console.ReadLine();
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                Course = "ND: IT",
                FullName = studentName!,
                StudentNumber = studentNumber,
            };
            repo.Create(staff);
            studentRepo.Create(student);
            Console.WriteLine(JsonSerializer.Serialize(repo.GetData()));
            Console.WriteLine(JsonSerializer.Serialize(studentRepo.GetData()));

            Console.WriteLine("Removing staff");
            repo.Remove(staff);
            Console.WriteLine(JsonSerializer.Serialize(repo.GetData()));
        }
    }
}
