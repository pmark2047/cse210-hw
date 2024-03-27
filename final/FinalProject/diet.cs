using System.Dynamic;
using System.IO.Pipes;
using System.Linq.Expressions;
using Microsoft.VisualBasic;

public class Diet{
    public double height ; //cm
    public double weight ; //kg
    public string gender ;
    public int age ;
    public double bmr ;
    public double activityLvl;
    public int calories;

    public void GetData(){
        bool loop = true;
        int intFeet = 0;
        int intInch;
        int intLbs;
        int intAge;
        while (loop)
        {
            Console.WriteLine("What is your height? ");
            Console.Write("Feet: ");
            if (int.TryParse(Console.ReadLine(), out intFeet) && intFeet >= 4 && intFeet <= 8 && intFeet != 0)
            {
                loop = false;
            }else if (intFeet != 0 && (intFeet < 4 || intFeet > 8)){
                Console.WriteLine("\nPlease enter a valid height. ");
            }else{
                Console.WriteLine("\nPlease enter your height in just feet. inches will be input after. ");
            }
        }
        while (!loop)
        {
            Console.Write("Inches: ");
            if (int.TryParse(Console.ReadLine(), out intInch) && intInch >= 0 && intInch < 12)
            {
                loop = true;
                this.height = ((intFeet * 12) + intInch) * 2.54;
            }else if (loop == true && (intInch < 4 || intInch > 8)){
                Console.WriteLine("\nPlease enter your height in inches (0-11). ");
            }else{
                Console.WriteLine("\nPlease enter your height in inches as a whole number. ");
            }   
        }
        while (loop)
        {
            Console.WriteLine("\nWhat is your weight in pounds? ");
            if (int.TryParse(Console.ReadLine(), out intLbs))
            {
                this.weight = intLbs * 0.453592;
                loop = false;
            }else if (loop = true || intLbs <= 0){
                Console.WriteLine("\nInvalid entry. Please enter your weight in pounds. ");
                loop = true;
            }else{
                Console.WriteLine("\nPlease enter your weight in pounds as a whole number. ");
            }
        }
        while (!loop)
        {
            Console.WriteLine("\nWhat is your gender (m/f)? ");
            this.gender = Console.ReadLine().ToUpper();
            if (gender == "M" || gender == "F")
            {
                loop = true;
            }else{
                Console.WriteLine("\nInvalid Response, please enter either m or f. ");
            }
        }
        while (loop)
        {
            Console.WriteLine("\nHow old are you? ");
            if (int.TryParse(Console.ReadLine(), out intAge) && intAge > 0)
            {
                this.age = intAge;
                loop = false;
            }else if (intAge <= 0){
                Console.WriteLine("\nInvalid entry. Please enter your age. ");
            }else{
                Console.WriteLine("\nPlease enter your Age as a whole number. ");
            }
        }
    }
    public void CalculateBmr(){
        bool loop = true;
        while (loop)
        {
            Console.WriteLine("    What is your activityLvl level? ");
            Console.WriteLine("1.) Sedentary (little to no exercise)");
            Console.WriteLine("2.) Light Activity (light exercise 1-3 days a week)");
            Console.WriteLine("3.) Moderate Activity (moderate exercise 3-5 days a week)");
            Console.WriteLine("4.) Very Active (strenuous exercise 6-7 days a week)");
            Console.WriteLine("5.) Extra Active (very hard exercise and physically demanding job)");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice < 6 && choice > 0)
            {
                loop = false;
                if (choice == 1){
                    this.activityLvl = 1.2;
                }else if(choice == 2){
                    this.activityLvl = 1.375;
                }else if(choice == 3){
                    this.activityLvl = 1.55;
                }else if(choice == 4){
                    this.activityLvl = 1.725;
                }else{
                    this.activityLvl = 1.9;
                }
            }else{
                Console.WriteLine("\nInvalid Entry. Please enter a choice from the list given. \n");
            }
        }
        if (gender == "M"){
            this.bmr = (10 * weight) + (6.25 * height) - (5 * age) + 5;
        }else{
            this.bmr = (10 * weight) + (6.25 * height) - (5 * age) -161;
        }
    }
    public virtual void CalculateCalories(){
        double cal = Math.Round(bmr * activityLvl, 0);
        this.calories = (int)cal;
    }
    public string Export(){
        return($"{this.height},{this.weight},{this.gender},{this.age},{this.bmr},{activityLvl},{this.calories},{this.GetType().Name}");
    }
    public void Import(string import){
        var parts = import.Split(',');
        this.height = double.Parse(parts[0]);
        this.weight = double.Parse(parts[1]);
        this.gender = parts[2];
        this.age = int.Parse(parts[3]);
        this.bmr = double.Parse(parts[4]);
        this.activityLvl = double.Parse(parts[5]);
        this.calories = int.Parse(parts[6]);
    }
}