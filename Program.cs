using Microsoft.EntityFrameworkCore;
using Amadeus.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar los controladores
builder.Services.AddControllers();


// Agregar los endpoints
builder.Services.AddEndpointsApiExplorer();


// Agregar los servicios de Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Amadeus", Version = "v1" });
});

// Agregar los servicios de la base de datos
builder.Services.AddDbContext<AmadeusDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Agregar los servicios de la aplicación
builder.Services.AddScoped<UserService>();
 
 
// Agregar los repositorios de la aplicación
builder.Services.AddScoped<UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();