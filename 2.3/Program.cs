using System;

namespace _2._3
{
    class Program
    {
        static int Main(string[] args)
        {
            if(args.Length > 1){
                int[] arr = new int[args.Length];
                for(int i = 0; i < args.Length; i++)
                {
                    if (!int.TryParse(args[i], out arr[i]))
                    {
                        return -1;
                    }   
                }
                Console.WriteLine(MinElement(arr));
                Console.WriteLine(MaxElement(arr));
                Console.WriteLine(SumElements(arr));
                Console.WriteLine(Average(arr));
                Console.WriteLine(Deviation(arr));
                int[] sortedArr = SortArray(arr);
                foreach (var item in sortedArr)
                {
                    Console.Write(item + " ");
                }
                

            }
            else
            {
                Console.WriteLine("'Array statistics' made by Roman Holub");
                int n;
                Console.WriteLine("Program 'array statistic' made by Roman Holub");
                do
                {
                    Console.Write("Enter size of array->");
                }
                while (!int.TryParse(Console.ReadLine(), out n));

                int[] arr = new int[n];

                for(int i = 0; i < n; i++)
                {
                    Console.Write($"Enter item #{i+1}->");
                    if (!int.TryParse(Console.ReadLine(), out arr[i]))
                    {
                        i -= 1;
                        continue;
                    }
                }
               
                Console.WriteLine($"\nMax number is {MaxElement(arr)}");
                Console.WriteLine($"Min number is {MinElement(arr)}");
                Console.WriteLine($"Sum of elements is {SumElements(arr)}");
                Console.WriteLine($"Average is {Average(arr)}");
                Console.WriteLine($"Deviation {Deviation(arr)}\n");
                int[] sortedArr = SortArray(arr);
                Console.Write("Sorted array: [");
                foreach (var number in sortedArr)
                {
                    Console.Write($"{number} ");
                }
                Console.Write("];");
                
            }
            return 0;
        }

        public static int MaxElement(int[] numbers)
        {
            int maxNumber=int.MinValue;
            foreach(var number in numbers)
            {
                if (number > maxNumber) maxNumber = number;
            }
            return maxNumber;
        }
        public static int MinElement(int[] numbers)
        {
            int minNumber = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < minNumber) minNumber = number;
            }
            return minNumber;
        }
        public static int SumElements(int[] numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        public static double Average(int[] numbers)
        {
            return Math.Round((double)SumElements(numbers) / numbers.Length,2);
        }
        public static double Deviation(int[] numbers)
        {
            double M = 0.0;
            double S = 0.0;
            int k = 1;
            foreach (double value in numbers)
            {
                double tmpM = M;
                M += (value - tmpM) / k;
                S += (value - tmpM) * (value - M);
                k++;
            }
            return Math.Round(Math.Sqrt(S / (k - 1)),2);
        }
        public static int[] SortArray(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
            return nums;
        }

    }
}
