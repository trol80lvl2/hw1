using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._1
{
    class Program
    {
        static void CompareWeapons(string weaponU,string weaponC)
        {
            char winner;
            if (weaponU == weaponC) winner = 'x';
        }
        static void Main(string[] args)
        {
            string[] weapons = new string[] { "rock", "scissors", "paper" };
            Random random = new Random();
            string choisePl, choiseComp;
            List<History> history = new List<History>();
            Console.WriteLine("'Rock-paper-scissors' made by Roman Holub");
            Console.WriteLine("Hello there. Let's play the game. Rules are very simple:\nYou have 3 options of 'weapons': rock, paper, scissors;\nrock=rock, rock>scissors, rock<paper\n" +
                "scissors=scissors, scissors>paper, scissors<rock\npaper=paper, paper>rock, paper<scissors\nCommands:rock, paper, scissors, exit");

            while (true)
            {
                Console.Write("Enter your weapon->");
                choisePl = Console.ReadLine();
                if (choisePl == "exit") break;
                if (choisePl != "rock" && choisePl != "scissors" && choisePl != "paper")
                {
                    Console.WriteLine("Enter correct weapon");
                    continue;
                }

                choiseComp = weapons[random.Next(0, 3)];
                Console.WriteLine($"I choose {choiseComp}");

                switch (choisePl)
                {
                    case "rock":
                        if (choiseComp == "scissors")
                        {
                            Console.WriteLine("You won. Congratulations!");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "You won" });
                            continue;

                        }
                        else if (choiseComp == "paper")
                        {
                            Console.WriteLine("You lose. Try again");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Computer won" });
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Draw");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Draw" });
                            continue;
                        }
                    case "scissors":
                        if (choiseComp == "paper")
                        {
                            Console.WriteLine("You won. Congratulations!");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "You won" });
                            continue;

                        }
                        else if (choiseComp == "rock")
                        {
                            Console.WriteLine("You lose. Try again");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Computer won" });
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Draw");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Draw" });
                            continue;
                        }
                    case "paper":
                        if (choiseComp == "rock")
                        {
                            Console.WriteLine("You won. Congratulations!");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "You won" });
                            continue;

                        }
                        else if (choiseComp == "scissors")
                        {
                            Console.WriteLine("You lose. Try again");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Computer won" });
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Draw");
                            history.Add(new History { choiseComp = choiseComp, choisePl = choisePl, result = "Draw" });
                            continue;
                        }
                }
            }
            if (history.Count >= 1)
            {
                foreach(var item in history)
                {
                    Console.WriteLine($"Your turn {item.choisePl}, computer turn {item.choiseComp}, result:{item.result}");
                }
                double winRate = ((from s in history
                                   where s.result == "You won"
                                   select s).Count());

                Console.WriteLine($"\nWin rate is {Math.Round((double)winRate / history.Count * 100,2)}%");
            }

            }
        }
    }
