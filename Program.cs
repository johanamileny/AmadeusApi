using AMADEUSAPI.Data;
using AMADEUSAPI.Repositories;
using AMADEUSAPI.Services;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);



// Agregar los servicios de la aplicación
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<QuestionService>();
builder.Services.AddScoped<QuestionOptionService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<CityService>(); 



// Agregar los repositorios de la aplicación
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<QuestionRepository>();
builder.Services.AddScoped<QuestionOptionRepository>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<CityRepository>(); 




builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization(); 

app.MapControllers(); 

app.Run();
