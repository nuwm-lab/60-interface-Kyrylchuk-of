using System;
public interface IGeometry
{
    void Coefficients();
    void CheckPoint(params double[] coordinates);
}

public abstract class Geometry : IGeometry
{
    protected double[] coefficients;

    public Geometry(params double[] coefficients)
    {
        this.coefficients = coefficients;
    }

    public abstract void Coefficients();

    public abstract void CheckPoint(params double[] coordinates);
}

public class Line : Geometry
{
    public Line(double a1, double a2, double a0) : base(a1, a2, a0) { }

    public override void Coefficients()
    {
        Console.WriteLine($"Рівняння прямої: {coefficients[0]}x + {coefficients[1]}y + {coefficients[2]} = 0");
    }

    public override void CheckPoint(params double[] coordinates)
    {
        if (coefficients[0] * coordinates[0] + coefficients[1] * coordinates[1] + coefficients[2] == 0)
        {
            Console.WriteLine($"Точка ({coordinates[0]}, {coordinates[1]}) належить прямій.");
        }
        else
        {
            Console.WriteLine($"Точка ({coordinates[0]}, {coordinates[1]}) не належить прямій.");
        }
    }
}

public class Hyperplane : Geometry
{
    public Hyperplane(double a4, double a3, double a2, double a1, double a0) : base(a4, a3, a2, a1, a0) { }

    public override void Coefficients()
    {
        Console.WriteLine($"Рівняння гіперплощини: {coefficients[0]}x4 + {coefficients[1]}x3 + {coefficients[2]}x2 + {coefficients[3]}x1 + {coefficients[4]} = 0");
    }

    public override void CheckPoint(params double[] coordinates)
    {
        if (coefficients[0] * coordinates[0] + coefficients[1] * coordinates[1] + coefficients[2] * coordinates[2] + coefficients[3] * coordinates[3] + coefficients[4] == 0)
        {
            Console.WriteLine($"Точка ({coordinates[0]}, {coordinates[1]}, {coordinates[2]}, {coordinates[3]}) належить гіперплощині.");
        }
        else
        {
            Console.WriteLine($"Точка ({coordinates[0]}, {coordinates[1]}, {coordinates[2]}, {coordinates[3]}) не належить гіперплощині.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Line line = new Line(1, -2, 3);
        Console.WriteLine("Для лінії:");
        line.Coefficients();
        line.CheckPoint(-3, 0);

        Hyperplane hyperplane = new Hyperplane(4, 5, 6, 7, 8);
        Console.WriteLine("\nДля гіперплощини:");
        hyperplane.Coefficients();
        hyperplane.CheckPoint(1, 2, 3, 4);
    }
}

