using System;
using System.Collections.Generic;
using System.Text;

namespace singleton
{
    class Team
    {
        private static Team instance = new Team();

        private Team() { }

        public static Team Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Team();
                }
                return instance;
            }
        }

        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
    }
}
