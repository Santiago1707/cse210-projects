using System;

public class Circle : Shape
{
    private double _radius; // Private member variable for the radius
    public Circle(double radius)
    {
        _radius = radius; // Set the radius
    }
    public Circle(string color, double radius) : base()
    {
        SetColor(color); // Set the color using the base class method
        _radius = radius; // Set the radius
    }
    public override double GetArea()
    {
        return Math.PI * _radius * _radius; // Area = π * radius^2
    }
}