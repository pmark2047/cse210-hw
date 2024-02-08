using System;
using System.Net.Http.Headers;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        Fraction Fraction_1 = new Fraction();
        Console.WriteLine(Fraction_1.GetFractionString());
        Console.WriteLine(Fraction_1.GetDecimcalValue());

        Fraction Fraction_2 = new Fraction(5);
        Console.WriteLine(Fraction_2.GetFractionString());
        Console.WriteLine(Fraction_2.GetDecimcalValue());

        Fraction Fraction_3 = new Fraction(3, 4);
        Console.WriteLine(Fraction_3.GetFractionString());
        Console.WriteLine(Fraction_3.GetDecimcalValue());

        Fraction Fraction_4 = new Fraction(1, 3);
        Console.WriteLine(Fraction_4.GetFractionString());
        Console.WriteLine(Fraction_4.GetDecimcalValue());
    }
}