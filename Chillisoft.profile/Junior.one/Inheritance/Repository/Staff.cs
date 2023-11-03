namespace Junior.one.Inharitance.Repository
{
    public class Staff : Person
    {
        public string StaffNumber { get; set; } 
        public string? Position { get; set; }

        public Staff()
        {
            StaffNumber = string.Empty;
        }
    }
}
