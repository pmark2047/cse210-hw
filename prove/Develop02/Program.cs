using System;
using System.Threading.Tasks.Dataflow;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Hello Develop02 World!");
        Run();
    }

    static public string GetPrompt() 
    {
        List<string> prompts = new List<string>
        {
            "What was the best part of my day?",
            "What did I accomplish today?",
            "Who was the most interesting person I interacted with today?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I most grateful for today?"
        };
        Random Random = new Random();
        var randIndex = Random.Next(prompts.Count);

        return prompts[randIndex];
    }

    static public void Run() 
    {
        Journal journal = new Journal();

        bool keepGoing = true;
        Console.Clear();
        while (keepGoing) 
        {
            
            var selection = ShowMenu();

            if (selection == 1) {
                //write
                var prompt = GetPrompt();
                Console.WriteLine(prompt);
                var response = Console.ReadLine();
                string date = DateTime.Now.ToShortDateString();
                var entry = new Entry(response, prompt, date);
                journal.AddEntry(entry);
                Console.Clear();

            } else if (selection == 2) {
                //display
                Console.Clear();
                journal.Display();

            } else if (selection == 3) {
                //load
                Console.WriteLine("What is the filename?");
                string fileName = Console.ReadLine();
                journal = LoadFromFile(fileName);
                Console.Clear();


            } else if (selection == 4) {
                //save
                SaveToFile(journal);
                Console.Clear();

            } else if (selection == 5) {
                //quit
            keepGoing = false;
            }
        }
    }

    static int ShowMenu()
    {
        Console.WriteLine("Select Option: \n 1. Add Entry \n 2. Display Entry \n 3. Load \n 4. Save \n 5. Quit");
        string input = Console.ReadLine();
        return int.Parse(input);
    }

    static public void SaveToFile(Journal journal) 
    {
        Console.WriteLine("What would you like to name the file?");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            string [] lines = journal.Export();
            foreach (string line in lines)
            {
                outputFile.WriteLine(line);
            }
        }
    }

    static public Journal LoadFromFile(string fileName) 
    {
        string [] lines = System.IO.File.ReadAllLines(fileName);
        Journal journal = new Journal();
        foreach (string line in lines)
        {
            var entry = new Entry(line);
            journal.AddEntry(entry);
        }
        return journal;

        
    }
}