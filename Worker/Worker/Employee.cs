using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    class Employee
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int Salary { get; set; }

        public Employee(string name, string firstName, int salary)
        {
            Name = name;
            FirstName = firstName;
            Salary = salary;
        }

        public virtual void Work()
        {
            Console.WriteLine("{0} {1} is currently working!", FirstName, Name);
        }

        public void Pause()
        {
            Console.WriteLine("{0} {1} stopped working!", FirstName, Name);
        }
    }
}
