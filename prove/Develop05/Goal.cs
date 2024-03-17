public class Goal
    //This can also be the template for Eternal Goals
{
    public string goalName;
    public string goalDesc;
    public int point;

    public virtual void CreateGoal()
    {
        Console.WriteLine("What is the name of your goal? ");
        this.goalName = Console.ReadLine();
        Console.WriteLine("What is a short description of it? ");
        this.goalDesc = Console.ReadLine();

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("What is the amount of point associated with this goal? ");
            string input = Console.ReadLine();
            loop = !int.TryParse(input, out this.point);
            if (loop){
                Console.WriteLine("Please enter the points as a whole number. ");
            }
        }
    }

    public void CreateGoal(string goalName, string goalDesc, int point)
    {
        this.goalName = goalName;
        this.goalDesc = goalDesc;
        this.point = point;
    }

    public virtual string DisplayGoal()
    {
        return $"[ ] {goalName} ({goalDesc})";
    }

    public virtual string Export()
    {
        return $"{this.GetType().Name}:{goalName},{goalDesc},{point}";
    }

    public virtual int CompleteGoal()
    {
        return point;
    }

    public virtual bool Completed()
    {
        return false;
    }
}