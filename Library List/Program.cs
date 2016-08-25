using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_List
{
    class Program
    {
        static void Main(string[] args)
        {

            int choice;

            Console.WriteLine("Hello!");
            
            //menu
            do
            {
                Console.WriteLine("\n Press 1 to Add a Book" +
                                  "\n Press 2 to List All Books" +
                                  "\n Press 3 to Save to File" +
                                  "\n Press 4 to Retrieve" +
                                  "\n Press 5 to Exit" +
                                  "\n");

                bool number = Int32.TryParse(Console.ReadLine(), out choice);

                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Book Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Author:");
                    string author = Console.ReadLine();
                    Book bookToAdd = new Book(name, author);
                    CardCatalog.addBook(bookToAdd);
                    Console.Clear();
                    Console.WriteLine("Adding " + name + " by " + author + ". What's next?");
                }

                else if (choice == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Your list includes:");
                    CardCatalog.listBooks();
                    Console.WriteLine("What's next?");
                }

                else if (choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Provide a file name for your book list.");
                    string filename = Console.ReadLine();
                    CardCatalog.Save(filename);
                    Console.Clear();
                    Console.WriteLine("File Saved to " + filename + ". Press Enter for Menu.");
                }

                else if (choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Provide a file name for retrieval.");
                    string filename = Console.ReadLine();
                    CardCatalog.RetrieveList(filename);
                    Console.Clear();
                    Console.WriteLine("List retrieved. What's next?");
                 }

                else if (choice == 5)
                {
                    Console.WriteLine("\nThanks for coming to the library. So long.");
                    System.Threading.Thread.Sleep(2500);
                    break;
                }
                else
                {
                    Console.WriteLine("Valid choices are numbers 1 - 5. Try again.");
                }

            } while (choice != 5);
        }
    }
}
