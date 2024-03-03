class Breathing : Activity
{
    public Breathing()
    {
        _description = "This activity wil help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _name = "Breathing Activity";
    }

    public void run()
    {
        Console.Clear();
        displayStartMessage();
        setDuration();

        Console.Clear();
        Console.WriteLine("Get ready...");
        displayAnimation();

        DateTime timeStart = DateTime.Now;
        DateTime stopTime = timeStart.AddSeconds(_duration);
        while (timeStart < stopTime)
        {
            Console.Write("Breathe in...");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b\n");

            Console.Write("Breathe out...");
            Console.Write("4");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("3");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("2");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            Console.Write("1");
            Thread.Sleep(1000);
            Console.Write("\b \b\n\n");

            timeStart = DateTime.Now;
        }

        displayEndMessage();
    }
}