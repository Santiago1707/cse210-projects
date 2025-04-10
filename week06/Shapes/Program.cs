using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add a square, rectangle, and circle to the list
        shapes.Add(new Square("Blue", 5.0)); // Square with side 5.0
        shapes.Add(new Rectangle("Red", 4.0, 6.0)); // Rectangle with length 4.0 and width 6.0
        shapes.Add(new Circle("Green", 3.0)); // Circle with radius 3.0

        // Iterate through the list of shapes
        foreach (Shape shape in shapes)
        {
            // Call and display the GetColor() and GetArea() methods
            Console.WriteLine($"Shape Color: {shape.GetColor()}");
            Console.WriteLine($"Shape Area: {shape.GetArea():F2}"); // Format area to 2 decimal places
            Console.WriteLine();
        }
    }
}