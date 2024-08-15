// See https://aka.ms/new-console-template for more information

public class Author
{
    public Guid AuthorId { get; set; }
    public string Name { get; set; } = null!;
    public string Bio { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = null!;
}
