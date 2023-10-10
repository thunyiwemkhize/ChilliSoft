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

    public class CollectAndDisplayPersonInformation: ICollectAndDisplayPersonInformation
    {

        public ArrayList RequestPersonInformation(ArrayList persoArrayList)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Add person name");
                var personName = Console.ReadLine();
                Console.WriteLine("Add person age");
                var age = Console.ReadLine();
            }

            return persoArrayList;
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
    }
}
