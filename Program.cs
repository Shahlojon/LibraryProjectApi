using ProductWebApi.Service.ProductService;

var builder = WebApplication.CreateBuilder(args); // Создаем новое приложение

// Add services to the container.

builder.Services.AddControllers(); // Добавляем контроллеры
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // Добавляем генерацию документации
builder.Services.AddSwaggerGen();  // Добавляем генерацию документации
builder.Services.AddSingleton<IProductService, ProductService>(); // Добавляем сервис для работы с продуктами в контейнер зависимостей. Добавляем зависимость ProductService с интерфейсом IProductService
var app = builder.Build(); // Строим приложение

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())  // Если приложение в режиме разработки
{
    app.UseSwagger(); // Используем Swagger
    app.UseSwaggerUI(); // Используем Swagger UI
}


app.UseHttpsRedirection(); // Используем перенаправление на https

app.UseAuthorization(); // Используем авторизацию

app.MapControllers();  // Используем контроллеры
 
app.Run(); // Запускаем приложение
