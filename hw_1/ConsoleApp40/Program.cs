using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace ConsoleApp40
{
    class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Color { get; set; }
        public int? Caloric_content { get; set; }
        public string Type { get; set; }
    }

    class MyDbContext : DbContext
    {
        public DbSet<Market> Markets => Set<Market>();

        string connectionString;

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
            string connectionString = @"Server=localhost\SQLEXPRESS;
                                    Database=VegetablesAndFruits;
                                    Encrypt=False;
                                    Trusted_Connection=True;
                                    TrustServerCertificate=True";

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Connect to database");
                Console.WriteLine("2. Exit");
                Console.WriteLine("3. Add item");
                Console.Write("Enter choice: ");
                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    try
                    {
                        using (MyDbContext context = new MyDbContext(connectionString))
                        {
                            Console.WriteLine("Connection successful!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Connection failed: {ex.Message}");
                    }
                }
                else if (choice == "2")
                {
                    break;
                }

                else if (choice == "3")
                {
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter type (Vegetable/Fruit): ");
                    string type = Console.ReadLine();
                    Console.Write("Enter color: ");
                    string color = Console.ReadLine();
                    Console.Write("Enter caloric content: ");
                    int calories = int.Parse(Console.ReadLine());

                    using (MyDbContext context = new MyDbContext(connectionString))
                    {
                        var item = new Market
                        {
                            Name = name,
                            Type = type,
                            Color = color,
                            Caloric_content = calories
                        };
                        context.Markets.Add(item);
                        context.SaveChanges();
                        Console.WriteLine("Item added.");
                    }
                }


                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }

}
  
