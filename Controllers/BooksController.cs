using LibraryWebApi.Dtos;
using LibraryWebApi.Requests;
using LibraryWebApi.Responses;
using LibraryWebApi.Service.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase // Контроллер для работы с продуктами
{
    private readonly IBookService _bookService; // Сервис для работы с продуктами

    public BooksController(IBookService bookService) // Конструктор контроллера для работы с продуктами (внедрение зависимости) 
    {
        _bookService = bookService; // Инициализация сервиса для работы с продуктами
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilteredProducts([FromQuery] BookFilterRequest filterRequest) // Получение отфильтрованных продуктов
    {
        var products = await _bookService.GetFilteredProductsAsync(filterRequest); // Получение отфильтрованных продуктов
        return Ok(new ApiResponse<List<BookDto>>(products, "Фильтрация выполнена успешно.")); // Возврат результата
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateBookRequest createRequest) // Создание продукта
    {
        if (!ModelState.IsValid) // Если модель не прошла валидацию
        {
            return BadRequest(new ApiResponse<string>("Ошибка валидации данных.")); // Возвращаем ошибку
        }

        var product = await _bookService.CreateAsync(createRequest); // Создание продукта
        return CreatedAtAction(nameof(GetFilteredProducts), null, new ApiResponse<BookDto>(product, "Продукт успешно создан.")); // Возврат результата
    }
}
