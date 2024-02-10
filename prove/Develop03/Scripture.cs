using System;
public class Scripture {

    public string GetScript()
    {
        string scripture = File.ReadAllText("Scripture.txt");
        return scripture;
    }

    


}