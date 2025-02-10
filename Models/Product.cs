using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Models;
//Доменный модель
public class Product
{
    [Required]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
