using System;
using System.Threading;

namespace ThreadJoiningAndIsAlivw
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started");
            Thread thread1 = new Thread(Thread1Function);
            Thread thread2 = new Thread(Thread2Function);
            thread1.Start();
            thread2.Start();

            // Join blocks the calling thread (main thread in this case)
            thread1.Join();
            Console.WriteLine("Thread 1 function done");
            thread2.Join();
            Console.WriteLine("Thread 2 function done");

            Console.WriteLine("Main thread ended");
        }

        public static void Thread1Function()
        {
            Console.WriteLine("Thread1Function started");
        }

        public static void Thread2Function()
        {
            Console.WriteLine("Thread2Function started");
        }
    }
}
