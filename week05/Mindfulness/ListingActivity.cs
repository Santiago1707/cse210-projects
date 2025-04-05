using System;
using System.Collections.Generic;
using System.Linq;

class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}\nThink for a moment...");
        ShowCountDown(5);

        Console.WriteLine("List as many responses you can to the following prompt:");
        List<string> responses = GetListFromUser();

        Console.WriteLine($"You listed {responses.Count} items.");
        DisplayEndingMessage();
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0) ResetPrompts();

        Random random = new Random();
        int index = random.Next(_prompts.Count); // Get a random index
        string prompt = _prompts[index];
        _prompts.RemoveAt(index); // Remove the selected prompt to avoid repetition
        return prompt;
    }

    private void ResetPrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        _prompts = _prompts.OrderBy(x => Guid.NewGuid()).ToList(); // Shuffle
    }

    private List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("- ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                responses.Add(response);
            }
        }
        return responses;
    }
}