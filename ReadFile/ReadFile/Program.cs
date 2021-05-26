using System;
using System.IO;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Method 1
            string[] lines = { "first line", "Second line", "Third line" };
            string[] highScores = { "First 200", "Second 100", "Third 50" };

            /*ile.WriteAllLines(@"C:\Users\Paulo\Desktop\textFile2.txt", lines);
            File.WriteAllLines(@"C:\Users\Paulo\Desktop\highScores.txt", highScores);*/

            // Method 2
            /*Console.WriteLine("Please give a file name");
            string fileName = Console.ReadLine();

            Console.WriteLine("Please enter text for file");
            string input = Console.ReadLine();

            File.WriteAllText(@"C:\Users\Paulo\Desktop\" + fileName + ".txt", input);*/


            // method 3 - stream writer opens and closes by itself
            using (StreamWriter file = new StreamWriter(@"C:\Users\Paulo\Desktop\myText2.txt"))
            {
                foreach (string line in lines)
                {
                    if (line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            }

            using (StreamWriter file = new StreamWriter(@"C:\Users\Paulo\Desktop\myText2.txt", true))
            {
                file.WriteLine("Additional loine");
            }

                /*string text = System.IO.File.ReadAllText(@"C:\Users\Paulo\Desktop\textFile.txt");
                Console.WriteLine(text);

                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Paulo\Desktop\textFile.txt");

                Console.WriteLine("Contents of textfile.txt = ");

                foreach (string line in lines)
                {
                    Console.WriteLine("\t" + line);
                }*/

                Console.ReadLine();
        }
    }
}
