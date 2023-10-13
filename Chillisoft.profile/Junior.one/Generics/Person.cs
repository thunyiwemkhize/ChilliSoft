using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Generics
{
    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class Implementation
    {
        private readonly ICollectAndDisplayPersonInformation _test;

        public Implementation(ICollectAndDisplayPersonInformation test)
        {
            _test = test;
        }

        public ArrayList GetAll(ArrayList persoArrayList)
        {
            return _test.RequestPersonInformation(persoArrayList);
        }

        public Person getById(int age)
        {
           return _test.GetPerson(age);
        }

        
    }
    public class CollectAndDisplayPersonInformation: ICollectAndDisplayPersonInformation
    {

        public ArrayList RequestPersonInformation(ArrayList persoArrayList)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Add person name");
                var personName = Console.ReadLine();
                Console.WriteLine("Add person age");
                var age =int.Parse(Console.ReadLine()!);
                persoArrayList.Add(new Person
                {
                    Age = age,
                    Name = personName
                });
            }

            return persoArrayList;
        }

        public Person GetPerson(int id)
        {
            var arrayList = new List<Person>();
            arrayList.Add(new Person
            {
                Name = "Juan",
                Age = 26
            });
            arrayList.Add(new Person
            {
                Name = "Sara",
                Age = 31
            });
            arrayList.Add(new Person
            {
                Name = "Carlos",
                Age = 23
            });
            var res = arrayList.FirstOrDefault(p => p.Age == id);
            if(res == null)
                throw new DirectoryNotFoundException("User Not found");
            return res;
        }

        private readonly ArrayList PersonArrayList;

        public CollectAndDisplayPersonInformation()
        {
            PersonArrayList = new ArrayList();
        }

    }

    public interface ICollectAndDisplayPersonInformation
    {
        ArrayList RequestPersonInformation(ArrayList persoArrayList);
        Person GetPerson(int id);
    }
}
