﻿using System;
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
            conn = new NpgsqlConnection("Server=ella.db.elephantsql.com; User Id=finomhzd; Password=qDjavv-S5TXm78zV2dGfIti1PiZZlcer; Database=finomhzd;");
        }
        public bool PreveriPrijavo(Ucitelj uc)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT solski_email, geslo FROM ucitelji WHERE(solski_email = '" + uc.SolskiEmail + "') AND (geslo = '" + uc.Geslo + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (!bralnik.HasRows)
                    return false;

                com.Dispose();
                conn.Close();
            }
            return true;
        }

        public List<Razred> ReturnVseRazrede()
        {
            List<Razred> razredi = new List<Razred>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT razred FROM razredi", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string razred = bralnik.GetString(0);
                    Razred r = new Razred(razred);
                    razredi.Add(r);
                }
                com.Dispose();
                conn.Close();
            }
            return razredi;
        }

        public List<Predmet> ReturnVsePredmete()
        {
            List<Predmet> predmeti = new List<Predmet>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT predmet FROM predmeti", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string predmet = bralnik.GetString(0);
                    Predmet r = new Predmet(predmet);
                    predmeti.Add(r);
                }
                com.Dispose();
                conn.Close();
            }
            return predmeti;
        }
        public List<Solsko_Leto> ReturnVsaSolskaLeta()
        {
            List<Solsko_Leto> solska_leta = new List<Solsko_Leto>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT solsko_leto FROM solska_leta", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string sLeto = bralnik.GetString(0);
                    Solsko_Leto r = new Solsko_Leto(sLeto);
                    solska_leta.Add(r);
                }
                com.Dispose();
                conn.Close();
            }
            return solska_leta;
        }
    }
}
