

using System.IO.Enumeration;

public class FileManager{
    public void Save(Diet diet, List<object> foods, List<object>recipes){
        Console.WriteLine("What would you like to name the file? ");
        string filename = Console.ReadLine()+".txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(diet.Export());
            foreach(Food food in foods){
                writer.WriteLine(food.Export());
            }
            foreach(Recipe recipe in recipes){
                writer.WriteLine(recipe.Export());
            }
        }
    }
    public (Diet, List<object>, List<object>) Load(Diet diet){
        List<object> foods = new List<object>();
        List<object> recipes = new List<object>();
        Console.WriteLine("What is the name of the file? ");
        string filename = Console.ReadLine()+".txt";
        string [] lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line == lines[0]){
                var parts = line.Split(',');
                if (parts[7] == "Diet"){
                    diet = new Diet();
                }else if (parts[7] == "Cut"){
                    diet = new Cut();
                }else{
                    diet = new Bulk();
                }
                diet.Import(line);
            }else{
                var parts = line.Split('/');
                if (parts[0] == "Recipe"){
                    Recipe recipe = new Recipe();
                    recipe.Import(line);
                    recipe.CalculateMacros();
                    recipes.Add(recipe);
                }else{
                    Food food = new Food();
                    food.Import(line);
                    foods.Add(food);
                }
            }
        }
        filename = "generic.txt";
        lines = System.IO.File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            var parts = line.Split('/');
            Food food = new Food();
            food.Import(line);
            foods.Add(food);
        }
        return (diet, foods, recipes);
    }
    public List<object> GetGeneric(List<object> foods){
        string [] lines = System.IO.File.ReadAllLines("generic.txt");
        foreach (string line in lines)
        {
            var parts = line.Split('/');
            Food food = new Food();
            food.Import(line);
            foods.Add(food);
        }
        return foods;
    }
}