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
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("How long, (in seconds) would you like for this section?: ");
        _duration = int.Parse(Console.ReadLine() ?? "30");
        Console.WriteLine("\nGet Ready...");
        ShowSpinner(4);
        Console.Clear();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine("\nGood job! You have completed the activity.");
        ShowSpinner(3);
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(5);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> showSpinner = new List<string>()
        {
            "|", "/", "-", "\\", "|", "/", "-", "\\"
        };

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);

        int i = 0;

        while (DateTime.Now < endTime)
        {
            string s = showSpinner[i % showSpinner.Count];
            Console.Write(s);
            Thread.Sleep(200);
            Console.Write("\b \b");

            i++;

            if (i >= showSpinner.Count)
            {
                i = 0; // Reset the index to loop through the spinner characters
            }
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



