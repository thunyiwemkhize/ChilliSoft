// See https://aka.ms/new-console-template for more information

public class Publisher
{
    public Guid PublisherId { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public ICollection<Book> Books { get; set; } = null!;
}