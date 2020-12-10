using System;

namespace _1._4
{
    class Program
    {
       
        static void SimpleNum(int start, int finish)
        {
            for(int i = start; i <= finish; i++)
            {
                if (isSimple(i))
                {
                    Console.Write(i + " ");
                }
            }

        }
        static bool isSimple(int N)
        {
            if (N<2)
                return false;
            for (int i = 2; i <= (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("'Simple nums' made by Roman Holub");
            Console.Write("Enter the left border->");
            int left = int.Parse(Console.ReadLine());
            Console.Write("Enter the right border->");
            int right = int.Parse(Console.ReadLine());

            SimpleNum(left, right);
        }
    }
}
