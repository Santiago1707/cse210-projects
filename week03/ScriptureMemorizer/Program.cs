using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of scriptures (like a database)
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ who strengthens me.")
        };

        Console.WriteLine("Select a scripture to memorize:");
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetDisplayText()}");
        }

        // Get user choice
        int choice;
        do
        {
            Console.Write("\nEnter the number of the scripture: ");
        }
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > scriptures.Count);

        Scripture selectedScripture = scriptures[choice - 1];

        // Scripture memorization process
        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(2); // Hide 2 words at a time

            if (selectedScripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden!");
                break;
            }
        }
    }
}
