using System;

public class Square : Shape
{
    private double _side; // Private member variable for the side length

    // Constructor that accepts color and side, and calls the base constructor with color
    public Square(string color, double side) : base()
    {
        SetColor(color); // Set the color using the base class method
        _side = side;    // Set the side length
    }

    // Override the GetArea method to calculate and return the area of the square
    public override double GetArea()
    {
        return _side * _side; // Area = side * side
    }
}