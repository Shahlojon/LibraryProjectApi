using LibraryWebApi.Dtos;
using LibraryWebApi.Requests;

namespace LibraryWebApi.Service.UserService;

public interface IUserService // Интерфейс сервиса для работы с пользователями
{
    Task<List<UserDto>> GetAllUsersAsync(); // Получение всех пользователей
    Task<UserDto> LoginAsync(LoginRequest request); // Вход пользователя
    Task<UserDto> RegisterAsync(RegisterUserRequest request); // Регистрация пользователя
}