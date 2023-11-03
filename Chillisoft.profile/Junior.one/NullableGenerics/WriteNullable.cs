namespace Junior.one.NullableGenerics
{
    public class WriteNullable
    {
        public void write()
        {
            var author = new Author() { Age = 45, Name = "Sandile"};

            var autherWriter = new NullableValueWriter<Author>(author);
            autherWriter.DisplayValue();

            new NullableValueWriter<Author>(null).DisplayValue();
        }
    }
    public struct Author
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
