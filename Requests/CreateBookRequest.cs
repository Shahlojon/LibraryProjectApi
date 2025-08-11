using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Requests;
// Получение данных от клиента к серверу. Входные данные
public class CreateBookRequest // Запрос на создание продукта
{
    [Required(ErrorMessage = "Название продукта обязательно.")] // Обязательное поле
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Название должно быть от 3 до 100 символов.")] // Проверка на длину строки
    public string Title { get; set; }
    [Required(ErrorMessage = "ISBN книги обязательно.")] // Обязательное поле
    public string ISBN { get; set; }

    [Required(ErrorMessage = "Автор обязателен")] // Обязательное поле
    public string Author { get; set; }
}
