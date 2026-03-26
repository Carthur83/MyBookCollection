
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Business.Dtos;

public class AddBookForm
{
    [Required(ErrorMessage = "Titel krävs")]
    public string Title { get; set; } = null!;
    public string? Author { get; set; } = null!;
    public string? Condition { get; set; }
    public string? Type { get; set; }
    public string? Edition { get; set; }
    public int? PublishedYear { get; set; }
    public string? Description { get; set; }
    public string? ImageFileName { get; set; }
}
