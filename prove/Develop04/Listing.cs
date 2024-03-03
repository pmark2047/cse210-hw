class Listing : Activity
{
    private string[] _prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    
    public Listing()
    {
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _name = "Listing Activity";
    }

    public string getPrompt()
    {
        int index = _generator.Next(0,_prompts.Length);
        return _prompts[index];
    }

    public void run()
    {
        Console.Clear();
        displayStartMessage();
        setDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        displayAnimation();

        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"--- {getPrompt()} ---");
        Console.WriteLine("You may begin in: ");
        Console.Write("3");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("2");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("1");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.WriteLine();

        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(_duration);
        string response;
        int numResponses = 0;
        while (startTime < stopTime)
        {
            response = Console.ReadLine();
            numResponses++;
            startTime = DateTime.Now;
        } 

        Console.WriteLine($"You listed {numResponses} items!");
        displayEndMessage();
    }
}