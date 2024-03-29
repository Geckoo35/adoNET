﻿using System;
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
            string connectionString = "Data Source=chinook (1).db";
            //funzioni.CreateAlbums(connectionString);
            //funzioni.FillAlbums(connectionString);
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                //    connection.Open();

                //    using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM albums", connection))
                //    using (SQLiteDataReader reader = cmd.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            //access data from reader
                //            int id = reader.GetInt32(0);
                //            string name = reader.GetString(1);

                //            //process the data
                //            Console.WriteLine("{0}-{1}", id, name);
                //        }
                //    }
                //    connection.Close();
                connection.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(@"SELECT * FROM invoices WHERE BillingCountry = 'Germany' OR BillingCountry = 'USA'", connection))
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    float totale_germania = 0;
                    float totale_usa = 0;
                    List<ordine> germania = new List<ordine>();
                    List<ordine> usa = new List<ordine>();
                    while (reader.Read())
                    {
                        
                        //access data from reader
                        float Total = reader.GetFloat(8);

                        //process the data
                        if (reader.GetString(6) == "Germany")
                        {
                            string indirizzo = reader.GetString(3);
                            float prezzo = reader.GetFloat(8);
                            string data = reader.GetString(2);

                            germania.Add(new ordine(indirizzo = reader.GetString(3), prezzo, data ));
                            totale_germania = totale_germania + Total;
                        }
                        else
                        {
                            string indirizzo = reader.GetString(3);
                            float prezzo = reader.GetFloat(8);
                            string data = reader.GetString(2);

                            usa.Add(new ordine(indirizzo = reader.GetString(3), prezzo, data)); totale_usa = totale_usa + Total;
                        }
                    }
                    usa.TrimExcess();
                    germania.TrimExcess();
                    Console.WriteLine("ordini da parte della germania: \n");
                    for(int k =  0; k < germania.Count; k++)
                    {
                        Console.WriteLine("indirizzo: " + germania[k].Indirizzo + " Prezzo: " + germania[k].Prezzo + " Data: " + germania[k].Data + "\n");
                    }
                    Console.WriteLine("il totale di tutta la germania è: " + totale_germania + "\n");
                    Console.WriteLine("ordini da parte degli USA: \n");
                    for (int k = 0; k < usa.Count; k++)
                    {
                        Console.WriteLine("indirizzo: " + usa[k].Indirizzo + " Prezzo: " + usa[k].Prezzo + " Data: " + usa[k].Data + "\n");
                    }
                    Console.WriteLine("il totale di tutta la usa è: " + totale_usa);

                }
                connection.Close();
                Console.ReadKey();
            }
        }
    }
}
