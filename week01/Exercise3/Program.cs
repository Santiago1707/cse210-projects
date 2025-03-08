using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise 3 Project.");
        Console.WriteLine("Hello! Welcome to the Magic Number Guessing Game!");

        Random random = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = random.Next(1, 101); 
            int guess = -1;
            int attempts = 0;

            Console.WriteLine("\nI have selected a random number between 1 and 100. Try to guess it!");

            while (guess != magicNumber)
            {
                Console.Write("Enter your guess: ");
                
                // Validate user input
                if (int.TryParse(Console.ReadLine(), out guess))
                {
                    attempts++;

                    if (guess < magicNumber)
                    {
                        Console.WriteLine("Higher!");
                    }
                    else if (guess > magicNumber)
                    {
                        Console.WriteLine("Lower!");
                    }
                    else
                    {
                        Console.WriteLine($"Congratulations! You guessed the magic number in {attempts} attempts!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("Thanks for playing! Goodbye!");
    }
}