
public class Simple: Goal
{
    public bool status;

    public override string DisplayGoal()
    {
        if (this.status == false){
            return base.DisplayGoal();
        }else{
            return $"[X] {goalName} ({goalDesc})";
        }
    }

    public override string Export()
    {
        return $"{this.GetType().Name}:{goalName},{goalDesc},{point},{status}";
    }

    public void CreateGoal(string goalName, string goalDesc, int point, bool status)
    {
        this.goalName = goalName;
        this.goalDesc = goalDesc;
        this.point = point;
        this.status = status;
    }

    public override int CompleteGoal()
    {
        this.status = true;
        return base.CompleteGoal();
    }

    public override bool Completed()
    {
        return this.status;
    }
}