using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        float number = PromptUserNumber();
        float square = SquareNumber(number);
        DisplayResult(name, square);
    }
    static void DisplayWelcome()
    {
        Console.WriteLine("\n\n\nWelcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        var name = Console.ReadLine();
        return name;
    }

    static float PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        float number = float.Parse(Console.ReadLine());
        return number;
    }

    static float SquareNumber(float number)
    {
        float square = (number * number);
        return square;
    }

    static void DisplayResult(string name, float square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}\n\n\n");
    }
}