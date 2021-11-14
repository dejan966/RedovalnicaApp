using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace RedovalnicaData
{
    public class RedovalnicaDatabase
    {
        private NpgsqlConnection conn;
        public RedovalnicaDatabase()
        {
            conn = new NpgsqlConnection("Server=ella.db.elephantsql.com; User Id=finomhzd; Password=qDjavv-S5TXm78zV2dGflti1PiZZlcer; Database=finomhzd;");
        }
        
        public string ReturnIme()
        {
            string ime = "";
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT ime FROM osebe LIMIT 1;", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string name = bralnik.GetString(0);
                    ime = name;
                }
                com.Dispose();
                conn.Close();
                
            }
            return ime;
        }
    }
}
