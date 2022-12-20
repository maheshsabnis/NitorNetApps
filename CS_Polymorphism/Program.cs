// See https://aka.ms/new-console-template for more information
Console.WriteLine("DEMO Polymorphism");
Rectangle rect = new Rectangle(20, 30);
Console.WriteLine($"Rectangle ARea = {rect.GetArea()}");
Circle circle = new Circle(100);
Console.WriteLine($"Circle ARea = {circle.GetArea()}");

// Lets' dynamic Plymorphism

Geometry geometry = new Geometry();

geometry.PrintAreaforShape(circle);
geometry.PrintAreaforShape(rect);

Console.ReadLine();




abstract class Shape
{
    private float _height;
    private float _width;

    public Shape(float height, float width)
    {
        _height = height;
        _width = width;
    }

    public abstract float GetArea();
    //public virtual float GetArea()
    //{
    //    return _height * _width;
    //}
}

class Rectangle : Shape
{
    float _length;
    float _breadth;
    /// <summary>
    /// Linkin with base class ctor and assing parameters
    /// </summary>
    /// <param name="length"></param>
    /// <param name="breadth"></param>
    public Rectangle(float length, float breadth):base(length,breadth)
    {
        _length = length;
        _breadth = breadth;
    }
    /// <summary>
    /// Hide the Matching member of the base class
    /// This method is providing Polymorphic Implementation for the GetArea()
    /// </summary>
    /// <returns></returns>
    public override float GetArea()
    {
        //return base.GetArea();
        return _length * _breadth;
    }

}

 class Circle : Shape
{
    private float _radius;
    public Circle(float radius):base(radius, radius)    
    {
        _radius = radius;
    }
    /// <summary>
    /// polumorphic behavior
    /// </summary>
    /// <returns></returns>
    public override float GetArea()
    {
        return Convert.ToSingle( Math.PI * (_radius * _radius));
    }
}


class Geometry
{
    public void PrintAreaforShape(Shape shape)
    {
        var area = shape.GetArea();
        Console.WriteLine($"ARea of Shape is = {area}");
    }
}