using ProductWebApi.Dtos;
using ProductWebApi.Requests;

namespace ProductWebApi.Service.ProductService;

public interface IProductService // Интерфейс сервиса для работы с продуктами
{
    Task<List<ProductDto>> GetFilteredProductsAsync(ProductFilterRequest filterRequest); // Получение отфильтрованных продуктов
    Task<ProductDto> CreateAsync(CreateProductRequest createRequest); // Создание продукта
}
