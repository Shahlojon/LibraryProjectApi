using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Requests;
//// Получение данных от клиента к серверу. Входные данные
public class LoginRequest // Запрос на вход
{
    [Required]  // Обязательное поле
    [EmailAddress] // Проверка на соответствие email
    public string Email { get; set; }

    [Required] // Обязательное поле
    public string Password { get; set; }
}
