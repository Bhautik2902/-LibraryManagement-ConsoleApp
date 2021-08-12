using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;

namespace LibraryManagement
{
    class DBHelper
    {

        public static MySqlConnection createConnection(string serverAddress, string DBname, string UserID, string password)
        {
            string MyConnectionString = $"datasource={serverAddress};port=3306;username={UserID};password={password};Database={DBname}";
            
            try
            {
                MySqlConnection conn = new MySqlConnection(MyConnectionString);
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                Console.WriteLine(value: "Couldn't connect. Reason: " + e.Message);
                return null;
            }
        }

    }
}
