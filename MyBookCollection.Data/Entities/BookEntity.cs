namespace MyBookCollection.Data.Entities;

public class BookEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string? Author { get; set; } = null!;
    public string? Condition { get; set; } = null!;
    public string? Type { get; set; }
    public string? Edition { get; set; }
    public int? PublishedYear { get; set; }
    public string? Description { get; set; }
    public string? ImageFileName { get; set; }
}
