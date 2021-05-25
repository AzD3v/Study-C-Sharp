using System;
using System.Collections;
using System.Collections.Generic;

namespace HashtablesChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];
            students[0] = new Student(1, "Paulo", 88);
            students[1] = new Student(2, "Henrique", 97);
            students[2] = new Student(6, "Costa", 65);
            students[3] = new Student(1, "Cunha", 73);
            students[4] = new Student(4, "AzD3v", 58);

            Hashtable studentsTable = CreateHashtable(students);
        }

        static Hashtable CreateHashtable(params Student[] students)
        {
            Hashtable studentsTable = new Hashtable();

            foreach (Student student in students)
            {
                if (!studentsTable.ContainsKey(student.Id))
                {
                    studentsTable.Add(student.Id, student);
                    Console.WriteLine("{0} was added to the hashtable!", student.Name);
                }
                else
                {
                    Console.WriteLine("Sorry, already exists. {0} not added!", student.Name);
                    Console.WriteLine("Will assign a different id to this student");

                    int newId = new Random().Next(5, 13);

                    studentsTable.Add(newId, student);
                    Console.WriteLine("{0} was added to the hashtable! With a new id of {1}", student.Name, newId);
                }


            }

            return studentsTable;
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
