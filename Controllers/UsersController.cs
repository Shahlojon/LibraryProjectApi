using LibraryWebApi.Dtos;
using LibraryWebApi.Requests;
using LibraryWebApi.Responses;
using LibraryWebApi.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApi.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(UserService userService) : ControllerBase // Контроллер для работы с пользователями
{
    private readonly UserService _userService = userService; // Сервис для работы с пользователями (внедрение зависимости) 

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserRequest request) // Регистрация пользователя
    {
        try // Обработка исключений
        {
            var user = await _userService.RegisterAsync(request); // Регистрация пользователя
            return Ok(new ApiResponse<UserDto>(user, "Пользователь успешно зарегистрирован")); // Возврат результата
        }
        catch (Exception ex) // Обработка исключений
        {
            return BadRequest(new ApiResponse<string>(ex.Message)); // Возврат ошибки
        }
    }

    [HttpPost("login")] // Вход пользователя
    public async Task<IActionResult> Login([FromBody] LoginRequest request) // Вход пользователя
    {
        try // Обработка исключений
        { 
            var user = await _userService.LoginAsync(request); // Вход пользователя
            return Ok(new ApiResponse<UserDto>(user, "Успешный вход")); // Возврат результата
        }
        catch (Exception ex) // Обработка исключений
        {
            return Unauthorized(new ApiResponse<string>(ex.Message)); // Возврат ошибки
        }
    }

    [HttpGet] // Получение всех пользователей
    public async Task<IActionResult> GetAllUsers() // Получение всех пользователей
    {
        var users = await _userService.GetAllUsersAsync(); // Получение всех пользователей
        return Ok(new ApiResponse<List<UserDto>>(users, "Список пользователей")); // Возврат результата
    }
}

