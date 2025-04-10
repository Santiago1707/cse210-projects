using System;

public abstract class Shape
{
    private string _color; // Private color variable

    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }

    public string GetColor()
    {
        return _color; // Getter for color
    }

    public string SetColor(string color)
    {
        _color = color; // Setter for color
        return _color;
    }
    public abstract double GetArea(); // Abstract method for getting the area
}