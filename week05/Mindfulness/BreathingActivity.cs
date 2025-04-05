using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "The Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int elapsedTime = 0;
        while (elapsedTime < _duration)
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(5);

            Console.WriteLine("Now breathe out...");
            ShowCountDown(6);
            Console.WriteLine("");
            elapsedTime += 8; // Each cycle takes 8 seconds

        }

        DisplayEndingMessage();
    }
}
