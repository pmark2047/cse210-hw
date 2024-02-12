using System;
using System.Net;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        Scripture scripture = new Scripture();

        string script = "John 3:16 For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life.";

        //string script = "Alma 12:27 But behold, it was not so; but it was appointed unto men that they must die; and after death, they must come to judgment, even that same judgment of which we have spoken, which is the end.";
        
        scripture.scripture = script;

        Console.Clear();
        scripture.DisplayReference();
        scripture.DisplayVerses();

        Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish: ");
        string response = Console.ReadLine();
        while (response != "quit")
        {
            Console.Clear();
            scripture.DisplayReference();
            scripture.DisplayHide();

            Console.WriteLine("\n\nPress enter to continue or type 'quit' to finish: ");
            response = Console.ReadLine();

            if (scripture.wordCount.Count() == 0) { response = "quit";}            
        }

        
    }
}