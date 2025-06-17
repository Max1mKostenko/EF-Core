using System;
using System.Threading.Tasks;

namespace ConsoleApp47
{
    internal class Program
    {
        static long factorial_result = 1;
        static int digit_count = 0;
        static int digit_sum = 0;

        static void Main(string[] args)
        {
            int number = 6;

            Parallel.Invoke(
                () => CalculateFactorial(number),
                () => CountDigits(number),
                () => SumDigits(number),
                () => PrintResults(number) 
            );
        }

        static void CalculateFactorial(int n)
        {
            factorial_result = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial_result *= i;
            }
        }

        static void CountDigits(int n)
        {
            digit_count = n.ToString().Length;
        }

        static void SumDigits(int n)
        {
            digit_sum = 0;
            while (n > 0)
            {
                digit_sum += n % 10;
                n /= 10;
            }
        }

        static void PrintResults(int number)
        {
            Task.Delay(100).Wait();

            Console.WriteLine($"Number: {number}");
            Console.WriteLine($"Factorial: {factorial_result}");
            Console.WriteLine($"Digit count: {digit_count}");
            Console.WriteLine($"Digit sum: {digit_sum}");
        }
    }
}
