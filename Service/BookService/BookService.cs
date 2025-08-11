using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using LibraryWebApi.Requests;
using Mapster;

namespace LibraryWebApi.Service.BookService;

public class BookService : IBookService // Реализация интерфейса сервиса для работы с продуктами
{
    private readonly List<Book> _books = new(); // Листь для хранение данных о продуктах

    public async Task<List<BookDto>> GetFilteredProductsAsync(BookFilterRequest filterRequest) // Получение отфильтрованных продуктов
    {
        // Пример простой фильтрации (в реальных проектах это будет через базу данных)
        var filteredBooks = _books // Фильтрация продуктов
            .Where(p => string.IsNullOrEmpty(filterRequest.Title) || p.Title.Contains(filterRequest.Title, StringComparison.OrdinalIgnoreCase)) // Фильтрация по имени
            .Where(p => string.IsNullOrEmpty(filterRequest.Author) || p.Title.Contains(filterRequest.Author, StringComparison.OrdinalIgnoreCase)) // Фильтрация по имени
            .ToList(); // Преобразование в лист

        return filteredBooks.Select(p => new BookDto { Id = p.Id, Title = p.Title, Author = p.Author }).ToList(); // Преобразование в лист Dto
    }

    public async Task<BookDto> CreateAsync(CreateBookRequest createRequest) // Создание продукта
    {
        var book = new Book // Создание продукта
        {
            Id = Guid.NewGuid(), // Генерация Id
            Title = createRequest.Title, // Присвоение имени
            Author = createRequest.Author, // Присвоение автора
            ISBN = createRequest.ISBN, // Присвоение автора
        };
        _books.Add(book); // Добавление продукта в лист

        return book.Adapt<BookDto>();
    }
}