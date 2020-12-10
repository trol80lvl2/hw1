using System;
using System.Diagnostics;

namespace _2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = 0, max = 1000000;
            int minUser, maxUser;
            double score;
            int inputUser=-1;
            int attempt = 0;
            Random random = new Random();
            int randomNumber;
            Console.WriteLine("'More or less' made by Roman Holub\n");
            Console.WriteLine($"Rules:\n\tYou should enter range for the game. Min value for the range is {min}, max value is {max}.\n\tRange for example: min = {min}, max = {max} \n\t-" +
                $"Computer comes up with a number and proposes to guess this one\n\t-After game, you will get your score.\n\t-If you want to quit write 'exit' to any field.\nLet's start\n");
            while (true)
            {
                do
                {
                    Console.Write("Enter left border->");
                }
                while (!int.TryParse(Console.ReadLine(), out minUser));

                if (minUser < 0)
                {
                    Console.WriteLine("Border less than 0");
                    continue;
                }

                do
                {
                    Console.Write("Enter right border->");
                }
                while (!int.TryParse(Console.ReadLine(), out maxUser));

                if (maxUser > 1000000)
                {
                    Console.WriteLine("Border more than 1000000");
                    continue;
                }

                bool isGameGoind=false;
                if (maxUser>minUser)
                    isGameGoind = true;
                else
                {
                    Console.WriteLine("Right border < left border");
                }
                
                while (isGameGoind)
                {
                    Stopwatch sw = new Stopwatch();
                    randomNumber = random.Next(minUser, maxUser + 1);
                    sw.Start();
                    Console.WriteLine("Okay, now try to guess the number");
                    while (inputUser != randomNumber)
                    {
                        
                        Console.Write("Enter your number->");
                        string input = Console.ReadLine();
                        
                        if (input.ToLower() == "exit")
                        {
                            Console.WriteLine("Your score is 0. Bye!");
                            Process.GetCurrentProcess().Kill();
                        }
                            
                        if(!int.TryParse(input,out inputUser))
                        {
                            Console.WriteLine("Invalid input. Try again");
                            continue;
                        }

                        if (inputUser < minUser || inputUser > maxUser)
                        {
                            Console.WriteLine("Are you kidding? Not your borders");
                        }
                        else if (randomNumber > inputUser)
                        {
                            Console.WriteLine("More");
                            attempt++;
                        }
                        else if(randomNumber<inputUser)
                        {
                            Console.WriteLine("Less");
                            attempt++;
                        }
                        else
                        {
                            sw.Stop();
                            score = 100 * (GetNearestPow((maxUser - minUser)+1) - attempt) / GetNearestPow((maxUser - minUser)+1);
                            if (score <= 0)
                                score = 1;
                            Console.WriteLine($"Congratulations, your score {Math.Round(score)}");
                            Console.WriteLine($"Attempts {attempt}");
                            Console.WriteLine($"Time you've been played {sw.ElapsedMilliseconds / 1000} second(s)");
                            Console.WriteLine($"Let's play again");
                        }
                        isGameGoind = false;
                           
                    }
                }
            }

        }
        //GetNearestPow()
        public static int GetNearestPow(int number)
        {
            //rewrite
            int counter=0;
            int nearest;
            int num = number;

            while ((num /= 2) >= 1)
            {
                counter++;
                //number /= 2;
            }
            int minPow = (int)Math.Pow(2, counter);
            int maxPow = (int)Math.Pow(2, counter + 1);

            if (Math.Abs(number - minPow) <= Math.Abs(number - maxPow))
            {
                nearest = counter;
            }
            else
            {
                nearest = counter+1;
            }
            return nearest;
        }



    }
}
