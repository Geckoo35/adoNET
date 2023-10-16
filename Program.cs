using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace adoNET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=chinook.db";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // operazioni

                connection.Close();
            }
        }
    }
}
