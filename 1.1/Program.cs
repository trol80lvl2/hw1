using System;

namespace _1._1
{
    class Program
    {
        static void Main(string[] args)
        {
           int a, b = 2001 ,c = 3,  d = 30;
            Console.WriteLine("'Expression calculation' made by Roman Holub");
            Console.WriteLine($"Expression: (Math.Pow(Math.E, a)+4*Math.Log10(c))/Math.Sqrt(b)*Math.Abs(Math.Atan(d))+(5/Math.Sin(a)), \nWhere b={b},c={c},d={d}");
            Console.Write("Please, write a->");
            int.TryParse(Console.ReadLine(), out a);
            double res = (Math.Pow(Math.E, a)+4*Math.Log10(c))/Math.Sqrt(b)*Math.Abs(Math.Atan(d))+(5/Math.Sin(a));
            Console.WriteLine(Math.Round(res,4));
        }
    }
}
