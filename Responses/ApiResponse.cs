namespace LibraryWebApi.Responses;

public class ApiResponse<T>  // Обобщенный класс
{
    public bool Success { get; set; } // Успешно ли выполнен запрос
    public T Data { get; set; }  // Данные
    public string Message { get; set; } // Сообщение

    public ApiResponse(T data, string message = null) // Конструктор
    {
        Success = true; // По умолчанию true
        Data = data; // Присваиваем данные
        Message = message; // Присваиваем сообщение
    }

    public ApiResponse(string message) // Конструктор
    {
        Success = false; // По умолчанию false
        Message = message; // Присваиваем сообщение
    }
}
