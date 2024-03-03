class Activity
{
    protected int _duration;
    protected string _description;
    protected string _name;
    protected Random _generator = new Random();
    private List<string> animationStrings = new List<string>() { "|", "/", "-", "\\", "|" };
    public void displayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Start breathing activity");
        Console.WriteLine("   2. Start reflecting activity");
        Console.WriteLine("   3. Start listing activity");
        Console.WriteLine("   4. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    public int getUserChoice()
    {
        int choice;
        choice = int.Parse(Console.ReadLine());
        while (choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice, please try again.\n");
            Console.Write("Select a choice from the menu: ");
            try {
                choice = int.Parse(Console.ReadLine());
            } catch {}
        }

        return choice;
    }

    public void displayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    public void displayEndMessage()
    {
        Console.WriteLine("Well Done!");
        displayAnimation();
        Console.WriteLine($"\nYou completed another {_duration} seconds of the {_name}.");
        displayAnimation();
    }

    public void displayAnimation()
    {
        for (int i = 0; i < 2; i++)
        {
            foreach (string symbol in animationStrings)
            {
                Console.Write(symbol);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }
    }

    public void setDuration()
    {
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
    }

}