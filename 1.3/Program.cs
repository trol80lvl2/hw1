using System;

namespace _1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            double year = 2001,i=1;
            double res = 0, sum = 0;
            Console.WriteLine("'Series sum' made by Roman Holub");
            Console.WriteLine("Series: E = 1 / (i * (i + 1)), while Epsilon >= 1/2001 ");
            do
            {
                res = 1 / (i * (i + 1));
                sum += res;
                i++;
            }
            while (!(res < (1 / year)));
            Console.WriteLine($"Sum = {sum}");

        }


        
    }
}
