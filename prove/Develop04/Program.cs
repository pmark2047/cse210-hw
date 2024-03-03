using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, int> log;

    static void Main(string[] args)
    {
        log = getLog();
        Console.Clear();
        Activity activity = new Activity();

        activity.displayMenu();
        int choice = activity.getUserChoice();

        while (choice != 4)
        {
            if (choice == 1)
            {
                Breathing breathingAct = new Breathing();
                breathingAct.run();
                Console.Clear();
                log["Breathing"] += 1;
            }
            else if (choice == 2)
            {
                Reflection reflectAct = new Reflection();
                reflectAct.run();
                Console.Clear();
                log["Reflection"] += 1;
            }
            else if (choice == 3)
            {
                Listing listAct = new Listing();
                listAct.run();
                Console.Clear();
                log["Listing"] += 1;
            }

            activity.displayMenu();
            choice = activity.getUserChoice();
            writeLog(log);
        }
    }

    static void writeLog(Dictionary<string, int> logs)
    {
        string[] activities = new string[] { "Breathing", "Reflection", "Listing" };
        string[] entries = new string[logs.Count];
        for (int i = 0; i < activities.Length; i++) {
            entries[i] = activities[i] + ";" + logs[activities[i]];
        }
        using (StreamWriter writer = new StreamWriter("activity_log.txt"))
        {
            foreach (string entry in entries)
            {
                 writer.WriteLine(entry);
            }
        }
    }

    static Dictionary<string, int> getLog()
    {
        string fileName = "activity_log.txt";
        Dictionary<string, int> log = new Dictionary<string, int>();
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] entry = line.Split(";");
                log.Add(entry[0], int.Parse(entry[1]));
            }
            return log;
        }
        catch
        {
            log.Add("Breathing", 0);
            log.Add("Reflection", 0);
            log.Add("Listing", 0);
            return log;
        }

    }
}