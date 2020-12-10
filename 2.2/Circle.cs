using System;
using System.Collections.Generic;
using System.Text;

namespace _2._2
{
    class Circle : IShape
    {
        private double r;
        public Circle()
        {
            BuildFigure();
        }

        public Circle(double R)
        {
            r = R;
        }
        public void BuildFigure()
        {
            do
            {
                Console.Write("Write radius->");
            }
            while (!(double.TryParse(Console.ReadLine(), out r) && r > 0));
        }

        public double GetArea()
        {
            return Math.Round(Math.PI*r*r,2);
        }
    }
}
