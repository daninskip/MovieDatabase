using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieDatabaseDTO;


namespace MovieDatabaseRepository
{
    public class MovieRepository
    {
        private IConfiguration _configuration;
        private DbContextOptionsBuilder<ApplicationDBContext> _optionsBuilder;

        public MovieRepository()
        {
            BuildOptions();
        }
        private void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDBContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MovieManager"));
        }
        public bool AddItem(Movie itemToAdd)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                //determine if item exists
                Movie existingItem = db.Movies.FirstOrDefault(x => x.Title.ToLower() == itemToAdd.Title.ToLower());

                if (existingItem == null)
                {
                    // doesn't exist, add it
                    db.Movies.Add(itemToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Movie> GetMoviesByGenre(string genreInput)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.Where(x => x.Genre == genreInput).ToList();
            }
        }

        public Movie GetMovieByTitle(string titleInput)
        {
            using (ApplicationDBContext db = new ApplicationDBContext(_optionsBuilder.Options))
            {
                return db.Movies.FirstOrDefault(x => x.Title == titleInput);
            }
        }
    }
}