using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Requests;
// Получение данных от клиента к серверу. Входные данные
public class ProductFilterRequest // Запрос на фильтрацию продуктов
{
    public string? Name { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Минимальная цена должна быть положительным числом.")] // Проверка на положительное число
    public decimal? MinPrice { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "Максимальная цена должна быть положительным числом.")] // Проверка на положительное число
    public decimal? MaxPrice { get; set; }
}
