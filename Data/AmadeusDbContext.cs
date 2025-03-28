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


    // Método que se ejecuta al momento de crear el modelo de la base de datos
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Destination>().ToTable("destination").HasKey(u => u.Id);

        modelBuilder.Entity<Destination>().Property(u => u.Id).IsRequired().HasColumnName("id");
        modelBuilder.Entity<Destination>().Property(u => u.Combination).IsRequired().HasColumnName("combination");
        modelBuilder.Entity<Destination>().Property(u => u.FirstCityId).IsRequired().HasColumnName("first_city_id");
        modelBuilder.Entity<Destination>().Property(u => u.SecondCityId).IsRequired().HasColumnName("second_city_id");

        modelBuilder.Entity<City>().ToTable("city").HasKey(u => u.Id);

        modelBuilder.Entity<City>().Property(u => u.Id).IsRequired().HasColumnName("id");
        modelBuilder.Entity<City>().Property(u => u.Description).IsRequired().HasColumnName("description");
    }

}