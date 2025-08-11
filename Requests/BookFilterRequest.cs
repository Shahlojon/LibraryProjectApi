using System.ComponentModel.DataAnnotations;

namespace LibraryWebApi.Requests;
// Получение данных от клиента к серверу. Входные данные
public class BookFilterRequest // Запрос на фильтрацию продуктов
{
    public string? Title { get; set; }

    public string? Author { get; set; }
}
