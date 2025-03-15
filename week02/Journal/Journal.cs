using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private int _streak = 0;
    private string _streakFile = "streak.txt";

    public Journal()
    {
        LoadStreak(); // Cargar la racha al iniciar el programa
    }

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
        UpdateStreak(); // Actualizar la racha al agregar una nueva entrada
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(fileName);
        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[1], parts[2]));
            }
        }
        Console.WriteLine("Journal loaded successfully.");
    }

    private void LoadStreak()
    {
        if (File.Exists(_streakFile))
        {
            string[] data = File.ReadAllLines(_streakFile);
            if (data.Length == 2)
            {
                _streak = int.Parse(data[0]);
                string lastDate = data[1];

                DateTime lastEntryDate = DateTime.Parse(lastDate);
                DateTime today = DateTime.Today;

                if (lastEntryDate == today)
                {
                    // Si ya se escribió hoy, no cambia la racha
                    return;
                }
                else if (lastEntryDate == today.AddDays(-1))
                {
                    // Si fue ayer, la racha continúa
                    _streak++;
                }
                else
                {
                    // Si han pasado más de 1 día, la racha se reinicia
                    _streak = 0;
                }
            }
        }
        else
        {
            _streak = 0;
        }
    }

    private void UpdateStreak()
    {
        _streak++; // Incrementa la racha cuando se escribe una entrada
        File.WriteAllLines(_streakFile, new string[] { _streak.ToString(), DateTime.Today.ToString("yyyy-MM-dd") });
    }

    public int GetStreak()
    {
        return _streak;
    }
}
