namespace Junior.one.NullableGenerics
{
    public class WriteNullable
    {
        public void write()
        {
            var author = new Author() { Age = 45, Name = "Sandile"};
            new NullableValueWriter<Author>(author).DisplayValue();

            var bob = author;
            bob.Name = "Thunyiwe";
            new NullableValueWriter<Author>(bob).DisplayValue();

            new NullableValueWriter<Author>(null).DisplayValue();
        }
    }
    public struct Author
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
