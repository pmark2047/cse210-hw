using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        int response = 0;
        int points = 0;
        List<Goal>goals = new List<Goal>();

        while (response !=6)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Create New Goal");
            Console.WriteLine("   2. List Goals");
            Console.WriteLine("   3. Save Goals");
            Console.WriteLine("   4. Load Goals");
            Console.WriteLine("   5. Record Event");
            Console.WriteLine("   6. Quit");

            string input = Console.ReadLine();
            bool isInt = int.TryParse(input, out response);

            if (!isInt || response <=0 || response >= 7){
                Console.WriteLine("Invalid Response, please enter an option from the list given.");
            }else if (response == 1){
                bool loop = true;
                while (loop)
                {
                    Console.WriteLine("The Types of Goals are:");
                    Console.WriteLine("     1. Simple Goal");
                    Console.WriteLine("     2. Eternal Goal");
                    Console.WriteLine("     3. Checklist Goal");
                    Console.WriteLine("Which type of goal would you like to create? ");

                    input = Console.ReadLine();
                    isInt = int.TryParse(input, out response);
                    if (!isInt || response <=0 || response >= 7){
                    Console.WriteLine("Invalid Response, please enter an option from the list given.");
                    }else if (response == 1){
                        //create Simple
                        Simple goal = new Simple();
                        goal.CreateGoal();
                        Console.WriteLine("Simple Goal Created");
                        goals.Add(goal);
                        loop = false;
                    }else if (response == 2){
                        //create Eternal
                        Goal goal = new Goal();
                        goal.CreateGoal();
                        Console.WriteLine("Eternal Goal Created");
                        goals.Add(goal);
                        loop = false;
                    }else{
                        //create Checklist
                        Checklist goal = new Checklist();
                        goal.CreateGoal();
                        Console.WriteLine("Checklist Goal Created");
                        goals.Add(goal);
                        loop = false;
                    }
                    
                }
            Console.WriteLine("Press Enter to Continue. ");
            Console.ReadLine();

            }else if (response == 2){
                if (goals.Count() == 0)
                {
                    Console.WriteLine("No goals to display. Please create a goal or load goals from file. ");
                    Thread.Sleep(2000);
                }
                else
                {
                    ListGoals(goals, points);
                    Console.WriteLine("Press enter to continue. ");
                    Console.ReadLine();
                }

            }else if (response == 3){

                SaveToFile(points, goals);
                Console.WriteLine("File saved successfully. \nPress enter to continue. ");
                Console.ReadLine();

            }else if (response == 4){

                points = LoadFromFile(points, goals);
                Console.WriteLine("File loaded successfully. \nPress enter to continue. ");
                Console.ReadLine();

            }else if (response == 5){
                int choice = -1;
                int incomplete = 0;
                bool empty = false;
                List<Goal> finish = new List<Goal>();
                while ((0 >= choice || choice > incomplete) && !empty)
                {
                    foreach (Goal goal in goals)
                    {
                        if (!goal.Completed())
                        {
                            incomplete += 1;
                        }
                    }
                    if (incomplete > 0)
                    {
                        Console.WriteLine("Select a choice from the menu: ");
                        foreach (Goal goal in goals)
                        {
                            if (!goal.Completed())
                            {
                                finish.Add(goal);
                                Console.WriteLine($"{finish.IndexOf(goal)+1}. {goal.DisplayGoal()}");
                            }
                        }
                        int.TryParse(Console.ReadLine(), out choice);
                    }
                    else
                    {
                        Console.WriteLine("No available goals to complete. Please create a goal first.");
                        empty = true;
                    }
                }
                if (!empty)
                {
                    var completed = goals[goals.IndexOf(finish[choice-1])];
                    int point = completed.CompleteGoal();
                    if (completed.GetType().Name == "Checklist" && completed.Completed())
                    {
                        Console.WriteLine($"Checklist goal completed you've earned a bonus of {point} points!");
                    }else{
                        Console.WriteLine($"Goal Completed! You earned {point} Points!");
                    }
                    points += point;
                }
                Console.WriteLine("Press enter to continue. ");
                Console.ReadLine();

            }else{

            }
        }
    }
    static public void SaveToFile(int points, List<Goal> goals) 
    {
        Console.WriteLine("What would you like to name the file?");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(points);
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.Export());
            }
        }
    }

    static public int LoadFromFile(int points, List<Goal> goals)
    {
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("What is the filename for the goal file? ");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName))
            {
                string [] lines = System.IO.File.ReadAllLines(fileName);
                goals.Clear();
                foreach (string line in lines)
                {
                    if (line == lines[0])
                    {
                        points = int.Parse(line);
                    }else{
                        var parts = line.Split(':', ',');
                        
                        if (parts[0] == "Goal"){
                            Goal goal = new Goal();
                            goal.CreateGoal(parts[1], parts[2], int.Parse(parts[3]));
                            goals.Add(goal);
                        }else if (parts[0] == "Simple"){
                            Simple goal = new Simple();
                            goal.CreateGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                            goals.Add(goal);
                        }else{
                            Checklist goal = new Checklist();
                            goal.CreateGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                            goals.Add(goal);
                        }loop = false;
                    }
                }
            }
        }
        return points;
    }

    static public void ListGoals(List<Goal> goals, int points)
    {
        Console.WriteLine($"Total Points {points}");
        Console.WriteLine("The goals are:");
                foreach( Goal goal in goals){
                    Console.WriteLine($"{goals.IndexOf(goal)+1}. {goal.DisplayGoal()}");
                }
    }
}