using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello Learning05 World!");

        Square square1 = new Square();
        square1.SetColor("Blue");
        square1._side = 5;

        Rectangle rectangle1 = new Rectangle();
        rectangle1.SetColor("Red");
        rectangle1._length = 4;
        rectangle1._width = 4;

        Circle circle1 = new Circle();
        circle1.SetColor("Green");
        circle1._radius = 3;

        List<object> shapes = new List<object>();
        shapes.Add(square1);
        shapes.Add(rectangle1);
        shapes.Add(circle1);

        foreach (Shape shape in shapes) {

        Console.WriteLine($"\n{shape.GetColor()} {shape.GetName()}");
        Console.WriteLine(Math.Round(shape.GetArea(), 2));
        }

    }
}

public class Shape
{
    public string _color ;
    public string GetColor(){
        return _color;
    }

    public void SetColor(string _color){
        this._color = _color;
    }
    public string GetName(){
        return this.GetType().Name;
    }
    public virtual double GetArea(){
        return -1;
    }
}
public class Square : Shape
{
    public double _side ;
    public override double GetArea(){
        return _side * _side;
    }
}
public class Rectangle : Shape
{
    public double _length ;
    public double _width ;
    public override double GetArea()
    {
        return _length * _width;
    }
}
public class Circle : Shape
{
    public double _radius;
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}