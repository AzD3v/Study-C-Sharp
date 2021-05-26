using System;
using System.Collections.Generic;
using System.Text;

namespace Worker
{
    class Boss : Employee
    {
        public string CompanyCar { get; set; }

        public Boss(string name, string firstName, int salary, string companyCar) : base(name, firstName, salary)
        {
            CompanyCar = companyCar;
        }

        public void Lead()
        {
            Console.WriteLine("{0} {1} is leading!", FirstName, Name);
        }
    }
}
