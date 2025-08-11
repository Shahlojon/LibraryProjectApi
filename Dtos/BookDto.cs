namespace LibraryWebApi.Dtos;

// Path: Dtos/ProductDto.cs - данные которые передаются в ответе
public class BookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
