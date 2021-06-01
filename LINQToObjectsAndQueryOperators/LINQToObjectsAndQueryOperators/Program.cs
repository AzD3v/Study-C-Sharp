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
            LibraryManager libraryManager = new LibraryManager();
            // libraryManager.MaleStudents();
            // libraryManager.FemaleStudents();
            // libraryManager.SortReadersByAge();
            // libraryManager.AllReadersFromLibrary1();

            /* int[] someInts = { 30, 12, 4, 3, 12 };
             IEnumerable<int> sortedInts = from i in someInts orderby i select i;
             IEnumerable<int> reversedInts = sortedInts.Reverse();

             foreach (int i in reversedInts)
             {
                 Console.WriteLine(i);
             }

             IEnumerable<int> reversedSortedInts = from i in someInts orderby i descending select i;

             foreach (int i in reversedSortedInts)
             {
                 Console.WriteLine(i);
             }*/

            // Get readers from library id 
            /*string input = Console.ReadLine();
            try
            {
                int inputAsInt = Convert.ToInt32(input);
                libraryManager.FindReadersByLibraryId(inputAsInt);
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong value");
            }*/

            // Get readers from library id - My solution
            /* int id = 0;

             Console.WriteLine("Enter id in order to display all readers from the library with that id:");
             Console.WriteLine("Enter -1 when you're done:");

             do
             {
                 ConsoleKeyInfo UserInput = Console.ReadKey();

                 if (char.IsDigit(UserInput.KeyChar))
                 {
                     id = int.Parse(UserInput.KeyChar.ToString());
                     libraryManager.FindReadersByLibraryId(id);
                     Console.WriteLine("Please choose your next id");
                 }
                 else
                 {
                     Console.WriteLine("Please enter a valid id");
                 }
             // NOT WORKING
             } while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape));

             Console.WriteLine("Thanks for using our found reader program!");
             */

            libraryManager.ReaderAndLibraryNameCollection();

            Console.Read();
        }
    }

    // Class to manage libraries 
    class LibraryManager
    {
        public List<Library> libraries;
        public List<Reader> readers;

        // Constructor
        public LibraryManager()
        {
            libraries = new List<Library>();
            readers = new List<Reader>();

            // Add libraries
            libraries.Add(new Library { Id = 1, Name = "Library 1" });
            libraries.Add(new Library { Id = 2, Name = "Library 2" });

            // Add readers
            readers.Add(new Reader { Id = 1, Name = "Reader A", Gender = "male", Age = 25, LibraryId = 1 });
            readers.Add(new Reader { Id = 2, Name = "Reader D", Gender = "female", Age = 29, LibraryId = 2 });
            readers.Add(new Reader { Id = 3, Name = "Reader B", Gender = "male", Age = 21, LibraryId = 1 });
            readers.Add(new Reader { Id = 4, Name = "Reader C", Gender = "male", Age = 29, LibraryId = 1 });
            readers.Add(new Reader { Id = 5, Name = "Reader E", Gender = "trans-gender", Age = 31, LibraryId = 2 });
        }

        public void MaleStudents()
        {
            IEnumerable<Reader> maleReaders = from reader in readers where reader.Gender == "male" select reader;
            Console.WriteLine("Male - Readers: ");

            foreach (Reader maleReader in maleReaders)
            {
                maleReader.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Reader> femaleReaders = from reader in readers where reader.Gender == "female" select reader;
            Console.WriteLine("Female - readers:");

            foreach (Reader femaleReader in femaleReaders)
            {
                femaleReader.Print();
            }
        }

        public void SortReadersByAge()
        {
            var sortedReaders = from reader in readers orderby reader.Age select reader;

            Console.WriteLine("Readers sorted by age:");

            foreach (Reader reader in sortedReaders)
            {
                reader.Print();
            }
        }
        
        public void AllReadersFromLibrary1()
        {
            IEnumerable<Reader> library1Readers = from reader in readers
                                                  join library in libraries
                                                  on reader.LibraryId equals library.Id
                                                  where library.Name == "Library 1"
                                                  select reader;

            Console.WriteLine("Readers from library 1:");

            foreach (Reader reader in library1Readers)
            {
                reader.Print();
            }
        }

        public void FindReadersByLibraryId(int id)
        {
            IEnumerable<Reader> foundReaders = from reader in readers
                                               join library in libraries
                                               on reader.LibraryId equals library.Id
                                               where library.Id == id
                                               select reader;

            if (foundReaders.Count() == 0)
            {
                Console.WriteLine("No readers found");
                return;
            }

            Console.WriteLine($"Found readers from library with id: {id}");

            foreach (Reader foundReader in foundReaders)
            {
                foundReader.Print();
            }
        }

        public void ReaderAndLibraryNameCollection()
        {
            var newCollection = from reader in readers
                                join library in libraries
                                on reader.LibraryId equals library.Id
                                orderby reader.Name
                                select new { ReaderName = reader.Name, LibraryName = library.Name };

            Console.WriteLine("New collection :");
            foreach (var col in newCollection)
            {
                Console.WriteLine($"Reader {col.ReaderName} from library {col.LibraryName}");
            }
        }
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
