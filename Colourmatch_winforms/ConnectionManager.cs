using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colourmatch_winforms
{
    public class ConnectionManager
    {
        private static string server = "SPECTRALAPTOP13\\SQLEXPRESS";
        private static string database = "Colourmatch";
        private static string username = "SPECTRA-MASTERB\\michael.raw";
        private static string password = "MRaccess2312!";
        private static string trustedConnection = "yes";
        private static string connectionTimeout = "30";
        private static string connectionString = String.Format("user id={0};password={1};server={2};Trusted_Connection={3};database={4};connection timeout={5}", Username, Password, Server, TrustedConnection, Database, ConnectionTimeout);

        public static string ConnectionString
        {
            get { return connectionString; }
        }

        public static string Server
        {
            get { return server; }
        }

        public static string Database
        {
            get { return database; }
        }
        
        public static string Username
        {
            get { return username; }
        }

        public static string Password
        {
            get { return password; }
        }

        public static string TrustedConnection
        {
            get { return trustedConnection; }
        }

        public static string ConnectionTimeout
        {
            get { return connectionTimeout; }
        }
    }
}
