using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        Scripture scripture = new Scripture();
        string text = scripture.GetScript();

        Reference reference = new Reference();
        reference.BuildReference(text);

        reference.DisplayReference();
    }
}