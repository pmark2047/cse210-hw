using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep4 World!\n");

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        float number = 1;
        List<float> numbers = new List<float>();
        while (number != 0)
        {
            Console.Write("Enter number: ");
            number = float.Parse(Console.ReadLine());
            numbers.Add(number);
        }

        float sum = numbers.Sum();
        float avg = sum/numbers.Count;
        float max = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {max}");
    }
}