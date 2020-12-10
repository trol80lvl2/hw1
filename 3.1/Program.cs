using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace _3._1
{
    class Program
    {
        static string expression;
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                foreach (var arg in args)
                {
                    expression += arg;
                }
                IList<string> numbers = getNumbersModules(expression);

                if (numbers.Count > 2)
                {
                    return -1;
                }

                string operation = expression;
                foreach (var item in numbers)
                    operation = operation.Replace(item, "");
                if (operation.Length > 1 && operation != "pow")
                {
                    return -1;


                }
                operation = String.IsNullOrEmpty(operation) && numbers.Count == 2 ? "+" : operation;

                if (numbers.Count == 1)
                    Console.WriteLine(performUnaryOperation(numbers[0], operation));
                else if (numbers.Count == 2)
                    Console.WriteLine(performBinaryOperation(numbers[0], numbers[1], operation));
                else
                {
                    return -1;
                }
                    
            }
            else
            {
                Console.WriteLine("Hello there. Use 'exit' to exit program. 'help' for help");
                while (true)
                {
                    Console.Write("->");
                    expression = Console.ReadLine().Replace(" ", "").Replace(",", ".");
                    if (expression.ToLower() == "exit")
                    {
                        Console.WriteLine("Bye! See you later!");
                        break;
                    }
                    if (expression.ToLower() == "help")
                    {
                        ShowHelp();
                    }

                    IList<string> numbers = getNumbersModules(expression);

                    if (numbers.Count > 2)
                    {
                        Console.WriteLine("So much numerics.Try again or use help");
                        continue;
                    }

                    string operation = expression;
                    foreach (var item in numbers)
                    {
                        Regex regex = new Regex(Regex.Escape(item));
                        operation = regex.Replace(operation, "",1);
                    }

                    if (operation.Length > 1 && operation != "pow")
                    {
                        Console.WriteLine("So much operations. Try again or use help");
                        continue;
                    }
                    operation = String.IsNullOrEmpty(operation) && numbers.Count == 2 ? "+" : operation;

                    if (numbers.Count == 1)
                        Console.WriteLine(performUnaryOperation(numbers[0], operation));
                    else if (numbers.Count == 2)
                        Console.WriteLine(performBinaryOperation(numbers[0], numbers[1], operation));
                    else
                        Console.WriteLine("Too long string or so much numerics");
                }
            }
            return 0;
            
        }

        static IList<string> getNumbersModules(string input)
        {
            IList<string> numbers = new List<string>();
            //MatchCollection numbersMatches = Regex.Matches(input, @"-?\d+(\.|,)?(-?\d)*");
            MatchCollection numbersMatches = Regex.Matches(input, @"-?\d+((\.|,)\d+)?");

            foreach (var match in numbersMatches)
                numbers.Add(match.ToString());

            return numbers;
        }

        static string performUnaryOperation(string operand, string operation)
        {
            string result = "";
            switch (operation)
            {
                case "":
                    result = operand;
                    break;
                case "!":
                    result = expression.IndexOf(operation) < expression.IndexOf(operand) ?
                        (~int.Parse(operand)).ToString() : Factorial(int.Parse(operand)).ToString();
                    break;
            }
            return result;
        }

        static string performBinaryOperation(string op1, string op2, string operation)
        {
            string result = "";
            switch (operation)
            {
                case "+":
                    result = (Double.Parse(op1) + Double.Parse(op2)).ToString();
                    break;
                case "-":
                    result = (Double.Parse(op1) - Double.Parse(op2)).ToString();
                    break;
                case "*":
                case "x":
                    result = (Double.Parse(op1) * Double.Parse(op2)).ToString();
                    break;
                case "/":
                case @"\":
                    result = (Double.Parse(op2)==0)?"Dividing by zero":Math.Round((Double.Parse(op1) / Double.Parse(op2)),5).ToString();
                    break;
                case "%":
                    result = (int.Parse(op1) % int.Parse(op2)).ToString();
                    break;
                case "pow":
                    result = (Math.Pow(Double.Parse(op1), Double.Parse(op2))).ToString();
                    break;

                case "&":
                    int intOp1, intOp2;

                    checked
                    {
                        if (!int.TryParse(op1, out intOp1)||(!int.TryParse(op2, out intOp2)))
                        {
                            result = "Should be integer value";
                        }
                        else
                        {
                            result = (int.Parse(op1) & int.Parse(op2)).ToString();
                        } 
                    }
                    break;
                case "|":

                    checked
                    {
                        if (!int.TryParse(op1, out intOp1) || (!int.TryParse(op2, out intOp2)))
                        {
                            result = "Should be integer value";
                        }
                        else
                        {
                            result = (int.Parse(op1) | int.Parse(op2)).ToString();
                        }
                    }
                    break;
                case "^":

                    checked
                    {
                        if (!int.TryParse(op1, out intOp1) || (!int.TryParse(op2, out intOp2)))
                        {
                            result = "Should be integer value";
                        }
                        else
                        {
                            result = (int.Parse(op1) ^ int.Parse(op2)).ToString();
                        }
                    }
                    break;
            }
            return result;
        }

        static string Factorial(int number)
        {
            if (number >= 0)
            {
                if (number == 0)
                {
                    return 1.ToString();
                }
                else
                {
                    checked
                    {
                        number = number * int.Parse(Factorial(number - 1));
                    }     
                }
                return number.ToString();
            }
            else
            {
                return "Factorial cannot be negative";
            }
                
        }
        static void ShowHelp()
        {
            Console.WriteLine("This calculator is for calculation:\nbinary operations (-,+,*,x(the same as *),/,\\(the same as \\),%,pow)(int/double)(+/-); \nbinary bit operations(&,|,^)(int)(+);" +
                "\nunary(!,echo operations(a,-a)(int for '!',int/double for echo))(+ for '!',+/- for echo)\nunary bit(!)(+)");
        }

    }
}
