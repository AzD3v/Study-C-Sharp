using System;
using System.Linq;
using System.Xml.Linq;

namespace LinkWithXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentsXML =
                        @"<Students>
                            <Student>
                                <Name>Toni</Name>
                                <Age>21</Age>
                                <University>Uni 1</University>
                                <Semester>6</Semester>
                                <IdiotMeter>10</IdiotMeter>
                            </Student>
                            <Student>
                                <Name>Carla</Name>
                                <Age>17</Age>
                                <University>Uni 2</University>
                                <Semester>1</Semester>
                                <IdiotMeter>9</IdiotMeter>
                            </Student>
                            <Student>
                                <Name>Leyla</Name>
                                <Age>19</Age>
                                <University>Uni 3</University>
                                <Semester>3</Semester>
                                <IdiotMeter>10</IdiotMeter>
                            </Student>
                            <Student>
                                <Name>Frank</Name>
                                <Age>25</Age>
                                <University>Uni 4</University>
                                <Semester>10</Semester>
                                <IdiotMeter>8</IdiotMeter>
                            </Student>
                            <Student>
                                <Name>Paulo</Name>
                                <Age>24</Age>
                                <University>Uni of life</University>
                                <Semester>10</Semester>
                                <IdiotMeter>11</IdiotMeter>
                            </Student>
                        </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Semester = student.Element("Semester").Value,
                               IdiotMeter = student.Element("IdiotMeter").Value,
                           };

            var sortedStudents = from student in students
                                 orderby student.Age
                                 select student;
                                 

            foreach (var student in students)
            {
                Console.WriteLine("Student {0} with age {1} from univeversity of {2} has an idiot meter of {3}", student.Name, student.Age, student.University, student.IdiotMeter);
            }

            foreach (var student in sortedStudents) 
            {
                Console.WriteLine($"student {student.Name} with age of {student.Age}");
            }
        }
    }
}
