using System;
using System.Net;
using Microsoft.VisualBasic;
public class Scripture {

    
    public string scripture;
    
    public Reference reference = new Reference();

    public List<Word> words = new List<Word>();
    public List<int> wordCount = new List<int>();

    public void DisplayReference()
    {
        reference.BuildReference(this.scripture);
        Console.Write($"\n{reference.ReturnReference()}");
    }

    public void DisplayVerses()
    {
        var parts = scripture.Split(" ");
        for (int i = 2; i < parts.Count(); i++)
        {
            Word word = new Word();
            word.word = parts[i];
            wordCount.Add(i-2);
            words.Add(word);
            Console.Write($"{parts[i]} ");
        }
    }

    public void DisplayHide()
    {
        Random rnd = new Random();

        if (wordCount.Count() > 10)
        {
            for (int i = 0; i < 6; i++)
            {
                int randInt = rnd.Next(wordCount.Count());
                words[wordCount[randInt]].Hide();
                wordCount.RemoveAt(randInt);
            }
        }
        else if (wordCount.Count() > 3)
        {
            for (int i = 0; i < 3; i++)
            {
                int randInt = rnd.Next(wordCount.Count());
                words[wordCount[randInt]].Hide();
                wordCount.RemoveAt(randInt);
            }
        }
        else
        {
            for (int i = 0; i < 1; i++)
            {
                int randInt = rnd.Next(wordCount.Count());
                words[wordCount[randInt]].Hide();
                wordCount.RemoveAt(randInt);
            }
        }
        foreach (Word word in words)
        {
            Console.Write($"{word.word} ");
        }
    }

    


}