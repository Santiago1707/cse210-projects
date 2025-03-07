using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradePercentage = int.Parse(grade);

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        if (gradePercentage <= 97 && letter != "F")
        {
            if (gradePercentage % 10 >= 7)
            {
                sign = "+";
            }
            else if (gradePercentage % 10 < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congrats, You passed!");
        }
        else
        {
            Console.WriteLine("You failed but Grades don’t define your worth or your potential. What matters most is what you learn and how you grow. Keep pushing forward, and next time, you’ll do even better.!");
        }
    }
}
