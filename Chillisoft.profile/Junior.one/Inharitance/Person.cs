namespace Junior.one.Inharitance
{
    public class Person
    {
       public string? Name { get; set; }
       public string? Surname { get; set; }
       public DateOnly DateOfBirth { get; set; }
       public bool Gender { get; set; }
       public string? CellPhoneNumber { get; set; }

       public virtual void Travels()
       {

       }
       public virtual void CalculateUsingDateOfBirth()
       {

       }
    }
}
