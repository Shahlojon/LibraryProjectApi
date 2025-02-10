using System.ComponentModel.DataAnnotations;

namespace ProductWebApi.Requests;
// Получение данных от клиента к серверу. Входные данные
public class RegisterUserRequest // Запрос на регистрацию пользователя
{
    [Required] // Обязательное поле
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [EmailAddress] // Проверка на соответствие email
    public string Email { get; set; }

    [Required]
    [MinLength(6)]  // Минимальная длина пароля (6 символов)
    public string Password { get; set; }
}
