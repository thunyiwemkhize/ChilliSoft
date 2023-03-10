using Junior.one.Inharitance;

namespace Junior.one.Inharitence
{
    public class Staff: Person
    {
        public string? StaffNumber { get; set; }
        public string? Qualification { get; set; }
        public double Salary { get; set; }

        public override void CalculateUsingDateOfBirth()
        {

            Console.WriteLine($"{60 - (DateTime.Now.Year - GenerateDateOfBirth(-54).Year)} years remaining before you retire");
        }

        public override void Travels()
        {
            Console.WriteLine("Staff travels to work");
        }
    }
}
