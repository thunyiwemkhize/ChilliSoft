using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Junior.one.Delegates
{
    public class FuncsAndActions
    {
        public static int CalculateAvarage(List<int> numbers)
        {
            return numbers.Sum()/numbers.Count;
        }
        public static int CalculateMaximum(List<int> numbers)
        {
            return numbers.Max();
        }
    }

    public class DeelegateFunc
    {
        public void WriteAvarage(Func<List<int>,int> avarageFunction,Action<string> resultWriter, List<int> numbers)
        {
            int avarage = avarageFunction(numbers);
            resultWriter($"Avarage is: {avarage}");
        }

        public void WriteMAx(Func<List<int>,int> maxFunction, Action<string> resultWriter, List<int> numbers)
        {
            int maxNumber = maxFunction(numbers);
            resultWriter($"Max is: {maxNumber}");
        }
    }


}
