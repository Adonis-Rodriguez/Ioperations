public interface IOperaciones
{
    double Sumar(double a, double b);

    double Restar(double a, double b);

    double Multiplicar(double a, double b);

    double Dividir(double a, double b);

    double CalcularAreaCirculo(double radio);

    double CalcularVolumenEsfera(double radio);

    double CalcularDistancia(double x1, double y1, double x2, double y2);
}

public abstract class OperacionesBase : IOperaciones
{
    public double Sumar(double a, double b)
    {
        return a + b;
    }

    public double Restar(double a, double b)
    {
        return a - b;
    }

    public double Multiplicar(double a, double b)
    {
        return a * b;
    }

    public double Dividir(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("La división por cero no está permitida.");
        }
        return a / b;
    }

    public double CalcularAreaCirculo(double radio)
    {
        if (radio < 0)
        {
            throw new ArgumentException("El radio no puede ser negativo.");
        }
        return Math.PI * Math.Pow(radio, 2);
    }

    public double CalcularVolumenEsfera(double radio)
    {
        if (radio < 0)
        {
            throw new ArgumentException("El radio no puede ser negativo.");
        }
        return (4.0 / 3.0) * Math.PI * Math.Pow(radio, 3);
    }

    public double CalcularDistancia(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}

public class OperacionesConcretas : OperacionesBase
{

}

class Program
{
    static void Main(string[] args)
    {
        IOperaciones operaciones = new OperacionesConcretas();

        Console.WriteLine("Suma: " + operaciones.Sumar(10, 3));
        Console.WriteLine("Resta: " + operaciones.Restar(5, 3));
        Console.WriteLine("Multiplicación: " + operaciones.Multiplicar(5, 3));

        try
        {
            Console.WriteLine("División: " + operaciones.Dividir(10, 2));
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Área de un círculo (radio 5): " + operaciones.CalcularAreaCirculo(5));
        Console.WriteLine("Volumen de una esfera (radio 5): " + operaciones.CalcularVolumenEsfera(5));
        Console.WriteLine("Distancia entre puntos (0,0) y (3,4): " + operaciones.CalcularDistancia(0, 0, 3, 4));
    }
}

