using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using LibraryWebApi.Requests;
using LibraryWebApi.Responses;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public class BooksV2Controller:ControllerBase
{
    private static readonly List<Book> _books = new(); // Сервис для работы с продуктами

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilteredProducts([FromQuery] BookFilterRequest filterRequest) // Получение отфильтрованных продуктов
    {
        // Пример простой фильтрации (в реальных проектах это будет через базу данных)
        var filteredBooks = _books // Фильтрация продуктов
            .Where(p => string.IsNullOrEmpty(filterRequest.Title) || p.Title.Contains(filterRequest.Title, StringComparison.OrdinalIgnoreCase)) // Фильтрация по имени
            .Where(p => string.IsNullOrEmpty(filterRequest.Author) || p.Title.Contains(filterRequest.Author, StringComparison.OrdinalIgnoreCase)) // Фильтрация по имени
            .ToList(); // Преобразование в лист

        // Получение отфильтрованных продуктов
        return Ok(new ApiResponse<List<BookDto>>(filteredBooks.Select(p => new BookDto { Id = p.Id, Title = p.Title, Author = p.Author }).ToList(), "Фильтрация выполнена успешно.")); // Возврат результата
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateBookRequest createRequest) // Создание продукта
    {
        var book = new Book // Создание продукта
        {
            Id = Guid.NewGuid(), // Генерация Id
            Title = createRequest.Title, // Присвоение имени
            Author = createRequest.Author, // Присвоение автора
            ISBN = createRequest.ISBN, // Присвоение автора
        };
        _books.Add(book); // Добавление книги в лист
        // Создание книги
        return CreatedAtAction(nameof(GetFilteredProducts), null, new ApiResponse<BookDto>(book.Adapt<BookDto>(), "Продукт успешно создан.")); // Возврат результата
    }
}