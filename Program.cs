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
            funzioni.CreateAlbums(connectionString);
            funzioni.FillAlbums(connectionString);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM albums", connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //access data from reader
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);

                        //process the data
                        Console.WriteLine("{0}-{1}", id, name);
                    }
                }
                connection.Close();
                Console.ReadKey();
            }
        }
    }
}
