using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQToObjectsAndQueryOperators
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    // Class to manage libraries 
    class LibraryManager
    {
        public List<Library> libraries;
        public List<Reader> readers;
    }

    class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine($"Library {Name} with id {Id}");
        }
    }

    class Reader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign key
        public int LibraryId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with id {Id}, gender {Gender} " + 
                $"and age {Age} from the library {LibraryId}");
        }
    }
}
