using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
   
    class Program
    {
        public static List<User> user_list = new List<User>();
        public static List<Book> book_list = new List<Book>();
        public static List<Borrower> borrower_list = new List<Borrower>();
        public static List<Submiter> submitter_list = new List<Submiter>();

       /* public static MySqlConnection conn;
        MySqlCommand cmd*/
        static void Main(string[] args)
        {
            /*conn = DBHelper.createConnection("127.0.0.1", "User", "root", "");
            if (conn != null)
                Console.WriteLine("Database Connected.");
            else
                return*/;

            while (true)
            {
                Console.WriteLine("Choose options.");
                Console.Write("1.Add User \n2.Add Book \n3.Show Books \n4.Show Users \n5.Issue Book \n6.Submit Book \n7.Show Borrower\n8.Show Submitter\n9.Terminate\nInput =>");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 9)
                    break;

                LibraryUtility libraryUtility = new LibraryUtility();

            
                switch (choice)
                {
                    case 1: Console.WriteLine(libraryUtility.AddNewUser());
                        break;
                    case 2:
                        Console.WriteLine(libraryUtility.AddNewBook());
                        break;
                    case 3:
                        libraryUtility.showBooks();
                        break;
                    case 4:
                        libraryUtility.showUsers();
                        break;
                    case 5:
                        Console.WriteLine(libraryUtility.issue_book());
                        break;
                    case 6:
                        Console.WriteLine(libraryUtility.submit_book());
                        break;
                    case 7:
                        libraryUtility.showBorrowers();
                        break;
                    case 8:
                        libraryUtility.showSumbitters();
                        break;

                    default:
                        Console.WriteLine("Input mismatch");
                        break;
                }
            }

        }
    }
}
