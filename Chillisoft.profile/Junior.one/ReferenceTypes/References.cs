namespace Junior.one.ReferenceTypes
{
    public class References
    {
        public class AuthorClass
        {
            public string Name ;
            public AuthorClass(string name) 
            {
                Name = name;
            }
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
            var object1 = new AuthorClass("Thunyiwe");
            var object2 = object1;
            var object3 = object2;
            
            object3.Name = "class: ref object 3 value after change";

            Console.WriteLine(object1.Name);
            Console.WriteLine(object2.Name);
            Console.WriteLine(object3.Name);
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
