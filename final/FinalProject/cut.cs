public class Cut: Diet{
    public override void CalculateCalories()
    {
        double cal = Math.Round(bmr * activityLvl * 0.8, 0);
        this.calories = (int)cal;
    }
}