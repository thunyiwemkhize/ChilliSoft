namespace Junior.one.Inharitance
{
    public class Student: Person
    {
        public string? StudentNumber { get; set; }
        public string? Course { get; set; }

        public override void CalculateUsingDateOfBirth()
        {
            Console.WriteLine($"This year are {DateTime.Now.Year - GenerateDateOfBirth(-25).Year} years old");
        }

        public override void Travels()
        {
            Console.WriteLine("Student travels to School");
        }
    }
}
