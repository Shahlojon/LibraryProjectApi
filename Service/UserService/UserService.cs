using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using LibraryWebApi.Requests;

namespace LibraryWebApi.Service.UserService;

public class UserService : IUserService
{
    private readonly List<User> _users = new(); // Пока без БД храним в памяти

    public async Task<UserDto> RegisterAsync(RegisterUserRequest request) // Регистрация пользователя
    {
        return await Task.Run(() => // Симуляция асинхронной операции
        {
            // Проверяем, есть ли уже пользователь с таким email
            if (_users.Any(u => u.Email == request.Email)) // Если пользователь с таким email уже есть
                throw new Exception("Пользователь с таким email уже зарегистрирован"); // Выбрасываем исключение

            // Создаём пользователя
            var user = new User // Создаём пользователя
            {
                Id = _users.Count + 1, // Симуляция автоинкремента
                FirstName = request.FirstName, // Присваиваем имя
                LastName = request.LastName,  // Присваиваем фамилию
                Email = request.Email,  // Присваиваем email
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) // Хешируем пароль
            };

            _users.Add(user); // Добавляем пользователя в список

            return new UserDto // Возвращаем пользователя
            {
                Id = user.Id, // Присваиваем Id
                FirstName = user.FirstName, // Присваиваем имя
                LastName = user.LastName, // Присваиваем фамилию
                Email = user.Email // Присваиваем email
            };
        });
    }

    public async Task<UserDto> LoginAsync(LoginRequest request)
    {
        return await Task.Run(() =>
        {
            var user = _users.FirstOrDefault(u => u.Email == request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                throw new Exception("Неверный email или пароль");

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        });
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        return await Task.Run(() =>
        {
            return _users.Select(u => new UserDto
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email
            }).ToList();
        });
    }
}

