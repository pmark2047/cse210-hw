public class Entry {

    public string response;

    public string prompt;

    public string date;

    public Entry(string response, string prompt, string date)
    {
        this.response = response;
        this.prompt = prompt;
        this.date = date;
    }

    public Entry(string import)
    {
        var parts = import.Split("-|-");
        this.prompt = parts[0];
        this.response = parts[1];
        this.date = parts[2];
    }

    public void Display()
    {
        Console.WriteLine($"{prompt}\n{response}\n");
    }

    public string Export()
    {
        return $"{prompt}-|-{response}-|-{date}";
    }


}