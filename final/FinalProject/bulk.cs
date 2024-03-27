public class Bulk: Diet{
    public override void CalculateCalories()
    {
        double cal = Math.Round(bmr * activityLvl * 1.2, 0);
        this.calories = (int)cal;
    }
}