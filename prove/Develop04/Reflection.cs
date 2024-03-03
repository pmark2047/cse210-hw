class Reflection : Activity
{
    private int[] _questionsChosen = {};
    private string[] _prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

   private string[] _reflection = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
   };
   public Reflection()
   {
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _name = "Reflecting Activity";
   }
    public string getPrompt()
    {
        int index = _generator.Next(0,_prompts.Length);
        return _prompts[index];
    }

    public string getQuestion()
    {
        int index = _generator.Next(0,_reflection.Length);
        int exists = Array.IndexOf(_questionsChosen,index);

        while (exists > -1)
        {
            index = _generator.Next(0,_reflection.Length);
            exists = Array.IndexOf(_questionsChosen,index);
        }

        _questionsChosen.Append(index);
        return _reflection[index];
    }

    public void run()
    {
        Console.Clear();
        displayStartMessage();
        setDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        displayAnimation();
        
        Console.WriteLine("\nConsider the following prompt:\n");
        string prompt = getPrompt();
        Console.WriteLine($"--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("You may begin in: ");
        Console.Write("3");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Write("2");
        Thread.Sleep(1000);
        Console.Write("\b \b"); 
        Console.Write("1");
        Thread.Sleep(1000);
        Console.Write("\b \b");
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(_duration);

        while (startTime < stopTime)
        {
            Console.Write(getQuestion());
            Console.Write(" ");
            displayAnimation();
            Console.WriteLine();
            startTime = DateTime.Now;
        }

        Console.WriteLine();
        displayEndMessage();
    }
}