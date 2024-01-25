using System;

public class Resume
{
    public string name;

    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
    
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Job:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}