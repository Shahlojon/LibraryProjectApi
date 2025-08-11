namespace LibraryWebApi.Dtos;

// Path: Dtos/UserDto.cs - данные которые передаются в ответе
public class UserDto 
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
