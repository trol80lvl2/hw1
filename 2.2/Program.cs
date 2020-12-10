using System;

namespace _2._2
{
    class Program
    {
        static int Main(string[] args)
        {
            IShape shapeI;
            string shape;
            double area=0;

            if (args.Length > 1)
            {
                shape = args[0];
                if (shape.ToLower() != "circle" && shape.ToLower() != "square" && shape.ToLower() != "triangle" && shape.ToLower() != "rectangle")
                {
                    return -1;
                }
                else
                {
                    switch (shape)
                    {
                        case "circle":
                            double r;
                            if ((double.TryParse(args[1], out r))&&(r > 0))
                            {
                                shapeI = new Circle(r);
                                area = shapeI.GetArea();
                            }
                            break;
                        case "square":
                            double a;
                            if ((double.TryParse(args[1], out a))&&(a > 0))
                            {
                                shapeI = new Square(a);
                                area = shapeI.GetArea();
                            }
                            break;
                        case "triangle":
                            double A, B, C;
                            if((double.TryParse(args[1], out A)) && (double.TryParse(args[2], out B)) && (double.TryParse(args[3], out C)) && (A > 0) && (B > 0) && (C > 0)){
                                shapeI = new Triangle(A, B, C);
                                area = shapeI.GetArea();
                            }
                            break;
                        case "rectangle":
                            if ((double.TryParse(args[1], out A)) && (double.TryParse(args[2], out B)) && (A > 0) && (B > 0))
                            {
                                shapeI = new Rectangle(A, B);
                                area = shapeI.GetArea();
                            }

                            break;
                    }
                    if (area != 0)
                    {
                        Console.WriteLine(area);
                    }
                    else
                    {
                        return -1;
                    }
                }
             }
            else
            {
                Console.WriteLine("'Area calculator' made by Roman Holub");
                Console.WriteLine("To get area of figure enter name of figure \navaliable figures:\ncircle\nrectangle\ntriangle\nsquare\nand default dimensions of this one:\n" +
                    "square a, rectangle a b, circle r, triangle a b c;");
                Console.Write("Enter shape->");
                while (true)
                {
                    shape = Console.ReadLine();
                    if (shape.ToLower() != "circle" && shape.ToLower() != "square" && shape.ToLower() != "triangle" && shape.ToLower() != "rectangle")
                    {
                        Console.WriteLine("Incorrect shape. Try again"); //тут має бути вивод правил, які я ще не придумав
                        continue;
                    }
                    switch (shape)
                    {
                        case "circle":
                            shapeI = new Circle();
                            area = shapeI.GetArea();
                            break;
                        case "square":
                            shapeI = new Square();
                            area = shapeI.GetArea();
                            break;
                        case "triangle":
                            shapeI = new Triangle();
                            area = shapeI.GetArea();
                            break;
                        case "rectangle":
                            shapeI = new Rectangle();
                            area = shapeI.GetArea();
                            break;
                        default:
                            area = 0;
                            break;
                    }
                    if(area!=0)
                        Console.WriteLine($"The area of {shape} is {area}");
                    else if (area == 0 && shape == "triangle")
                    {
                        Console.WriteLine("Sum of 2 sides <= then 3rd");
                    }
                }
                
            }
            return 0;
            
        }
    }
}
