// See https://aka.ms/new-console-template for more information

public class Book
{
    public Guid BookId { get; set; }
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public Guid PublisherId { get; set; }
    public Publisher Publisher { get; set; } = null!;
}
