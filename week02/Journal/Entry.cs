using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    public string Date { get { return _date; } }
    public string PromptText { get { return _promptText; } }
    public string EntryText { get { return _entryText; } }

    public Entry(string prompt, string entryText)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _promptText = prompt;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine("-----------------------------");
    }
}
