﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingLesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Hello World! 1");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World! 2");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World! 3");
            Thread.Sleep(1000);
            Console.WriteLine("Hello World! 4");*/

            // Create new thread
            /*  new Thread(() =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("Thread 1");
              }).Start();

              new Thread(() =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("Thread 2");
              }).Start();

              new Thread(() =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("Thread 3");
              }).Start();

              new Thread(() =>
              {
                  Thread.Sleep(1000);
                  Console.WriteLine("Thread 4");
              }).Start();*/

            new Thread(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Thread 4");
            })
            { IsBackground = true }.Start();

            // Enumerable creaates multiples threads
            Enumerable.Range(0, 1000).ToList().ForEach(f =>
            {
                ThreadPool.QueueUserWorkItem((o) =>
                {
                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
                    Thread.Sleep(1000);

                    Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
                });
            });
            
            Console.ReadLine();
        }
    }
}
