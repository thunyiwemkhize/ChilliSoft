using Junior.one.Inharitance.Repository;
using System.Text.Json;

namespace Junior.one
{
    public class TestGenericListWithStaff
    {
        public void TestGenericRepoWithStaff()
        {

            var repo = new GenericRepository<Staff>();
            Console.WriteLine("--------------------Creating staff--------------------");
            CreateRandomStaffList(repo);
            WriteStaffList(repo);

            Console.WriteLine("--------------------Deleting staff by staff number--------------------");
            while (true)
            {
                Console.WriteLine("Enter staff number to be removed");
                var staffNumberToRemove = Console.ReadLine();

                RemoveStaff(repo, staffNumberToRemove);
                WriteStaffList(repo);
                Console.WriteLine("Press 1 to remove another staff member");
                var action = Console.ReadLine();
                if (action != "1") break; 
            }
            Console.WriteLine("--------------------Crearing all staff--------------------");
            Console.WriteLine("Clearing everything in the array");
            repo.Clear();
            Console.WriteLine($"Number of remaining staff in the array: {repo.GetData().Count()}");
        }

        private static void RemoveStaff(GenericRepository<Staff> repo, string? staffNumberToRemove)
        {
            var staff = repo.GetData().FirstOrDefault(x => x.StaffNumber == staffNumberToRemove);
            if (staff != null)
            {
                Console.WriteLine($"Removing staff {staff.FullName}");
                repo.Remove(staff);
            }
            else
            {
                Console.WriteLine($"Staff with staff number {staffNumberToRemove} was not found ");
            }
        }

        private static void WriteStaffList(GenericRepository<Staff> repo)
        {
            repo.GetData().ToList().ForEach(x =>
            {
                Console.WriteLine($"StaffNumber: {x.StaffNumber}, Fullname: {x.FullName} ", Environment.NewLine);
            });
        }

        private static void CreateRandomStaffList(GenericRepository<Staff> repo)
        {
           for(int i = 0; i < 5; i++)
            {
                var staff = new Staff()
                {
                    FullName = new GenerateStaffList().RandomFullName()[i],
                    Position = "position",
                    StaffNumber = new GenerateStaffList().RandomStaffNumbers()[i],
                    Id = Guid.NewGuid()
                };
                repo.Create(staff);
            }
        }

    }

    public class GenerateStaffList
    {
        public List<string> RandomFullName()
        {
            return new List< string>()
            {
             "John Snow","Thunyiwe Mkhize","Percy Nene","Sakhile Derulo","Joshua Mhlongo", "Raymond Ndlovu","Jack Kane", "Bob Zimu","Samkelo Manyoni", "Sfiso Ngcobo"
            };
        }
    
        public List<string> RandomStaffNumbers()
        {
            return new List<string>()
            {
                "10000000","20000000","30000000","40000000","50000000","60000000","70000000","80000000","90000000","11000000"
            };
        }
    }
}
