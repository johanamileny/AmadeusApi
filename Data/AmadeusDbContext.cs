using Microsoft.EntityFrameworkCore;
using Amadeus.Models;
using AMADEUSAPI.Models;

public class AmadeusDbContext : DbContext
{
    // Constructor que recibe las opciones de configuración de la base de datos
    public AmadeusDbContext(DbContextOptions<AmadeusDbContext> options) : base(options)
    {
    }

    // Propiedades que representa las tablas de la base de datos
    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<City> Cities { get; set; }
}