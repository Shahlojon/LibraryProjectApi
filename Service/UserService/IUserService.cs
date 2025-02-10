using ProductWebApi.Dtos;
using ProductWebApi.Requests;

namespace ProductWebApi.Service.UserService;

public interface IUserService // Интерфейс сервиса для работы с пользователями
{
    Task<List<UserDto>> GetAllUsersAsync(); // Получение всех пользователей
    Task<UserDto> LoginAsync(LoginRequest request); // Вход пользователя
    Task<UserDto> RegisterAsync(RegisterUserRequest request); // Регистрация пользователя
}