using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    class Trainee : Employee
    {
        public int WorkHours { get; set; }
        public int SchoolHours { get; set; }

        public Trainee(string name, string firstName, int salary, int workHours, int schoolHours) : base(name, firstName, salary)
        {
            WorkHours = workHours;
            SchoolHours = schoolHours;
        }

        public void Learn()
        {
            Console.WriteLine("{0} {1} is learning!", FirstName, Name);
        }

        public override void Work()
        {
            Console.WriteLine("Trainee called {0} {1} currently working hours: {2}h", FirstName, Name, WorkHours);
        }
    }
}
