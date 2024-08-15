// See https://aka.ms/new-console-template for more information

using Faker;
using System.Runtime.CompilerServices;

var data = new DataGenerator();
var bookBuilder = new RecordBuilder<Book>(Author => new Book
{
    BookId = Guid.NewGuid(),
    Title = data.CreateRandomString().Trim(),
    PublishedYear = data.CreateRandomYear(),
});


var books = bookBuilder.BuildMany(10);


foreach (var book in books)
{
    Console.WriteLine($"BookId: {book.BookId}, PublishedYear: {book.PublishedYear}, Title: {book.Title}");
}


public class RecordBuilder<TEntity> where TEntity: Book
{
    private readonly Func<int, TEntity> _recordGenerator;

    public RecordBuilder(Func<int, TEntity> recordGenerator)
    {
        _recordGenerator = recordGenerator;
    }

    public RecordBuilder<TEntity> WithAuthor(Guid authorId)
    {
        var data = new DataGenerator();
        var author = new Author()
        {
            AuthorId = authorId,
            Bio = data.CreateRandomString(),
            Name = NameFaker.Name(),
        };
        return this;
    }

    public IEnumerable<TEntity> BuildMany(int numberOfRecords)
    {
        var records = new List<TEntity>();
        for (int i = 0; i < numberOfRecords; i++)
        {
            records.Add(_recordGenerator(i));
        }
        return records;
    }
}
