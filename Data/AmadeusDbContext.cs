using Microsoft.EntityFrameworkCore;
using AmadeusApi.Models;


namespace AmadeusApi.Data
{
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
        public DbSet<Destination> Destinations { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relaciones Destination -> City (dos FK a la misma tabla)
            modelBuilder.Entity<Destination>()
                .HasOne(d => d.FirstCity)
                .WithMany()
                .HasForeignKey(d => d.FirstCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Destination>()
                .HasOne(d => d.SecondCity)
                .WithMany()
                .HasForeignKey(d => d.SecondCityId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}