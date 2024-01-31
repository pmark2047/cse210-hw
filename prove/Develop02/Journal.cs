using Microsoft.VisualBasic;

public class Journal {
    public List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in entries)
        {
            entry.Display();
        }
    }

    public string[] Export()
    {
        var exportString = new List<string>();
        foreach (var entry in entries)
        {
            exportString.Add(entry.Export());
        }
        return exportString.ToArray();
    }
}