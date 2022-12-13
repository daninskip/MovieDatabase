using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using MovieDatabaseDTO;


namespace MovieDatabaseRepository
{

    internal class ApplicationDBContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }

        private static IConfigurationRoot _configuration;

        public ApplicationDBContext()
        {

        }

        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("MovieManager");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }

    }
}
