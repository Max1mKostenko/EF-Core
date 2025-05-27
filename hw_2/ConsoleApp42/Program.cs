using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleApp40
{
    class Student
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public double? AvgGradeOfYear { get; set; }
        public string? SubjectMinAvgGrade { get; set; }
        public string? SubjectMaxAvgGrade { get; set; }
    }

    class MyDbContext : DbContext
    {
        public DbSet<Student> Students => Set<Student>();

        private readonly string _connection_string;

        public MyDbContext(string con_string)
        {
            _connection_string = con_string;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection_string);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;
                                        Database=E-diary;
                                        Encrypt=False;
                                        Trusted_Connection=True;
                                        TrustServerCertificate=True";

            using var context = new MyDbContext(connectionString);

            if (!context.Students.Any())
            {
                context.Students.Add(new Student
                {
                    FullName = "Ivan Petrenko",
                    AvgGradeOfYear = 4.25,
                    SubjectMinAvgGrade = "Math",
                    SubjectMaxAvgGrade = "History"
                });
                context.SaveChanges();
            }

            var students = context.Students.ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.FullName}, " +
                                  $"Avg: {student.AvgGradeOfYear}, MinSubj: {student.SubjectMinAvgGrade}, MaxSubj: {student.SubjectMaxAvgGrade}");
            }
        }
    }
}
