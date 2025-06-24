using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp25
{
    class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
    }

    class MyDbContext : DbContext
    {
        public DbSet<Game> Games => Set<Game>();

        private readonly string connectionString;

        public MyDbContext(string conString)
        {
            connectionString = conString;
            Database.EnsureCreated(); 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=Multimedia;Encrypt=False;Trusted_Connection=True;TrustServerCertificate=True";

            using var context = new MyDbContext(connectionString);

            while (true)
            {
                Console.WriteLine("\n--- Game Menu ---");
                Console.WriteLine("1. Add a game");
                Console.WriteLine("2. Show all games");
                Console.WriteLine("3. Update a game");
                Console.WriteLine("4. Delete a game");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddGame(context);
                        break;
                    case "2":
                        ShowAllGames(context);
                        break;
                    case "3":
                        UpdateGame(context);
                        break;
                    case "4":
                        DeleteGame(context);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddGame(MyDbContext context)
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            Console.Write("Enter genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter release year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter rating (0.0 - 10.0): ");
            double rating = double.Parse(Console.ReadLine());

            Console.Write("Is the game available (yes/no): ");
            bool isAvailable = Console.ReadLine().ToLower() == "yes";

            var game = new Game
            {
                Title = title,
                Genre = genre,
                ReleaseYear = year,
                Rating = rating,
                IsAvailable = isAvailable
            };

            context.Games.Add(game);
            context.SaveChanges();
            Console.WriteLine("Game added successfully.");
        }

        static void ShowAllGames(MyDbContext context)
        {
            var games = context.Games.ToList();
            Console.WriteLine("\n--- Games List ---");
            foreach (var game in games)
            {
                Console.WriteLine($"ID: {game.Id}, Title: {game.Title}, Genre: {game.Genre}, Year: {game.ReleaseYear}, Rating: {game.Rating}, Available: {game.IsAvailable}");
            }
        }

        static void UpdateGame(MyDbContext context)
        {
            Console.Write("Enter ID of the game to update: ");
            int id = int.Parse(Console.ReadLine());

            var game = context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            Console.Write("New title (leave empty to keep current): ");
            string title = Console.ReadLine();
            if (!string.IsNullOrEmpty(title)) game.Title = title;

            Console.Write("New genre (leave empty to keep current): ");
            string genre = Console.ReadLine();
            if (!string.IsNullOrEmpty(genre)) game.Genre = genre;

            Console.Write("New release year (leave empty to keep current): ");
            string yearStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(yearStr)) game.ReleaseYear = int.Parse(yearStr);

            Console.Write("New rating (leave empty to keep current): ");
            string ratingStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(ratingStr)) game.Rating = double.Parse(ratingStr);

            Console.Write("Is the game available? (yes/no/leave empty): ");
            string availStr = Console.ReadLine().ToLower();
            if (availStr == "yes") game.IsAvailable = true;
            else if (availStr == "no") game.IsAvailable = false;

            context.SaveChanges();
            Console.WriteLine("Game updated.");
        }

        static void DeleteGame(MyDbContext context)
        {
            Console.Write("Enter ID of the game to delete: ");
            int id = int.Parse(Console.ReadLine());

            var game = context.Games.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                Console.WriteLine("Game not found.");
                return;
            }

            context.Games.Remove(game);
            context.SaveChanges();
            Console.WriteLine("Game deleted.");
        }
    }
}
