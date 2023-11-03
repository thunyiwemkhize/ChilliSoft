using System.Text.Json;

namespace Junior.one.NullableGenerics
{
    public class NullableValueWriter<T> where T : struct
    {
        private T? _value;

        public NullableValueWriter(T? value)
        {
            _value = value;
        }

        public T? Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void DisplayValue()
        {
            if (_value.HasValue)
            {
                Console.WriteLine($"The value is: {JsonSerializer.Serialize(_value.Value)}");
            }
            else
            {
                Console.WriteLine("The value is null");
            }
        }
    }
}
