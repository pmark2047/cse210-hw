using System.Security.Cryptography;
using System.Xml.Serialization;

public class Recipe : Food{
    public List<object> foods = new List<object>();

    public override void Import(string import){
        var lines = import.Split('/');
        foreach (string line in lines){
            if (line == lines[1]){
                this.name = line;
            }else if (line != lines[0] && line != lines[1]){
                Food food = new Food();
                food.Import(line);
                foods.Add(food);
            }
        }
    }
    public override string Export(){
        string export = $"{this.GetType().Name}/{this.name}";
        foreach (Food food in foods){
            export += $"/{food.Export()}";
        }
        return export;
    }
    public void MakeRecipe(List<object> inventory)
    {
        Console.Write("Name of Recipe: ");
        this.name = Console.ReadLine();
        bool finished = false;
        List<object> found = new List<object>();
        bool fromFound = false;
        while (!finished){
            Console.WriteLine("What foods would you like to add to your recipe?");
            Console.WriteLine("Press 'd' when you are done adding foods.");
            Console.WriteLine("    Enter the list number of the food");
            if (found.Count() == 0){
                DisplayFoods(inventory);
            }else{
                DisplayFoods(found);
                fromFound = true;
            }
            string keyword = Console.ReadLine();
            bool isInt = int.TryParse(keyword, out int choice);
            if (isInt && fromFound == false && 0 < choice && choice <= inventory.Count()){
                Food food = (Food)inventory[choice-1];
                food.AddFood();
                this.foods.Add(inventory[choice-1]);
                Console.Clear();
            }else if (isInt && fromFound == true && 0 < choice && choice <= found.Count()){
                Food food = (Food)found[choice-1];
                food.AddFood();
                food.Calories();
                this.foods.Add(found[choice-1]);
                Console.Clear();
                found.Clear();
            }else if (!isInt){
                found = Search(inventory, keyword);
                if (found.Count() == 0){
                    Console.Clear();
                    Console.WriteLine($"\n     No foods found under the search word {keyword}.");
                }
                if (keyword.ToLower() == "d"){
                    finished = true;
                    Console.Clear();
                }
            }else{
                Console.Clear();
                Console.WriteLine("Invalid Selection. ");
            }
        }
    }
    public static List<object> Search(List<object> list, string keyword){
        int index = 0;
        List<object> found = new List<object>();
        while (index < list.Count()){
            Food food  = (Food)list[index];
            if (food.name.ToLower().Contains(keyword.ToLower())){
                found.Add(list[index]);
            }
            index += 1;
        }
        return found;
    }

    public static void DisplayFoods(List<object> foods){
        int count = 0;
        foreach (Food food in foods){
            count += 1;
            Console.WriteLine($"{count}.) {food.name}");
        }
    }

    public void CalculateMacros(){
        this.carbs = 0;
        this.protein = 0;
        this.fat = 0;
        foreach (Food food in foods){
            this.carbs += food.carbs;
            this.protein += food.protein;
            this.fat += food.fat;
        }
        Calories();
    }
}