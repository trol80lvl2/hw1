using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    class Triangle : IShape
    {
        private double a, b, c, p;
        public Triangle()
        {
            BuildFigure();
        }
        public Triangle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
            p = (a + b + c) / 2;
        }
        public void BuildFigure()
        {
            do
            {
                Console.Write("Write length of first side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out a) && a > 0)) ;

            do
            {
                Console.Write("Write length of second side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out b) && b > 0));

            do
            {
                Console.Write("Write length of third side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out c) && c > 0));
            p = (a + b + c) / 2;
        }

        public double GetArea()
        {
            if (isExist())
                return Math.Round(Math.Sqrt(p * (p - a) * (p - b) * (p - c)), 2);
            else
                return 0;
        }

        public bool isExist()
        {
            return ((a + b > c) && (a + c > b) && (b + c > a)) ? true : false;
        }

    }
}
