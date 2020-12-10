using System;

namespace _1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("'Bet calculator' made by Roman Holub");
            Console.Write("Enter name of the first team->");
            string team1 = Console.ReadLine();
            Console.Write("Enter name of the second team->");
            string team2 = Console.ReadLine();
            Console.Write("Win 1 team coef->");
            double coef1 = double.Parse(Console.ReadLine());
            Console.Write("X(draw) coef->");
            double coefX = double.Parse(Console.ReadLine());
            Console.Write("Win 2 team coef->");
            double coef2 = double.Parse(Console.ReadLine());
            double perc1_mn = Math.Round(100 / coef1, 2);
            double percX_mn = Math.Round(100 / coefX, 2);
            double perc2_mn = Math.Round(100 / coef2, 2);
            double percGeneral = perc1_mn + percX_mn + perc2_mn;
            double margin = Math.Round(percGeneral - 100,2);

            double perc1 = Math.Round((perc1_mn * 100) / percGeneral, 2);
            double perc2 = Math.Round((perc2_mn * 100) / percGeneral, 2);
            double percX = Math.Round((percX_mn * 100) / percGeneral, 2);

            Console.WriteLine($"\nWin {team1} : {perc1}%");
            Console.WriteLine($"Draw {percX}%");
            Console.WriteLine($"Win {team2} : {perc2}%");
            Console.WriteLine($"Margin : {margin}%");

        }
    }
}
