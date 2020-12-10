using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    class Rectangle : IShape
    {
        private double a, b;

        public Rectangle()
        {
            BuildFigure();
        }

        public Rectangle(double A, double B)
        {
            a = A;
            b = B;
        }

        public void BuildFigure()
        {
            
            do
            {
                Console.Write("Write length of first side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out a)&&a>0));

            do
            {
                Console.Write("Write length of second side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out b) && b > 0));

        }

        public double GetArea()
        {
            return Math.Round(a * b,2);
        }
    }
}
