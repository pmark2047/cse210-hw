using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");


        Console.Write("What's Ur Age? ");

        var ageString = Console.ReadLine();
        Console.WriteLine($"My age is {ageString}.");

        int age = int.Parse(ageString);
        if (age < 18)
        {
            Console.WriteLine("You're a minor");
        }
    }
}