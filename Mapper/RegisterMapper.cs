using LibraryWebApi.Dtos;
using LibraryWebApi.Models;
using Mapster;

namespace LibraryWebApi.Mapper;

public class RegisterMappers : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Добавьте другие маппинги сюда
        config.NewConfig<Book, BookDto>();
        config.NewConfig<BookDto, Book>();
    }
}
