using System;
using System.Formats.Asn1;
using System.Numerics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please give a positive integer: ");

        int maxInt = int.Parse(Console.ReadLine());

        float guess = -5;

        Random randomGenerator = new Random();
        int answer = randomGenerator.Next(1, maxInt);

        do
        {
            Console.Write($"Pick a number between 1 and {maxInt}: ");

            guess = float.Parse(Console.ReadLine());

            if (guess < answer)
            {
                Console.WriteLine("     Too low!");
            }
            else if (guess > answer)
            {
                Console.WriteLine("     Too high!");
            }
            else
            {
                Console.Write("     Correct!");
            }

        } while (guess != answer);


    }
}