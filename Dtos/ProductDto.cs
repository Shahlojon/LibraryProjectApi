namespace ProductWebApi.Dtos;

// Path: Dtos/ProductDto.cs - данные которые передаются в ответе
public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
