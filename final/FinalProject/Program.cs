using System;

class Program
{
    static void Main(string[] args)
    {
        Diet diet = new Diet();
        FileManager file = new FileManager();
        List<object> foods = new List<object>();
        List<object> recipies = new List<object>();
        List<Food> daily = new List<Food>();
        List<double> totals = new List<double>(){
            0, //calories
            0, //carbs
            0, //protein
            0  //fats
        };

        Console.Clear();
        Console.WriteLine("Welcome to Macros Tracker\n");
        bool loop = true;
        while (loop){
            diet.CalculateCalories();
            totals = CalculateCalories(daily, totals);
            Console.WriteLine($"        Total Calories: {totals[0]}/{diet.calories}");
            Console.WriteLine($"Carbs: {Math.Round(totals[1], 1)}/{Math.Round((double)(diet.calories/2)/4, 1)}   Protein: {Math.Round(totals[2], 1)}/{Math.Round((double)(diet.calories/5)/4,1)}   Fat: {Math.Round(totals[3], 1)}/{Math.Round((double)(diet.calories*0.3)/9, 1)}");
            Console.WriteLine("\n   Please select from an option below");
            Console.WriteLine("1.) Add");
            Console.WriteLine("2.) Report");
            Console.WriteLine("3.) Display Foods");
            Console.WriteLine("4.) Profile");
            Console.WriteLine("5.) Save File");
            Console.WriteLine("6.) Load File");
            Console.WriteLine("7.) Quit");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice < 8){
                if (choice == 1){
                    Console.Clear();
                    while(loop){
                        Console.WriteLine("    What would you like to add? ");
                        Console.WriteLine("1.) Add Food");
                        Console.WriteLine("2.) Add Recipe");
                        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 3){
                            if (choice == 1){
                                Food food = new Food();
                                food.Make();
                                foods.Add(food);
                            }else{
                                Recipe recipe = new Recipe();
                                recipe.MakeRecipe(foods);
                                recipe.CalculateMacros();
                                recipies.Add(recipe);
                            }
                            loop = false;
                        }else{
                            Console.WriteLine("Invalid Seleciton. ");
                        }
                        Console.Clear();
                    }
                    loop = true;
                }else if (choice == 2){
                    Console.Clear();
                    while(loop){
                        Console.WriteLine("    What would you like to report? ");
                        Console.WriteLine("1.) Report Food");
                        Console.WriteLine("2.) Report Recipe");
                        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 3){
                            if (choice == 1){
                                Console.Clear();
                                List<object> found = new List<object>();
                                
                                while (loop && foods.Count() > 0){
                                    Console.WriteLine("    Enter the list number of what you ate or search within the list");
                                    bool fromFound = false;
                                    if (found.Count() == 0){
                                        DisplayFoods(foods);
                                        fromFound = false;
                                    }else{
                                        DisplayFoods(found);
                                        fromFound = true;
                                    }
                                    string keyword = Console.ReadLine();
                                    bool isInt = int.TryParse(keyword, out choice);
                                    if (isInt && 0 < choice && choice <= foods.Count()){
                                        if (fromFound){
                                            Food food = new Food();
                                            food.Import(((Food)found[choice-1]).Export());
                                            food.AddFood();
                                            food.Import(food.Export());
                                            food.name += daily.Count()+1;
                                            daily.Add(food);
                                            
                                        }else{
                                            Food food = new Food();
                                            food.Import(((Food)foods[choice-1]).Export());
                                            food.AddFood();
                                            food.Import(food.Export());
                                            food.name += daily.Count()+1;
                                            daily.Add(food);
                                        }
                                        loop = false;
                                    }else if (!isInt){
                                        found = Search(foods, keyword);
                                        if (found.Count() == 0){
                                            Console.Clear();
                                            Console.WriteLine($"\n     No foods found under the search word {keyword}.");
                                        }
                                    }else{
                                        Console.WriteLine("Invalid Selection. ");
                                    }
                                }
                                if (foods.Count == 0){
                                    Console.WriteLine("There are no foods to report, please add a food or load a profile. ");
                                    Thread.Sleep(3000);
                                }
                                loop = true;

                            }else{
                                List<object> found = new List<object>();
                                while (loop && recipies.Count() > 0){
                                    Console.WriteLine("    Enter the list number of what you ate or search within the list");
                                    bool fromFound = false;
                                    if (found.Count() == 0){
                                        DisplayFoods(recipies);
                                        fromFound = false;
                                    }else{
                                        DisplayFoods(found);
                                        fromFound = true;
                                    }
                                    string keyword = Console.ReadLine();
                                    bool isInt = int.TryParse(keyword, out choice);
                                    if (isInt && 0 < choice && choice <= recipies.Count()){
                                        if (fromFound){
                                            Recipe recipe = new Recipe();
                                            recipe.Import(((Recipe)found[choice-1]).Export());
                                            recipe.CalculateMacros();
                                            recipe.AddFood();
                                            recipe.name += daily.Count()+1;
                                            daily.Add(recipe);
                                        }else{
                                            Recipe recipe = new Recipe();
                                            recipe.Import(((Recipe)recipies[choice-1]).Export());
                                            recipe.CalculateMacros();
                                            recipe.AddFood();
                                            recipe.name += daily.Count()+1;
                                            daily.Add(recipe);
                                        }
                                        loop = false;
                                    }else if (!isInt){
                                        found = Search(recipies, keyword);
                                        if (found.Count() == 0){
                                            Console.Clear();
                                            Console.WriteLine($"\n     No recipies found under the search word {keyword}.");
                                        }
                                    }else{
                                        Console.WriteLine("Invalid Selection. ");
                                    }
                                }
                                if (recipies.Count == 0){
                                    Console.Clear();
                                    Console.WriteLine("There are no recipies to report, please add a recipe or load a profile. ");
                                    Thread.Sleep(3000);
                                }else{
                                    Recipe recipe = new Recipe();
                                }
                            }
                            loop = false;
                        }else{
                            Console.WriteLine("Invalid Seleciton. ");
                        }
                    }
                    Console.Clear();
                    loop = true;
                }else if (choice == 3){
                    Console.Clear();
                    if (foods.Count() > 0 || recipies.Count() > 0){
                        Console.WriteLine("\nFoods: ");
                        DisplayFoods(foods);
                        Console.WriteLine("\nRecipes: ");
                        DisplayFoods(recipies);
                        Console.WriteLine("\n\n");
                    }else{
                        Console.WriteLine("There are no foods or recipies. Please create a new food or recipe. \n");
                    }
                }else if (choice == 4){
                    Console.Clear();
                    while (loop)
                    {
                        Console.WriteLine("   Please select from an option below");
                        Console.WriteLine("1.) Create Profile");
                        Console.WriteLine("2.) Update Profile");
                        Console.WriteLine("3.) Update Goal");
                        if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 4){
                            Console.Clear();
                            if (choice == 1){
                                diet.GetData();
                                diet.CalculateBmr();
                                while (loop)
                                {
                                    string saveData = diet.Export();
                                    Console.WriteLine("    What is your weight goal?");
                                    Console.WriteLine("1.) Lose Weight");
                                    Console.WriteLine("2.) Maintain Weight");
                                    Console.WriteLine("3.) Gain Weight");
                                    if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 4){
                                        Console.Clear();
                                        if (choice == 1){
                                            diet = new Cut();
                                        }else if (choice == 2){
                                            diet = new Diet();
                                        }else{
                                            diet = new Bulk();
                                        }
                                        diet.Import(saveData);
                                        loop = false;
                                    }else{
                                        Console.WriteLine("Invalid Selection.");
                                    }
                                }
                            }else if (choice == 2){
                                diet.GetData();
                            }else{
                                while (loop)
                                {
                                    string saveData = diet.Export();
                                    Console.WriteLine("    What is your weight goal?");
                                    Console.WriteLine("1.) Lose Weight");
                                    Console.WriteLine("2.) Maintain Weight");
                                    Console.WriteLine("3.) Gain Weight");
                                    if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice < 4){
                                        Console.Clear();
                                        if (choice == 1){
                                            diet = new Cut();
                                        }else if (choice == 2){
                                            diet = new Diet();
                                        }else{
                                            diet = new Bulk();
                                        }
                                        diet.Import(saveData);
                                        loop = false;
                                    }else{
                                        Console.WriteLine("Invalid Selection.");
                                    }
                                }
                                diet.CalculateBmr();
                            }
                            loop = false;
                        }else{
                            Console.WriteLine("Invalid Selection.");
                        }
                    }
                    loop = true;
                    Console.Clear();
                }else if (choice == 5){
                    file.Save(diet, foods, recipies);
                    Console.Clear();
                }else if (choice == 6){
                    foods.Clear();
                    daily.Clear();
                    (diet, foods, recipies) = file.Load(diet);
                    Console.Clear();
                }else{
                    loop = false;
                }

            }else{
                Console.Clear();
                Console.WriteLine("Invalid selecion.");
            }
        }
    }

    public static void DisplayFoods(List<object> foods){
        int count = 0;
        foreach (Food food in foods){
            count += 1;
            Console.WriteLine($"{count}.) {food.name} ({food.caloriesPerServing} cal)");
        }
    }
    public static List<double> CalculateCalories(List<Food> daily, List<double> totals){
        totals[1] = 0;
        totals[2] = 0;
        totals[3] = 0;
        foreach(Food food in daily){
            totals[1] += food.carbs * food.servings;
            totals[2] += food.protein * food.servings;
            totals[3] += food.fat * food.servings;
        }
        totals[0] = (totals[1] * 4) + (totals[2] * 4) + (totals[3] * 9);
        return totals;
    }

    public static List<object> Search(List<object> list, string keyword){
        int index = 0;
        List<object> found = new List<object>();
        while (index < list.Count()){
            Food food = (Food)list[index];
            if (food.name.ToLower().Contains(keyword.ToLower())){
                found.Add(food);
            }
            index += 1;
        }
        return found;
    }
}