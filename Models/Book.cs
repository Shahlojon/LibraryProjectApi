using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Models;
//Доменный модель
public class Book
{
    [Required]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Author { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
