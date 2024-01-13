using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? ");
        string grade_from_user = Console.ReadLine();

        float grade = float.Parse(grade_from_user);

        Console.WriteLine();

        string letter = "";


        if (grade >= 90)
        {
            string letter = "A";
        }
        else if (grade >=80)
        {
            string letter = "B";
        }
        else if (grade >= 70)
        {
            string letter = "C";
        }
        else if (grade >= 60)
        {
            string letter = "D";
        }
        else
        {
            string letter = "F";
        }

        if (letter == "A" || letter == "B" || letter == "C")
        {
            Console.WriteLine($"You passed the class with a {letter}!");
        }
        else
        {
            Console.WriteLine($"You failed the class with a {letter}... better luck next time.");
        }
    }
}