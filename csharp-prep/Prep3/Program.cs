using System;
using System.Formats.Asn1;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("\nPlease give a positive integer: ");

        int maxInt = int.Parse(Console.ReadLine());

        float guess = -5;

        Random randomGenerator = new Random();
        int answer = randomGenerator.Next(1, maxInt);
        Console.WriteLine();
        do
        {
            Console.Write($"Pick a number between 1 and {maxInt}: ");

            guess = float.Parse(Console.ReadLine());

            if (guess == (answer - 1) || guess == (answer + 1))
            {
                Console.WriteLine("     Burning Hot!!!");
            }
            else if ((guess <= (answer - 2) && guess > (answer - 3)) || guess >= (answer + 2) && guess < (answer + 3))
            {
                Console.WriteLine("     Hot!");
            }
            else if ((guess <= (answer - 3) && guess > (answer - 4)) || guess >= (answer + 3) && guess < (answer + 4))
            {
                Console.WriteLine("     Warmer!");
            }
            else if (guess == answer)
            {
                Console.Write("     Correct!");
            }
            else if (guess < answer)
            {
                Console.WriteLine("     Colder (Higher)");
            }
            else if (guess > answer)
            {
                Console.WriteLine("     Colder (Lower)");
            }

        } while (guess != answer);


    }
}