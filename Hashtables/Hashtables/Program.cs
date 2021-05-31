using System;
using System.Collections;

namespace Hashtables
{
    internal class Person
    {
        static Person current;

        private Person()
        {

        }
        public static Person Current { 
            get {
                if (current == null)
                {
                    current = new Person();
                }

                return current;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {       
            object text = null;
            int a = 1;
            int b = a;

            b = 3;

            Person.Current.;


            if (text is string a)
            {
                int.Parse(a)
            }


            Hashtable studentsTable = new Hashtable();

            Student stud1 = new Student(1, "Paulo", 50);
            Student stud2 = new Student(1, "Henrique", 30);
            Student stud3 = new Student(1, "Costa", 71);
            Student stud4 = new Student(1, "Cunha", 20);

            studentsTable.Add(stud1.Id, stud1);
            studentsTable.Add(stud2.Id, stud2);
            studentsTable.Add(stud3.Id, stud3);
            studentsTable.Add(stud4.Id, stud4);
            studentsTable.Add(stud4.Id, stud4);

            // retrieve individual item with known ID
            Student storedStudent1 = (Student)studentsTable[stud1.Id];

            // retrieve all values from a hashtable
            foreach (DictionaryEntry entry in studentsTable)
            {
                Student temp = (Student)entry.Value;
                Console.WriteLine("Student ID: {0}", temp.Id);
            }

            foreach (Student value in studentsTable.Values)
            {
                Console.WriteLine("Student ID: {0}", value.Id);
            }
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float GPA { get; set; }

        public Student(int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }
}
