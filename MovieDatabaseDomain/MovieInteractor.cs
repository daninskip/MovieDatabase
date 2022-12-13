using MovieDatabaseDTO;
using MovieDatabaseRepository;

namespace MovieDatabaseDomain
{
    public class MovieInteractor
    {
        private MovieRepository _repository;

        public MovieInteractor()
        {
            _repository = new MovieRepository();
        }

        public List<Movie> BuildItemCollection()
        {
            List<Movie> initialItems = new List<Movie>();
            initialItems.Add(new Movie() { Title = "Avatar", Genre = "Sci-Fi", Runtime = 162 });
            initialItems.Add(new Movie() { Title = "Avengers: Endgame", Genre = "Action", Runtime = 181 });
            initialItems.Add(new Movie() { Title = "Titanic", Genre = "Drama", Runtime = 194 });
            initialItems.Add(new Movie() { Title = "Star Wars: Episode VII - The Force Awakens", Genre = "Sci-Fi", Runtime = 138 });
            initialItems.Add(new Movie() { Title = "Avengers: Infinity War", Genre = "Action", Runtime = 149 });
            initialItems.Add(new Movie() { Title = "Spider-Man: No Way Home", Genre = "Action", Runtime = 148 });
            initialItems.Add(new Movie() { Title = "Jurassic World", Genre = "Action", Runtime = 124 });
            initialItems.Add(new Movie() { Title = "The Lion King", Genre = "Animation", Runtime = 118 });
            initialItems.Add(new Movie() { Title = "The Avengers", Genre = "Action", Runtime = 143 });
            initialItems.Add(new Movie() { Title = "Furious 7", Genre = "Action", Runtime = 137 });
            initialItems.Add(new Movie() { Title = "Top Gun : Maverick", Genre = "Action", Runtime = 130 });
            initialItems.Add(new Movie() { Title = "Frozen II ", Genre = "Animation", Runtime = 163 });
            initialItems.Add(new Movie() { Title = "Avengers: Age of Ultron", Genre = "Action", Runtime = 141 });
            initialItems.Add(new Movie() { Title = "Black Panther", Genre = "Action", Runtime = 134 });
            initialItems.Add(new Movie() { Title = "Harry Potter and the Deathly Hallows: Part 2", Genre = "Fantasy", Runtime = 130 });

            return initialItems;
        }
        public bool AddNewItem(Movie itemToAdd)
        {
            if (string.IsNullOrEmpty(itemToAdd.Title) || string.IsNullOrEmpty(itemToAdd.Genre))
            {
                throw new ArgumentException("Name and Genre must contain valid text.");
            }
            return _repository.AddItem(itemToAdd);
        }
        public List<Movie> GetMoviesByGenre(string genreInput)
        {
            return _repository.GetMoviesByGenre(genreInput);
        }

        public bool GetMovieIfExists(string titleInput, out Movie itemToReturn)
        {
            Movie item = _repository.GetMovieByTitle(titleInput);
            itemToReturn = item;
            return itemToReturn != null;
        }
    }
}