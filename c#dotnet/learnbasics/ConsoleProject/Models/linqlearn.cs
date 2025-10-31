namespace ConsoleProject.Models
{
    internal class Game
    {
        public required string Title { get; set; }
        public string? Genre { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public float Price { get; set; }

        private List<Game> GetGames()
        {
            var games = new List<Game>
    {
    new Game { Title = "The Legend of Zelda", Genre = "Adventure", ReleaseYear = 1986, Rating = 9.1, Price = 60.25F },
    new Game { Title = "Super Mario Bros.", Genre = "Platformer", ReleaseYear = 1985, Rating = 9.3, Price = 50 },
    new Game { Title = "Elden Ring", Genre = "Adventure", ReleaseYear = 2022, Rating = 9.8, Price = 50 },
    new Game { Title = "Stardew Valley", Genre = "Platformer", ReleaseYear = 2016, Rating = 9.2, Price = 15 },
    new Game { Title = "Tetris", Genre = "Puzzle", ReleaseYear = 1984, Rating = 8.9, Price = 10 }
    };
            return games;
        }
        public void learLinq()
        {
            var games = GetGames();

            var titles = games.Select(g => g.Title);
            foreach (string t in titles)
            {
                Console.Write($"{t}, ");
            }
            Console.WriteLine("\n-----Titles Printed Above-----");

            var filterGenre = games.Where(g => g.Genre == "Adventure");
            foreach (Game genre in filterGenre)
            {
                Console.Write($"{genre.Title}, ");
            }
            Console.WriteLine("\n-----Titles with Genre Adventure filtered above-----");

            var gamesAfter2016Exists = games.Any(rl => rl.ReleaseYear > 2016);
            Console.WriteLine($"Any Game exists after 2016 : {gamesAfter2016Exists} \n-----Any clause returning a bool filtered above-----");

            var sortedGamesByReleaseYear = games.OrderByDescending(r => r.ReleaseYear);
            foreach (Game sort in sortedGamesByReleaseYear)
            {
                Console.Write($"{sort.Title} | {sort.ReleaseYear} , ");
            }
            Console.WriteLine("\n-----Sorted by descending on release year-----");

            var gameWith9P2rating = games.First(r => r.Rating == 9.2);
            Console.WriteLine($"First Game with 9.2 ratings : {gameWith9P2rating.Title} \n-----Game with 9.2 rating-----");

            var sumOfAllGames = games.Sum(g => g.Price);
            Console.WriteLine($"Float of all games : {sumOfAllGames} \n-----Float of all games-----");

            var groupAllGames = games.GroupBy(gp => gp.Genre);
            foreach (var grp in groupAllGames)
            {
                Console.WriteLine($"{grp.Key} :");
                foreach (var game in grp)
                {
                    Console.WriteLine($"{game.Title}");
                }
            }
            Console.WriteLine($"-----Group By of all games-----");

            var budgetGames = games.Where(x => x.Genre == "Adventure" && x.Rating > 9.3)
            .OrderBy(x => x.Rating)
            .Select(x => $"{x.Title} - {x.Genre}").ToList();

            foreach (var bg in budgetGames)
            {
                Console.WriteLine($"Budget Games : {bg} \n-----Method Chaining BudgetGames-----");
            }

            
        }   

     
    }


}

