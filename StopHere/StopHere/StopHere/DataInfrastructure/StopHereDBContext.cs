using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace DataInfrastructure
{
    public class StopHereDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Fabia\Downloads\StopHereDiaDaFormatura\StopHereDiaDaFormatura\StopHereDb.mdf;Integrated Security=True;Connect Timeout=5", (x => x.EnableRetryOnFailure(5)));
            base.OnConfiguring(optionsBuilder);
        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LegalPerson> LegalPersons { get; set; }
        public DbSet<NaturalPerson> NaturalPersons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Parking> Parkings { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
