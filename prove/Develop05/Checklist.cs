
public class Checklist: Goal
{
    public int complete;
    public int progress = 0;

    public int bonus;

    public override void CreateGoal()
    {
        base.CreateGoal();

        bool loop = true;
        while (loop)
        {
            Console.WriteLine("How many times does this goal need to be accomplished for a bonus? ");
            string input = Console.ReadLine();
            loop = !int.TryParse(input, out this.complete);
            if (loop){
                Console.WriteLine("Please enter the number as a whole number. ");
            }
        }
        loop = true;
        while (loop)
        {
            Console.WriteLine($"What is the bonus for accomplishing it {this.complete} times? ");
            string input = Console.ReadLine();
            loop = !int.TryParse(input, out this.bonus);
            if (loop){
                Console.WriteLine("Please enter the number as a whole number. ");
            }
        }
    }

    public override string DisplayGoal()
    {
        if (progress != complete){
            return $"[ ] {goalName} ({goalDesc}) -- Currently completed: {progress}/{complete}";
        }else{
            return $"[X] {goalName} ({goalDesc})";
        }
    }
    public override string Export()
    {
        return $"{this.GetType().Name}:{goalName},{goalDesc},{point},{bonus},{complete},{progress}";
    }

    public void CreateGoal(string goalName, string goalDesc, int point, int bonus, int complete, int progress)
    {
        this.goalName = goalName;
        this.goalDesc = goalDesc;
        this.point = point;
        this.complete = complete;
        this.progress = progress;
        this.bonus = bonus;
    }
    public override int CompleteGoal()
    {
        this.progress += 1;
        if (progress != complete){
            return base.CompleteGoal();
        }else{
            return bonus;
        }
    }

    public override bool Completed()
    {
        return progress == complete;
    }
}