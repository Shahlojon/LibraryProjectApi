using LibraryWebApi.Dtos;
using LibraryWebApi.Requests;

namespace LibraryWebApi.Service.BookService;

public interface IBookService // Интерфейс сервиса для работы с продуктами
{
    Task<List<BookDto>> GetFilteredProductsAsync(BookFilterRequest filterRequest); // Получение отфильтрованных продуктов
    Task<BookDto> CreateAsync(CreateBookRequest createRequest); // Создание продукта
}
