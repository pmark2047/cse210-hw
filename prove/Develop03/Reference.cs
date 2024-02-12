using System;
public class Reference {

    private string book;
    private int chap;
    private int startVerse;
    private int endVerse;
    public string BuildReference(string book, int chap, int startVerse, int endVerse)
    {
        return $"{book} {chap}:{startVerse}-{endVerse}";
    }

    public string BuildReference(string book, int chap, int startVerse)
    {
        return $"{book} {chap}:{startVerse}";
    }

    public void BuildReference(string scripture)
    {
        var parts = scripture.Split(" ");
        this.book = parts[0];
        string location = parts[1];
        parts = location.Split(":");
        this.chap = int.Parse(parts[0]);
        string verses = parts[1];

        if (verses.Contains("-"))
        {
            parts = verses.Split("-");
            this.startVerse = int.Parse(parts[0]);
            this.endVerse = int.Parse(parts[1]);
        }
        else
        {
            this.startVerse = int.Parse(parts[1]);
        }
    }

    public string ReturnReference()
    {
        if (endVerse == 0)
        {
            return $"{book} {chap}:{startVerse} ";
        }
        else
        {
            return $"{book} {chap}:{startVerse}-{endVerse} ";
        }
    }



}