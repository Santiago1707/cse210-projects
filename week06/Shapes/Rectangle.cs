using System;

public class Rectangle : Shape
{
    private double _length; // Private member variable for the length
    private double _width;  // Private member variable for the width

    public Rectangle(string color, double length, double width) : base()
    {
        SetColor(color); // Set the color using the base class method
        _length = length; // Set the length
        _width = width;   // Set the width
    }

    public override double GetArea()
    {
        return _length * _width; // Area = length * width
    }   
}