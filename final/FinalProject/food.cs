public class Food{
    public string name;
    public double carbs;
    public double protein;
    public double fat;
    public double servings = 1;

    public virtual string Export(){
        return $"{name}|{carbs}|{protein}|{fat}|{servings}";
    }
    public virtual void Import(string import){
        var parts = import.Split('|');
        this.name = parts[0];
        this.carbs = double.Parse(parts[1]);
        this.protein = double.Parse(parts[2]);
        this.fat = double.Parse(parts[3]);
        this.servings = double.Parse(parts[4]);
    }
    public virtual void Make(){
        Console.Write("Name: ");
        this.name = Console.ReadLine();
        bool loop = true;
        while (loop){
            Console.Write("Carbs: ");
            if (double.TryParse(Console.ReadLine(), out carbs) && carbs >= 0){
                loop = false;
            }else{
                Console.WriteLine("Invalid entry, please enter the grams of carbs per serving.");
            }
        }
        while (!loop){
            Console.Write("Protein: ");
            if (double.TryParse(Console.ReadLine(), out protein) && protein >= 0){
                loop = true;
            }else{
                Console.WriteLine("Invalid entry, please enter the grams of protein per serving.");
            }
        }
        while (loop){
            Console.Write("Fat: ");
            if (double.TryParse(Console.ReadLine(), out fat) && fat >= 0){
                loop = false;
            }else{
                Console.WriteLine("Invalid entry, please enter the grams of fat per serving.");
            }
        }
    }
    public virtual void AddFood(){
        bool loop = true;
        while (loop){
            Console.WriteLine("Number of servings consumed: ");
            if (double.TryParse(Console.ReadLine(), out servings) && servings > 0){
                loop = false;
            }else{
                Console.WriteLine("Invalid entry, please enter the number of servings you ate.");
            }
        }
    }
}