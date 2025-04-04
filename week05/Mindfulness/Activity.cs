using System;
using System.Threading;

class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = "Activity";
        _description = "A mindfulness activity to help you focus and relax.";
        _duration = 0;
    }

    public virtual void Run()
    {
        // To be overridden by derived classes
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"{_name}\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, (in seconds) would you like for this section?: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("Get Ready...");
        
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("Good job! You have completed the activity.");
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> showSpinner = new List<string>()
        {
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };

        foreach (string s in showSpinner)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}



