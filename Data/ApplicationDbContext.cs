using Microsoft.EntityFrameworkCore;
using AMADEUSAPI.Models;

namespace AMADEUSAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

             modelBuilder.Entity<Destination>().ToTable("destination") .HasKey(u => u.Id);

            modelBuilder.Entity<Destination>().Property(u => u.Id).IsRequired().HasColumnName("id");
            modelBuilder.Entity<Destination>().Property(u => u.Combination).IsRequired().HasColumnName("combination");
            modelBuilder.Entity<Destination>().Property(u => u.FirstCityId).IsRequired().HasColumnName("first_city_id");
            modelBuilder.Entity<Destination>().Property(u => u.SecondCityId).IsRequired().HasColumnName("second_city_id");
            
             modelBuilder.Entity<City>().ToTable("city") .HasKey(u => u.Id);

            modelBuilder.Entity<City>().Property(u => u.Id).IsRequired().HasColumnName("id");
            modelBuilder.Entity<City>().Property(u => u.Description).IsRequired().HasColumnName("description");
        }
    }
}