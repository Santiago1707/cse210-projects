using System;

class Program
{
    static void Main(string[] args)
    {
        // Create scripture reference
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // Create scripture passage
Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +"In all thy ways acknowledge him, and he shall direct thy paths.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.Write("\nPress Enter to hide words or type 'quit' to exit: ");
            

            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                break;
            }

            scripture.HideRandomWords(2); // Amount of words to hide 

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden!");
                break;
            }
        }
    }
}