using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.ReferenceTypes
{
    public class References
    {
        public class AuthorClass
        {
            public string name = "Thunyiwe";
        }
        private struct AuthorStruct
        {
            public string Name;
            public AuthorStruct(string name)
            {
                Name = name;
            }
        }
        public void ReferencesWritter()
        {
            var object1 = new AuthorClass();
            var object2 = object1;
            var object3 = object2;
            
            object3.name = "class: ref object 3 value after change";

            Console.WriteLine(object1.name);
            Console.WriteLine(object2.name);
            Console.WriteLine(object3.name);
        }
        public void ValueTypeWriter()
        {
            var object1 = new AuthorStruct("Dumisani");

            var object2 = object1;
            var object3 = object2;

            object3.Name = "struct: Value object 3 value after change";
            Console.WriteLine(object1.Name);
            Console.WriteLine(object2.Name);
            Console.WriteLine(object3.Name);
        }
    }
}
