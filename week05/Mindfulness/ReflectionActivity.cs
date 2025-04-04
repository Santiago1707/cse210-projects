using System;
using System.Collections.Generic;
using System.Linq;

class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private List<string> _availablePrompts;
    private List<string> _availableQuestions;

    public ReflectingActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        ResetPromptPool();
        ResetQuestionPool();
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);

        DisplayPrompt();
        ShowCountDown(5);

        AskReflectionQuestions();
        DisplayEndingMessage();
    }

    private void ResetPromptPool()
    {
        _availablePrompts = _prompts.OrderBy(x => Guid.NewGuid()).ToList();
    }

    private void ResetQuestionPool()
    {
        _availableQuestions = _questions.OrderBy(x => Guid.NewGuid()).ToList();
    }

    private string GetRandomPrompt()
    {
        if (_availablePrompts.Count == 0) ResetPromptPool();
        string prompt = _availablePrompts[0];
        _availablePrompts.RemoveAt(0);
        return prompt;
    }

    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0) ResetQuestionPool();
        string question = _availableQuestions[0];
        _availableQuestions.RemoveAt(0);
        return question;
    }

    private void DisplayPrompt()
    {
        string prompt = GetRandomPrompt();
        Console.WriteLine($"\n{prompt}\nThink about this moment...");
    }

    private void DisplayQuestion(string question)
    {
        Console.WriteLine($"\n{question}");
    }

    private void AskReflectionQuestions()
    {
        int elapsedTime = 0;

        while (elapsedTime < _duration)
        {
            string question = GetRandomQuestion();
            DisplayQuestion(question);
            ShowCountDown(5);
            elapsedTime += 5;
        }
    }
}
