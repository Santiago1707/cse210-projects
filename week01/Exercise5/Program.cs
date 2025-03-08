using System;

class Program
{
    static string name;
    static int number;
    static int square;

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise 5 Project.");
        DisplayMessage();
        PromptUserName();
        PromptUserNumber();
        SquareNumber();
        DisplayResult();
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static void PromptUserName()
    {
        Console.Write("Please enter your name: ");
        name = Console.ReadLine();
    }

    static void PromptUserNumber()
    {
        Console.Write("Please enter a number: ");
        number = int.Parse(Console.ReadLine());
    }

    static void SquareNumber()
    {
        square = (int)Math.Pow(number, 2);
    }

    static void DisplayResult()
    {
        Console.WriteLine($"{name}, the square of your number is: {square}");
    }
}