using System.Globalization;

namespace Junior.one.Inharitance

{
    public class Person
    {
       public Guid Id { get; set; }
       public string FullName { get; set; }

       public Person()
       {
           FullName = string.Empty;
       }
    }
}
