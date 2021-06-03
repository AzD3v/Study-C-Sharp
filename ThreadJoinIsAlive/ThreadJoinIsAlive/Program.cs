using System;
using System.Threading;

namespace ThreadJoinIsAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started!");
            
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);

            thread1.Start();
            thread2.Start();

            // Blocks main thread for that time
            if (thread1.Join(1000))
            {
                Console.WriteLine("Thread1Function done");
            }
            else
            {
                Console.WriteLine("Thread1Function wasn't done within 1 second");
            }

            thread2.Join();
            Console.WriteLine("Thread2Function done");

            for (int i = 0; i < 10; i++)
            {
                if (thread1.IsAlive)
                {
                    Console.WriteLine("Thread1 is still doing stuff");
                    Thread.Sleep(300);
                }
                else
                {
                    Console.WriteLine("Thread1 was completed");
                }
            }

            Console.WriteLine("Main thread ended!");
        }

        public static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started!");
            Thread.Sleep(3000);
            Console.WriteLine("Thread1Function coming back to caller");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started!");
        }
    }
}
