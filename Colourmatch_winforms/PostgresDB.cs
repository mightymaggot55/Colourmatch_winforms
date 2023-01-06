using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;


namespace Colourmatch_winforms
{
    public class PostgresDB
    {
        private static string Server = "localhost";
        private static string Database = "colourmatch_dotnet";
        private static string Port = "5433";
        private static string Username = "postgres";
        private static string Password = "MRaccess2312!";

        public static NpgsqlConnection Connect()       
        {
           
            string connString = String.Format("Server={0};Database={1};Port={2};Username={3};Password={4}",
                                              Server,
                                              Database,
                                              Port,
                                              Username,
                                              Password);
            using (var conn = new NpgsqlConnection(connString))
            {
                Console.WriteLine("Opening Connection");
                conn.Open();
                return conn;
            }

        }
        

    }
}
