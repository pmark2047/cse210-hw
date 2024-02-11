public class Word {

    public string word;

    public void Hide()
    {
        string blank = "";
        foreach (char a in word)
        {
            blank += "_";
        }
        word = blank;
    }

}