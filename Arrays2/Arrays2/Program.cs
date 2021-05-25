using System;

namespace Arrays2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare jagged array 
            int[][] jaggedArr = new int[3][];

            jaggedArr[0] = new int[5];
            jaggedArr[1] = new int[3];
            jaggedArr[2] = new int[2];

            jaggedArr[0] = new int[] { 2, 3, 5, 7, 11 };
            jaggedArr[1] = new int[] { 1, 2, 3 };
            jaggedArr[2] = new int[] { 13, 21 };

            // alternative way 
            int[][] jaggedArr2 = new int[][]
            {
                new int[] { 2, 3, 5, 7, 11 },
                new int[] { 1, 2, 3}
            };

            Console.WriteLine(jaggedArr2[0][2]);

            for (int i = 0; i < jaggedArr2.Length; i++)
            {
                Console.WriteLine("Element {0}", i);

                for (int j = 0; j < jaggedArr2[i].Length; j++)
                {
                    Console.WriteLine("{0} ", jaggedArr2[i][j]);
                }
            }

            string[][] friendsArray = new string[3][];

            friendsArray[0] = new string[] { "Person1", "Person2" };
            friendsArray[1] = new string[] { "Person2", "Person3" };
            friendsArray[2] = new string[] { "Person4", "Person5" };

            for (int i = 0; i < friendsArray.Length; i++)
            {
                for (int j = 0; j < friendsArray[i].Length; j++)
                {
                    Console.WriteLine("Hi, I'm {0}! Nice to meet you!", friendsArray[i][j]);
                }
            }

        int[] studenstGrades = new int[] { 15, 13, 8, 12, 6, 16 };
            double averageResult = GetAverage(studenstGrades);

            foreach (int grade in studenstGrades)
            {
                Console.WriteLine(" {0} ", grade);
            }

            Console.WriteLine("The average is: {0}", averageResult);

            int[] happiness = { 2, 4, 4, 5, 6 };
            SunIsShining(happiness);

            foreach (int y in happiness)
            {
                Console.WriteLine(y);
            }

            Console.ReadLine();
        }

        static void SunIsShining(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] += 2;
            }
        }

        static double GetAverage(int[] gradesArray)
        {
            int size = gradesArray.Length;
            double average;
            int sum = 0;

            for (int i = 0; i < size; i++)
            {
                sum += gradesArray[i];
            }

            average = (double)sum / size;
            return average;
        }
    }
}
