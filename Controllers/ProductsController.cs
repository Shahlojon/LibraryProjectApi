using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Dtos;
using ProductWebApi.Requests;
using ProductWebApi.Responses;
using ProductWebApi.Service.ProductService;

namespace ProductWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase // Контроллер для работы с продуктами
{
    private readonly IProductService _productService; // Сервис для работы с продуктами

    public ProductsController(IProductService productService) // Конструктор контроллера для работы с продуктами (внедрение зависимости) 
    {
        _productService = productService; // Инициализация сервиса для работы с продуктами
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilteredProducts([FromQuery] ProductFilterRequest filterRequest) // Получение отфильтрованных продуктов
    {
        var products = await _productService.GetFilteredProductsAsync(filterRequest); // Получение отфильтрованных продуктов
        return Ok(new ApiResponse<List<ProductDto>>(products, "Фильтрация выполнена успешно.")); // Возврат результата
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest createRequest) // Создание продукта
    {
        if (!ModelState.IsValid) // Если модель не прошла валидацию
        {
            return BadRequest(new ApiResponse<string>("Ошибка валидации данных.")); // Возвращаем ошибку
        }

        var product = await _productService.CreateAsync(createRequest); // Создание продукта
        return CreatedAtAction(nameof(GetFilteredProducts), null, new ApiResponse<ProductDto>(product, "Продукт успешно создан.")); // Возврат результата
    }
}
