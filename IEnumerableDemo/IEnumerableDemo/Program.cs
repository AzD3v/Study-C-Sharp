using System;
using System.Collections.Generic;

namespace IEnumerableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating a generic IEnumerable variable that takes any collection of type int
            // We will use this variable to store the collections that will get returned by the GetCollection() method
            IEnumerable<int> unkownCollection;
            unkownCollection = GetCollection(1);

            // Foreach number in the collection we got back from GetCollection(1)
            foreach (int num in unkownCollection)
            {
                Console.WriteLine(num + " ");
            }

            Console.WriteLine("");

            // Call GetCollection() with option 2 which will return a Queue<int>
            // But will store it in the base type of generic collections
            unkownCollection = GetCollection(2);

            // Foreach number in the collection we got back from GetCollection(2)
            foreach (int num in unkownCollection)
            {
                Console.WriteLine(num + " ");
            }
        }

        static IEnumerable<int> GetCollection(int option)
        {
            List<int> numbersList = new List<int>() { 1, 2, 3, 4, 5 };

            Queue<int> numbersQueue = new Queue<int>();
            numbersQueue.Enqueue(6);
            numbersQueue.Enqueue(7);
            numbersQueue.Enqueue(8);
            numbersQueue.Enqueue(9);
            numbersQueue.Enqueue(10);

            if (option == 1)
            {
                return numbersList;
            } 
            else if (option == 2)
            {
                return numbersQueue;
            } 
            else
            {
                return new int[] { 11, 12, 13, 14, 15 };
            }
        }
    }
}
