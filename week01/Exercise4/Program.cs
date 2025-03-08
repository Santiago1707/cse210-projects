using System;
using System.Diagnostics.CodeAnalysis;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise 4 Project.");

        List<int> numbers = new List<int>();
        string number = "";
        int suma = 0;
        int countnumbers = 0;

        Console.WriteLine("Enter a number or type '0' to quit");
        while (number != "0")
        {
            Console.Write("Enter a number: ");
            number = Console.ReadLine();
            {
                numbers.Add(int.Parse(number));
            }
        }

        numbers.Remove(0);

        foreach (int num in numbers)
            { 
                suma += num;
            }
            Console.WriteLine("Sum of numbers: " + suma);

            countnumbers = numbers.Count;
            Console.WriteLine($"Average of numbers: {(suma / (double)countnumbers):F3}");

            int largest = numbers.Max();
            Console.WriteLine("Largest number: " + largest);

            int minPositivo = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
            Console.WriteLine("The smallest positive number is: " + minPositivo);

            Console.WriteLine("The sorted list is:");
            numbers.Sort();
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            } 

    }
}