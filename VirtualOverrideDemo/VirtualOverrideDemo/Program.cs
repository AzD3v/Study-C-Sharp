using System;

namespace VirtualOverrideDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Snuffles", 15);
            Console.WriteLine($"{dog.Name} is {dog.Age} years old!");
            dog.MakeSound();
            dog.Play();
            dog.Eat();
        }
    }
}
