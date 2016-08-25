using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Library_List
{
    /// <summary>
    /// contains methods accessed from program
    /// </summary>
    public class CardCatalog
    {
        private string _filename { get; set; }
        private static List<Book> libraryList = new List<Book>();

        /// <summary>
        /// serializes and saves book list to xml file (gotten from user)
        /// </summary>
        /// <param name="filename"></param>
        public static void Save(string filename)
        {
            // Create an instance of the XmlSerializer specifying type.
            var serializer = new XmlSerializer(typeof(List<Book>));

            // Create a TextReader to read the file and designate destination. 
            using (var writer = new StreamWriter
                ("C:\\Users\\brian\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\Coding Temple Homework\\" + filename + ".XML"))
            {
                serializer.Serialize(writer, libraryList);
            }
        }

        /// <summary>
        /// retrieves and deserializes xml file to book list list
        /// </summary>
        /// <param name="filename"></param>
        public static void RetrieveList(string filename)
        {

            // Create an instance of the XmlSerializer specifying type.
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            // Create a TextReader to read the file and designate destination. 
            FileStream fs = new FileStream("C:\\Users\\brian\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\Coding Temple Homework\\" + filename + ".XML", FileMode.OpenOrCreate);
            TextReader reader = new StreamReader(fs);

            // Use the Deserialize method to restore the object's state.
            libraryList = (List<Book>)serializer.Deserialize(reader);
        }

        /// <summary>
        /// lists each item in book list
        /// </summary>
        public static void listBooks()
        {
            foreach (Book item in libraryList)
            {
                Console.WriteLine(item.Title + " by " + item.Author);
            }
        }

        /// <summary>
        /// adds book to list
        /// </summary>
        /// <param name="bookToAdd"></param>
        public static void addBook(Book bookToAdd)
        {
            libraryList.Add(bookToAdd);
        }
    }
}
