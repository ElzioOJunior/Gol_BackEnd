using GOL.Database.Mappings;
using GOL.Domain.Entities.Airplane;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GOL.Database.Context
{
    public class GolContext : DbContext
    {
        public DbSet<Airplane> Airplanes { get; set; }


        public GolContext(DbContextOptions<GolContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AirplaneMapping());

            base.OnModelCreating(modelBuilder);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // define the database to use
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"), o => o.UseRowNumberForPaging());
            }


        }
    }
}
