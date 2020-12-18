using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL
{
    public class Connection
    {
        private static string database = "dbi436715";

        private static string host = "studmysql01.fhict.local";

        private static string user = "dbi436715";

        private static string pass = "VaCovid";

        private static MySqlConnection GeneralConnection = new MySqlConnection($"Server={host};Database={database};$Uid={user};$Pwd={pass};");

        /// <summary>
        /// Returns the MySqlConnection
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetConnection()
        {
             MySqlConnection GeneralConnection = new MySqlConnection("Server=studmysql01.fhict.local;Uid=dbi436715;Database=dbi436715;Pwd=VaCovid;");
             return GeneralConnection;
        }
    }
}
