using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Requests;
// Получение данных от клиента к серверу. Входные данные
public class CreateProductRequest // Запрос на создание продукта
{
    [Required(ErrorMessage = "Название продукта обязательно.")] // Обязательное поле
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов.")] // Проверка на длину строки
    public string Name { get; set; }

    [Required(ErrorMessage = "Цена обязательна.")] // Обязательное поле
    [Range(0.01, 10000, ErrorMessage = "Цена должна быть в диапазоне от 0.01 до 10000.")] // Проверка на диапазон чисел
    public decimal Price { get; set; }
}
