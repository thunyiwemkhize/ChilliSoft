// See https://aka.ms/new-console-template for more information

using Junior.one.Inharitance;
using Junior.one.Inharitence;

Person[] personObj = { new Staff(), new Student()};
foreach (var person in personObj)
{
    person.CalculateUsingDateOfBirth();
    person.Travels();
} 
