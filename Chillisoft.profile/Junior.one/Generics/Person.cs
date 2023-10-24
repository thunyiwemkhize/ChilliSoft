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
    

   
}
