/*using System;
using System.Collections.Generic;
using System.Text;

namespace HashtablesChallenge
{
    class Class1
    {
        static void Main(string[] args)
        {
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

            // retrieve individual item with know ID
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
}
}
*/