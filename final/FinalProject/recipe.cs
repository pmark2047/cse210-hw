using System.Security.Cryptography;
using System.Xml.Serialization;

public class Recipe: Food{
    public List<Food> foods = new List<Food>();

    public override void Import(string import){
        var lines = import.Split('\n');
        foreach (string line in lines){
            if (line == lines[0]){
                this.name = line;
            }else{
                Food food = new Food();
                food.Import(line);
                foods.Add(food);
            }
        }
    }
    public override string Export(){
        string export = $"{this.GetType().Name}|{this.name}|";
        foreach (Food food in foods){
            export += $"{food.Export()}";
        }
        return export;
    }
    public void MakeRecipe(List<Food> inventory)
    {
        Console.Write("Name of Recipe: ");
        this.name = Console.ReadLine();
        bool finished = false;
        while (!finished){
            Console.WriteLine("What foods would you like to add to your recipe?");
            Console.WriteLine("Press 'd' when you are done adding foods.");
            List<Food> found = new List<Food>();
            Console.WriteLine("    Enter the list number of the food");
            if (found.Count() == 0){
                DisplayFoods(inventory);
            }else{
                DisplayFoods(found);
            }
            string keyword = Console.ReadLine();
            bool isInt = int.TryParse(keyword, out int choice);
            if (isInt && 0 < choice && choice <= inventory.Count()){
                inventory[choice-1].AddFood();
                this.foods.Add(inventory[choice-1]);
                Console.Clear();
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
    public static List<Food> Search(List<Food> list, string keyword){
        int index = 0;
        List<Food> found = new List<Food>();
        while (index < list.Count()){
            if (list[index].name.ToLower().Contains(keyword.ToLower())){
                found.Add(list[index]);
            }
            index += 1;
        }
        return found;
    }

    public static void DisplayFoods(List<Food> foods){
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