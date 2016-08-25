using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace Library_List
{
    public class CardCatalog
    {
        private string _filename { get; set; }
        private static List<Book> libraryList = new List<Book>();

        public static void Save(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Book>));

            using (var writer = new StreamWriter
                ("C:\\Users\\brian\\OneDrive\\Documents\\Visual Studio 2015\\Projects\\Coding Temple Homework\\" + filename + ".XML"))
            {
                serializer.Serialize(writer, libraryList);
            }
        }


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

        public static void listBooks()
        {
            foreach (Book item in libraryList)
            {
                Console.WriteLine(item.Title + " by " + item.Author);
            }
        }
        public static void addBook(Book bookToAdd)
        {
            libraryList.Add(bookToAdd);
        }

    }
}
