using System;
using System.Collections.Generic;

namespace StacksQueues
{
    class Program
    {
        // Queues
        static void Main(string[] args)
        {
            Queue<Order> ordersQueue = new Queue<Order>();

            foreach (Order o in RecieveOrdersFromBranch1())
            {
                ordersQueue.Enqueue(o);
            }

            foreach (Order o in RecieveOrdersFromBranch2())
            {
                ordersQueue.Enqueue(o);
            }

            while (ordersQueue.Count > 0)
            {
                Order currentOrder = ordersQueue.Dequeue();
                currentOrder.ProcessOrder();
            }
        }

        static Order[] RecieveOrdersFromBranch1()
        {
            // creating new orders array
            Order[] orders = new Order[]
            {
                new Order(1, 5),
                new Order(2, 4),
                new Order(6, 10),
            };

            return orders;
        }

        static Order[] RecieveOrdersFromBranch2()
        {
            // creating new orders array
            Order[] orders = new Order[]
            {
                new Order(3, 5),
                new Order(4, 4),
                new Order(5, 10),
            };

            return orders;
        }

        // Stacks
        /*  static void Main(string[] args)
          {
              // Defining a new stack
              Stack<int> stack = new Stack<int>();

              if (stack.Count > 0)
              {
                  stack.Pop();
              }

              // Add and remove elements to the stack using Push()
              stack.Push(1);
              Console.WriteLine("Top value in the stack is {0}", stack.Peek());

              stack.Push(2);
              stack.Push(3);
              int myStackItem = stack.Pop();

              // Peek() will return the element at the top of the stack without removing it
              Console.WriteLine("Popped value in the stack is {0}", myStackItem);
              Console.WriteLine("Top value in the stack is {0}", stack.Peek());

              while (stack.Count > 0)
              {
                  stack.Pop();
              }

              stack.TryPeek(out int popped);

              int[] numbers = new int[] { 1, 2, 3 };

              // Defining a new stack of int 
              Stack<int> myStack = new Stack<int>();

              foreach (int number in numbers)
              {
                  myStack.Push(number);
              }

              foreach (int number in myStack)
              {
                  Console.Write(number + " ");
              }
          }*/
    }

    class Order
    {
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }

        public Order(int id, int orderQuantity)
        {
            this.OrderId = id;
            this.OrderQuantity = orderQuantity;
        }

        public void ProcessOrder()
        {
            Console.WriteLine($"Order {OrderId} processed!");
        }
    }
}
