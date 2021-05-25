using System;
using System.Collections.Generic;

namespace Dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee[] employees =
            {
                new Employee("CEO", "Person1", 95, 2000),
                new Employee("CEO", "Person2", 95, 2000),
                new Employee("CEO", "Person1", 95, 2000),
                new Employee("CEO", "Person1", 95, 2000),
            };

            Dictionary<int, string> myDictionary = new Dictionary<int, string>()
            {
                { 1, "one" },
                { 2, "two" },
                { 3, "three" }
            };

            Dictionary<string, string> employeesDirectory = new Dictionary<int, string>();
        }
    }

    class Employee
{
        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Rate { get; set; }

        public float Salary
        {
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }

        public Employee(string role, string name, int age, float rate)
        {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }
    }
}
