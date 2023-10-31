using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Statics
{
    public class StaticVariables
    {
        public static string name = "mode1";
        public string nonStatic = "mode2";
        public void write()
        {
            Console.WriteLine(name);
            Console.WriteLine(nonStatic);
        }
    }

    public class DifferenceBetweenStaticAndNonStaticVariableWritter
    {
        public void write()
        {
            Console.WriteLine($"Current value for the static variable is {StaticVariables.name}");
            StaticVariables.name = "thunyiwe";
            var staticFeild = new StaticVariables()
            {
                nonStatic ="non static"
            };
            Console.WriteLine(StaticVariables.name);
            Console.WriteLine(staticFeild.nonStatic);
        }
    }
}
