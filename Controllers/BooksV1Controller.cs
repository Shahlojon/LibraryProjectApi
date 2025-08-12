using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using LibraryWebApi.Requests;
using LibraryWebApi.Responses;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[ApiController]
[Route("api/v1/books")]
public class BooksV1Controller:ControllerBase
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

        // Получение отфильтрованных книг
        var filteredBooksDto = filteredBooks.Select(p => new BookDto { Id = p.Id, Title = p.Title, Author = p.Author }).ToList(); // Преобразование в DTO
        return Ok(new ApiResponse<List<BookDto>>(filteredBooksDto, "Фильтрация выполнена успешно.")); // Возврат результата
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
        var bookDto = new BookDto()
        {
            Id = book.Id, // Присвоение Id
            Title = book.Title, // Присвоение имени
            Author = book.Author, // Присвоение автора
        };
        return CreatedAtAction(nameof(GetFilteredProducts), null, 
            new ApiResponse<BookDto>(bookDto, 
            "Продукт успешно создан.")
        ); // Возврат результата
    }
}