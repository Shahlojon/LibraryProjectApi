using ProductWebApi.Dtos;
using ProductWebApi.Models;
using ProductWebApi.Requests;

namespace ProductWebApi.Service.ProductService;

public class ProductService : IProductService // Реализация интерфейса сервиса для работы с продуктами
{
    private readonly List<Product> _products = new(); // Листь для хранение данных о продуктах

    public async Task<List<ProductDto>> GetFilteredProductsAsync(ProductFilterRequest filterRequest) // Получение отфильтрованных продуктов
    {
        // Пример простой фильтрации (в реальных проектах это будет через базу данных)
        var filteredProducts = _products // Фильтрация продуктов
            .Where(p => string.IsNullOrEmpty(filterRequest.Name) || p.Name.Contains(filterRequest.Name, StringComparison.OrdinalIgnoreCase)) // Фильтрация по имени
            .Where(p => !filterRequest.MinPrice.HasValue || p.Price >= filterRequest.MinPrice.Value) // Фильтрация по минимальной цене
            .Where(p => !filterRequest.MaxPrice.HasValue || p.Price <= filterRequest.MaxPrice.Value) // Фильтрация по максимальной цене
            .ToList(); // Преобразование в лист

        return filteredProducts.Select(p => new ProductDto { Id = p.Id, Name = p.Name, Price = p.Price }).ToList(); // Преобразование в лист Dto
    }

    public async Task<ProductDto> CreateAsync(CreateProductRequest createRequest) // Создание продукта
    {
        var product = new Product // Создание продукта
        {
            Id = Guid.NewGuid(), // Генерация Id
            Name = createRequest.Name, // Присвоение имени
            Price = createRequest.Price // Присвоение цены
        };
        _products.Add(product); // Добавление продукта в лист

        return new ProductDto // Преобразование в Dto
        {
            Id = product.Id, // Присвоение Id
            Name = product.Name, // Присвоение имени
            Price = product.Price // Присвоение цены
        };
    }
}