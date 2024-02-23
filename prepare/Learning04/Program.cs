using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment Assignment1 = new Assignment();
        Assignment1.SetStudentName("Samuel Bennett");
        Assignment1.SetTopic("Multiplication");

        Console.WriteLine(Assignment1.GetSummary());

        MathAssignment Assignment2 = new MathAssignment();
        Assignment2.SetStudentName("Roberto Rodriguez");
        Assignment2.SetTopic("Fractions");
        Assignment2.SetTextbookSection("Section 7.3");
        Assignment2.SetProblems("Problems 8-19");

        Console.WriteLine(Assignment2.GetSummary());
        Console.WriteLine(Assignment2.GetHomeworkList());

        WritingAssignment Assignment3 = new WritingAssignment();
        Assignment3.SetStudentName("Mary Waters");
        Assignment3.SetTopic("European History");
        Assignment3.SetTitle("The Causes of World War II");

        Console.WriteLine(Assignment3.GetSummary());
        Console.WriteLine(Assignment3.GetWritingInfo());
    }
}