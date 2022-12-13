using MovieDatabaseRepository;
using MovieDatabaseDTO;
using MovieDatabaseDomain;

MovieInteractor _movieInteractor = new MovieInteractor();

bool searchAgain = true;
ShowSearchMenu();


while (searchAgain)
{
    Console.WriteLine();
    Console.WriteLine("Would you like to perform another search? (y/n)");
    string searchAgainInput = Console.ReadLine();
    if (searchAgainInput == "y")
    {
        searchAgain = true;
        ShowSearchMenu();
    }
    else
    {
        searchAgain = false;
        Environment.Exit(0);
    }
}

void ShowSearchMenu()
{
    Console.WriteLine("How would you like to search the database:");
    Console.WriteLine("1 - Search by movie title");
    Console.WriteLine("2 - Search by genre");
    
    
    int searchInput = int.Parse(Console.ReadLine());
    switch (searchInput)
    {
        case 1:
            {
                Console.WriteLine("Enter a movie title to find:");
                string titleInput = Console.ReadLine();
                DisplayMovieInformation(titleInput);
                break;
            }
        case 2:
            {
                Console.WriteLine("Enter a genre to search by:");
                string genreInput = Console.ReadLine();
                DisplayByGenre(genreInput);
                break;
            }
    }
}

void LoadStartUpData()
{
    foreach (Movie movie in _movieInteractor.BuildItemCollection())
    {
        if (_movieInteractor.AddNewItem(movie) == true)
        {
            Console.WriteLine($"{movie.Title} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{movie.Title} was NOT added to the database.");
        }
    }
}

void DisplayByGenre(string genreInput)
{
    Console.WriteLine();
    Console.WriteLine($"The following {genreInput} movies are in the database:");
    foreach (Movie movie in _movieInteractor.GetMoviesByGenre(genreInput))
    {
        Console.WriteLine($"{ movie.Title}");
    }
}

void DisplayMovieInformation(string titleInput)
{
    Console.WriteLine();
    Console.WriteLine($"Searching for movie titled {titleInput}");
    bool doesMovieExist = _movieInteractor.GetMovieIfExists(titleInput, out Movie returnedMovie);
    if (doesMovieExist)
    {
        Console.WriteLine($"Title: {returnedMovie.Title} - Genre: {returnedMovie.Genre} - Runtime: {returnedMovie.Runtime} minutes.");
    }
    else
    {
        Console.WriteLine("That movie is not in the database");
    }
}