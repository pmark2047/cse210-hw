using Microsoft.VisualBasic;

public class Word {

    public string word;

    public void Hide()
    {
        string blank = "";

        if (!word.Contains("\n"))
        {
            foreach (char a in word)
            {
                if (!char.IsPunctuation(a))
                    {blank += "_";}
                else
                    {blank += a;}
            }
            word = blank;
        }
    }

}