using System.Globalization;

namespace Junior.one.Inharitance
{
    public class Person
    {
       public string? Name { get; set; }
       public string? Surname { get; set; }
       public DateTime DateOfBirth { get; set; } 
       public bool Gender { get; set; }
       public string? CellPhoneNumber { get; set; }

       public virtual void Travels()
       {
            
       }
       public virtual void CalculateUsingDateOfBirth()
       {

       }

       public DateTime GenerateDateOfBirth(int nagetiveAge)
       {
           return DateTime.Parse(DateTime.Now.AddYears(nagetiveAge).ToString(CultureInfo.InvariantCulture));
       }
    }
}
