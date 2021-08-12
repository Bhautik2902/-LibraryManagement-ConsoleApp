using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagement
{
    public class Book
    {
        public string book_id { get; }
        public string book_name { get; }
        public string author { get; }
        public double price { get; }
        public bool isAvailable { get; set; }

        public Book(string book_id, string book_name, string author, double price)
        {
            this.book_id = book_id;
            this.book_name = book_name;
            this.author = author;
            this.price = price;
            isAvailable = true;
        }
    }

    public class User
    {
        public string user_id;
        public string username;
        public string contact_no;

        public User(string user_id, string username, string contact_no)
        {
            this.user_id = user_id;
            this.username = username;
            this.contact_no = contact_no;
        }
    }

    public class Borrower
    {
        public string borrower_id;
        public string book_id;
        public DateTime issue_date;
        public DateTime return_date;

        public Borrower(string borrower_id, string book_id, DateTime issue_date, DateTime return_date)
        {
            this.borrower_id = borrower_id;
            this.book_id = book_id;
            this.issue_date = issue_date;
            this.return_date = return_date;
        } 
    }

    public class Submiter
    {
        public string book_id;
        public string user_id;
        public DateTime return_dt;
        
        public Submiter(string book_id, string user_id, DateTime return_dt)
        {
            this.book_id = book_id;
            this.user_id = user_id;
            this.return_dt = return_dt;
        }
    }
    class LibraryUtility
    {
        public string AddNewUser()
        {
            try
            {
                Console.Write("Add User Name: ");
                string username = Console.ReadLine();
                Console.Write("Add Contact No.: ");
                string contact_no = Console.ReadLine();
                string userid = username + "_" + contact_no.Substring(0, 5);
                Program.user_list.Add(new User(userid, username, contact_no));
                return "Data added successfully!";
            }
            catch (Exception e)
            {
                return "Error occured. Reason:" + e;
            }
            
        }

        public string AddNewBook()
        {
            try
            {
                Console.Write("Add Book name: ");
                string book_name = Console.ReadLine();
                Console.Write("Add Author name: ");
                string author = Console.ReadLine();
                Console.Write("Add a price of a book: ");
                double price = Convert.ToDouble(Console.ReadLine());
                string bookid = "";

                if (book_name.Length >= 3 && author.Length >= 3)
                {
                   bookid = book_name.Substring(0, 3) + "_" + author.Substring(0, 3);
                }
                else
                {
                    bookid = book_name + "_" + author;
                }
                Program.book_list.Add(new Book(bookid, book_name, author, price));
                return "Data added successfully!";
            }
            catch (Exception e)
            {
                return "Error occured. Reason:" + e;
            }
        }

        public void showBooks()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Book ID\t\tBook Name\t\tBook Author\t\tPrice\t\tAvailable\n");

            foreach (Book b in Program.book_list)
            {
                s.Append($"{b.book_id}\t\t{b.book_name}\t\t{b.author}\t\t{b.price}\t\t{b.isAvailable}\n");
            }
            Console.WriteLine(s);
        }

        public void showUsers()
        {
            StringBuilder s = new StringBuilder();
            s.Append("User Id\t\t\tUser Name\t\tContact No\n");

            foreach(User u in Program.user_list)
            {
                s.Append($"{u.user_id}\t\t{u.username}\t\t{u.contact_no}\n");
            }

            Console.WriteLine(s);
        }

        public void showBorrowers()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Borrower Id\t\t\tBook ID\t\tIssue Date\t\tReturn Date\n");

            foreach (Borrower u in Program.borrower_list)
            {
                s.Append($"{u.borrower_id}\t\t{u.book_id}\t\t{u.issue_date}\t\t{u.return_date}\n");
            }

            Console.WriteLine(s);
        }

        public void showSumbitters()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Book Id\t\t\tUser ID\t\tReturn Date\n");

            foreach (Submiter u in Program.submitter_list)
            {
                s.Append($"{u.book_id}\t\t{u.user_id}\t\t{u.return_dt}\n");
            }

            Console.WriteLine(s);
        }

        public string issue_book()
        {
            if (Program.book_list.Count > 0)
            {
                try
                {
                    Console.Write("Enter book id: ");
                    string book_id = Console.ReadLine();
                    Console.Write("Enter Issuer id:");
                    string user_id = Console.ReadLine();
                    Console.Write("Enter issue day, month and year: ");
                    int iday = Convert.ToInt32(Console.ReadLine());
                    int imonth = Convert.ToInt32(Console.ReadLine());
                    int iyear = Convert.ToInt32(Console.ReadLine());
                    DateTime issue_dt = new DateTime(iyear, imonth, iday);

                    Console.Write("Enter date of last return day, month and year seperated by space: ");
                    int rday = Convert.ToInt32(Console.ReadLine());
                    int rmonth = Convert.ToInt32(Console.ReadLine());
                    int ryear = Convert.ToInt32(Console.ReadLine());
                    DateTime return_dt = new DateTime(ryear, rmonth, rday);


                    Book foundBook = searchBook(book_id);
                    if (foundBook != null)
                    {
                        if (foundBook.isAvailable)
                        {
                            foundBook.isAvailable = false;
                            Program.borrower_list.Add(new Borrower(user_id, book_id, issue_dt, return_dt));
                            return "Book issued!";
                        }
                        else
                        {
                            return ("Book not available");
                        }
                    }
                    else
                        return "Book ID didn't match. Try again";
                }
                catch (Exception e)
                {
                    return ("Failure Occured. Reason: " + e);
                }
            }
            else
                return "No Book Available";
        }

        public string submit_book()
        {
            try
            {
                Console.Write("Enter submitter id: ");
                string user_id = Console.ReadLine();
                Console.Write("Enter Book id: ");
                string book_id = Console.ReadLine();
                Console.Write("Enter day, month and year of return: ");
                int rday = Convert.ToInt32(Console.ReadLine());
                int rmonth = Convert.ToInt32(Console.ReadLine());
                int ryear = Convert.ToInt32(Console.ReadLine());
                DateTime return_dt = new DateTime(ryear, rmonth, rday);

                Program.submitter_list.Add(new Submiter(book_id, user_id, return_dt));
                return ("Successfully submitted");
            }
            catch (Exception e)
            {
                return ("Issue Occured. Reason: " + e);
            }
        } 

        public Book searchBook(string bookid)
        {
            foreach (Book b in Program.book_list)
            {
                if (b.book_id == bookid)
                    return b;
            }
            return null;
        }
    }
}
