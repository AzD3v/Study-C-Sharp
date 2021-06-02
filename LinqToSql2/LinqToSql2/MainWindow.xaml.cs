using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqToSql2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSql2.Properties.Settings.MyWorkingDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);
            DeleteHenrique();
        }

        public void InsertLibraries()
        {
            dataContext.ExecuteCommand("delete from Library");

            // Create library - instantiation
            Library library1 = new Library();
            Library library2 = new Library();

            // Add library content
            library1.Name = "Biblioteca Cunha";
            library2.Name = "Biblioteca Municipal";

            // Insert library
            dataContext.Libraries.InsertOnSubmit(library1);
            dataContext.Libraries.InsertOnSubmit(library2);

            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Libraries;
        }

        public void InsertReaders()
        {
            dataContext.ExecuteCommand("delete from Reader");

            // With a lambda expression we can get a library object directly
            Library library1 = dataContext.Libraries.First(li => li.Name.Equals("Biblioteca Cunha"));
            Library library2 = dataContext.Libraries.First(li => li.Name.Equals("Biblioteca Municipal"));
            // The same as 
            // "from library in dataContext.Library where library == "Library1" select library"; 

            List<Reader> readers = new List<Reader>();

            readers.Add(new Reader { Name = "Paulo", Gender = "male", LibraryId = library1.Id });
            readers.Add(new Reader { Name = "Henrique", Gender = "male", Library = library1 });
            readers.Add(new Reader { Name = "Costa", Gender = "male", Library = library2 });
            readers.Add(new Reader { Name = "Cunha", Gender = "male", Library = library2 });

            dataContext.Readers.InsertAllOnSubmit(readers);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Readers;
        }

        public void InsertReadingSessions()
        {
            dataContext.ExecuteCommand("delete from ReadingSession");

            List<ReadingSession> readingSessions = new List<ReadingSession>();

            readingSessions.Add(new ReadingSession { Name = "Morning session " });
            readingSessions.Add(new ReadingSession { Name = "Afternoon session " });
            readingSessions.Add(new ReadingSession { Name = "Evening session " });

            dataContext.ReadingSessions.InsertAllOnSubmit(readingSessions);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.ReadingSessions;
        }

        public void InsertReaderSessionAssociations()
        {
            Reader Paulo = dataContext.Readers.First(rd => rd.Name == "Paulo");
            Reader Henrique = dataContext.Readers.First(rd => rd.Name == "Henrique");
            Reader Costa = dataContext.Readers.First(rd => rd.Name == "Costa");
            Reader Cunha = dataContext.Readers.First(rd => rd.Name == "Cunha");

            ReadingSession MorningSession = dataContext.ReadingSessions.First(rs => rs.Name.Contains("Morning"));
            ReadingSession AfternoonSession = dataContext.ReadingSessions.First(rs => rs.Name.Contains("Afternoon"));
            ReadingSession EveningSession = dataContext.ReadingSessions.First(rs => rs.Name.Contains("Evening"));

            dataContext.ReaderReadingSessions.InsertOnSubmit(new ReaderReadingSession { Reader = Paulo, ReadingSession = EveningSession } );

            ReaderReadingSession rsHenrique = new ReaderReadingSession();
            rsHenrique.Reader = Henrique;
            rsHenrique.ReadingSession = MorningSession;

            dataContext.ReaderReadingSessions.InsertOnSubmit(new ReaderReadingSession { Reader = Costa, ReadingSession = AfternoonSession });
            dataContext.ReaderReadingSessions.InsertOnSubmit(new ReaderReadingSession { Reader = Paulo, ReadingSession = AfternoonSession } );
            dataContext.ReaderReadingSessions.InsertOnSubmit(rsHenrique);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.ReaderReadingSessions;
        }

        public void GetLibraryOfHenrique()
        {
            Reader Henrique = dataContext.Readers.First(rd => rd.Name == "Paulo");
            Library HenriquesLibrary = Henrique.Library;

            List<Library> libraries = new List<Library>();
            libraries.Add(HenriquesLibrary);
        }

        public void GetReadingSessionsFromHenrique()
        {
            Reader Henrique = dataContext.Readers.First(rd => rd.Name == "Henrique");

            // My solution to get all reading sessions from Henrique
            /*IEnumerable<ReadingSession> HenriquesReadingSessions = from readingSession in dataContext.ReadingSessions
                                                      join readerReadingSession in dataContext.ReaderReadingSessions
                                                      on readingSession.Id equals readerReadingSession.ReadingSessionId
                                                      where readerReadingSession.ReaderId == Henrique.Id
                                                      select readingSession;*/

            // Instructor solution to get all reading sessions from Henrique
            var henriquerReadingSessions = from readingSession in Henrique.ReaderReadingSessions select readingSession.ReadingSession;

            MainDataGrid.ItemsSource = henriquerReadingSessions;
        }

        public void GetAllReadersFromLibraryMunicipal()
        {
            // My soltution
            /*Library LibraryMunicipal = dataContext.Libraries.First(lb => lb.Name.Contains("Municipal"));
            var libraryMunicipalReaders = from readers in LibraryMunicipal.Readers select readers;*/

            // Instructor's solution
            var libraryMunicipalReaders = from reader in dataContext.Readers
                                          where reader.Library.Name == "Biblioteca Municipal"
                                          select reader;
            
            MainDataGrid.ItemsSource = libraryMunicipalReaders;
        }

        public void GetAllLibrariesWithMales()
        {
            var malesLibraries = from reader in dataContext.Readers
                                 join library in dataContext.Libraries
                                 on reader.Library equals library
                                 where reader.Gender == "male"
                                 select library;

            MainDataGrid.ItemsSource = malesLibraries;
        }

        public void GetCunhaLibraryReadingSessions()
        {
            // My solution
            /*var cunhaLibraryReadingSessions = from reader in dataContext.Readers
                                 join library in dataContext.Libraries
                                 on reader.Library equals library
                                 where library.Name == "Biblioteca Municipal"
                                 from readingSession in reader.ReaderReadingSessions
                                 select readingSession.ReadingSession;*/

            // Instructor's solution
            var cunhaLibraryReadingSessions = from readingSession in dataContext.ReaderReadingSessions
                                              join reader in dataContext.Readers
                                              on readingSession.ReaderId equals reader.Id
                                              where reader.Library.Name == "Biblioteca Cunha"
                                              select readingSession.ReadingSession;

            MainDataGrid.ItemsSource = cunhaLibraryReadingSessions;
        }

        public void UpdatePaulo()
        {
            Reader Paulo = dataContext.Readers.FirstOrDefault(rd => rd.Name == "Paulo");
            Paulo.Name = "Paulão";
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Readers;
        }

        public void DeleteHenrique()
        {
            Reader Henrique = dataContext.Readers.FirstOrDefault(rd => rd.Name == "Henrique");
            dataContext.Readers.DeleteOnSubmit(Henrique);
            dataContext.SubmitChanges();
        }
    }
}
