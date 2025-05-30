using _123Vago.Repositorio;
using _123Vago.Servico;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("HotelsDB"));
builder.Services.AddScoped<IHotelRepositorio, HotelRepositorio>();
builder.Services.AddScoped<IHotelServico, HotelServico>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
     .AllowAnyHeader()
     .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowLocalhost4200");

app.MapControllers();

app.Run();
