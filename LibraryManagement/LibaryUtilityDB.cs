using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    class LibraryUtilityDB
    {
        public MySqlConnection conn;
        public DBHelper dbhelper = new DBHelper();
        public LibraryUtilityDB(MySqlConnection conn)
        {
            this.conn = conn;
        }
        
        public string AddNewUser()
        {
            string username;
            long contact_no;
            string email;
            string address; 

            try
            {
                Console.Write("Add User Name: ");
                username = Console.ReadLine();
                Console.Write("Add Contact No.: ");
                contact_no = Convert.ToInt64(Console.ReadLine());
                Console.Write("Add Email: ");
                email = Console.ReadLine();
                Console.Write("Address");
                address = Console.ReadLine();

                return username;
                
                  
            }
            catch (Exception e)
            {
                return "Error occured. Reason:" + e;
            }

        }
    }
}
