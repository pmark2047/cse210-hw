

using System.IO.Enumeration;

public class FileManager{
    public void Save(Diet diet, List<Food> foods){
        Console.WriteLine("What would you like to name the file? ");
        string filename = Console.ReadLine()+".txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(diet.Export());
            foreach(Food food in foods){
                writer.WriteLine(food.Export());
            }
        }
    }
    public (Diet, List<Food>) Load(Diet diet){
        List<Food> foods = new List<Food>();
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
                Food food = new Food();
                food.Import(line);
                foods.Add(food);
            }
        }
        return (diet, foods);
    }
}