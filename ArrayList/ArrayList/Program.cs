using System;
using System.Collections;

namespace ArrayLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring an ArrayList with undefined amount of objects
            ArrayList myArrayList = new ArrayList();

            // With defined amount of objects
            ArrayList myArrayList2 = new ArrayList(100);

            myArrayList.Add(25);
            myArrayList.Add("Hello");
            myArrayList.Add(13.37);
            myArrayList.Add(128);
            myArrayList.Add(25.3);
            
            // Delete element with specific value from the arraylist
            myArrayList.Remove(13.37);

            // Delete element at specific position
            myArrayList.RemoveAt(0);

            Console.WriteLine(myArrayList.Count);

            double sum = 0;

            foreach (object obj in myArrayList)
            {
                if (obj is int)
                {
                    sum += Convert.ToDouble(obj);
                }
                else if (obj is double)
                {
                    sum += (double)obj;
                } else if (obj is string)
                {
                    Console.WriteLine(obj);
                }
            }

            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}
