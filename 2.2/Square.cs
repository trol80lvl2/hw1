using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    class Square : IShape
    {
        public Square()
        {
            BuildFigure();
        }

        public Square(double A)
        {
            a = A;
        }
        private double a;
        public void BuildFigure()
        {
            do
            {
                Console.Write("Write length of first side->");
            }
            while (!(double.TryParse(Console.ReadLine(), out a) && a > 0));
        }

        public double GetArea()
        {
            return Math.Round(a * a,2);
        }
    }
}
