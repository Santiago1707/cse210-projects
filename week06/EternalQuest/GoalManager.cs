using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        Console.WriteLine("\n=== Eternal Quest Program ===");
        Console.WriteLine("Track your goals and earn points as you progress!");
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int level = _score / 1000;
        if (level > 0)
        {
            Console.WriteLine($"Level: {level} - {GetTitle(level)}");
        }
    }

    private string GetTitle(int level)
    {
        string[] titles = { "Novice", "Apprentice", "Adept", "Expert", "Master", "Legend" };
        return level <= titles.Length ? titles[level - 1] : "Grandmaster";
    }

    public void ListGoalNames()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points.ToString()));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points.ToString()));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points.ToString(), target, bonus));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine()) - 1;

        if (goalNumber >= 0 && goalNumber < _goals.Count)
        {
            Goal goal = _goals[goalNumber];
            goal.RecordEvent();
            _score += int.Parse(goal.GetPoints());

            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.GetBonus();
                Console.WriteLine($"Bonus! You earned {checklistGoal.GetBonus()} extra points!");
            }

            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter the filename to save goals: ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("Enter the filename to load goals: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            _goals.Clear();
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split("|");
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                string points = parts[3];

                switch (type)
                {
                    case "SimpleGoal":
                        bool isComplete = bool.Parse(parts[4]);
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        if (isComplete) simpleGoal.RecordEvent();
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(name, description, points));
                        break;
                    case "ChecklistGoal":
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        for (int j = 0; j < amountCompleted; j++) checklistGoal.RecordEvent();
                        _goals.Add(checklistGoal);
                        break;
                }
            }

            Console.WriteLine("Goals loaded successfully!");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}