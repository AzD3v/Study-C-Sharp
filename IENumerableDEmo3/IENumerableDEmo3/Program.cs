using System;
using System.Collections.Generic;

namespace IENumerableDEmo3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = new List<int>() { 8, 6, 2 };
            int[] numberArray = new int[] { 1, 7, 1, 3 };
        }

        static void CollectionSum(INumerable<int> anyCollection)
        {
            int sum = 0;

            foreach (int num in anyCollection)
            {
                sum += sum;
            }

            Console.WriteLine("Sum is {0}", sum);
        }
    }
}
