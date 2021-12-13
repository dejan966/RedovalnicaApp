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

        public List<Ucenec> ReturnVseUcence()
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string ime = bralnik.GetString(0);
                    string priimek = bralnik.GetString(1);
                    Ucenec u = new Ucenec(ime,priimek);
                    ucenci.Add(u);
                }
                com.Dispose();
                conn.Close();
            }

            return ucenci;
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
                    Predmet p = new Predmet(predmet);
                    predmeti.Add(p);
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
                    Solsko_Leto s = new Solsko_Leto(sLeto);
                    solska_leta.Add(s);
                }
                com.Dispose();
                conn.Close();
            }
            return solska_leta;
        }

        public List<Vrsta_Ur> ReturnVseVrsteUr()
        {
            List<Vrsta_Ur> vrste_ur = new List<Vrsta_Ur>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT vrsta_ure FROM vrste_ur", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string vUre = bralnik.GetString(0);
                    Vrsta_Ur s = new Vrsta_Ur(vUre);
                    vrste_ur.Add(s);
                }
                com.Dispose();
                conn.Close();
            }
            return vrste_ur;
        }

        public List<Ucenec> ReturnUcenci_Razred(string razred)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi WHERE(r.razred = '" + razred + "') ", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        string ime = bralnik.GetString(0);
                        string priimek = bralnik.GetString(1);
                        Ucenec u = new Ucenec(ime, priimek);
                        ucenci.Add(u);
                    }
                }

                com.Dispose();
                conn.Close();
            }

            return ucenci;
        }

        public List<Ucenec> ReturnUcenci_Razred_Predmet(string razred, string predmet)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN razredi_predmeti rp ON rp.id_razredi = r.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(r.razred = '" + razred + "') AND (p.predmet = '" + predmet + "')", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        string ime = bralnik.GetString(0);
                        string priimek = bralnik.GetString(1);
                        Ucenec u = new Ucenec(ime, priimek);
                        ucenci.Add(u);
                    }
                }

                com.Dispose();
                conn.Close();
            }

            return ucenci;
        }

        public List<Ucenec> ReturnUcenci_Razred_Predmet_SolskoLeto(string razred, string predmet, string solsko_leto)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN razredi_predmeti rp ON rp.id_razredi = r.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti INNER JOIN solska_leta s ON r.id_solska_leta = s.id_solska_leta WHERE(r.razred = '" + razred + "') AND (p.predmet = '" + predmet + "') AND (s.solsko_leto = '" + solsko_leto + "') ", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        string ime = bralnik.GetString(0);
                        string priimek = bralnik.GetString(1);
                        Ucenec u = new Ucenec(ime, priimek);
                        ucenci.Add(u);
                    }
                }
                
                com.Dispose();
                conn.Close();
            }

            return ucenci;
        }
    }
}
