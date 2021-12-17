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

                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return true;
        }

        public string ReturnImePriimekUcitelja(string email)
        {
            string ime_priimek = "";

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime || ' ' || o.priimek AS ucitelj FROM osebe o INNER JOIN ucitelji u ON u.id_osebe = o.id_osebe WHERE (u.solski_email = '" + email + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string imePriimek = bralnik.GetString(0);
                    ime_priimek = imePriimek;
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }

            return ime_priimek;
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
                bralnik.Close();
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
                bralnik.Close();
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
                bralnik.Close();
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
                bralnik.Close();
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
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return vrste_ur;
        }
        public List<Ocena> ReturnVseOcene()
        {
            List<Ocena> ocene = new List<Ocena>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT ocena_st FROM ocene", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    int stO = bralnik.GetInt32(0);
                    Ocena s = new Ocena(stO);
                    ocene.Add(s);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }

            return ocene;
        }
        public List<Ucenec> ReturnUcenci_Razred(string razred, string solskoleto)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN solska_leta sl on sl.id_solska_leta = r.id_solska_leta WHERE(r.razred = '" + razred + "') AND (sl.solsko_leto = '" + solskoleto + "');", conn);
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
                else
                {
                    Ucenec u = new Ucenec("", "");
                    ucenci.Add(u);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }

            return ucenci;
        }
        public List<Razred> ReturnRazred_SolskoLeto(string solskoLeto)
        {
            List<Razred> razredi = new List<Razred>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT r.razred FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (sl.solsko_leto = '" + solskoLeto + "')", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        string r = bralnik.GetString(0);
                        Razred u = new Razred(r);
                        razredi.Add(u);
                    }
                }
                else
                {
                    Razred u = new Razred("");
                    razredi.Add(u);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return razredi;
        } 
        public List<Ucenec> ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto_Datum(string razred, string predmet, string vrsta_ure, string solsko_leto, string datum)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN razredi_predmeti rp ON rp.id_razredi = r.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti INNER JOIN solska_leta s ON r.id_solska_leta = s.id_solska_leta INNER JOIN ure_izvedb ui ON ui.id_razredi_predmeti = rp.id_razredi_predmeti INNER JOIN vrste_ur vu ON vu.id_vrste_ur = ui.id_vrste_ur INNER JOIN prisotnosti pr on ui.id_ure_izvedb = pr.id_ure_izvedb INNER JOIN prisotnosti pr2 ON pr2.id_ucenci = u.id_ucenci  WHERE(r.razred = '" + razred + "') AND (p.predmet = '" + predmet + "') AND (s.solsko_leto = '" + solsko_leto + "') AND (vu.vrsta_ure = '" + vrsta_ure + "') AND (ui.datum_cas LIKE '%" + datum + "%');", conn);
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
                else
                {
                    Ucenec u = new Ucenec("", "");
                    ucenci.Add(u);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }

            return ucenci;
        }

        public void InsertRazrediPredmeti(string predmet, string razred, string solskoLeto, string ucitelj)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT p.predmet, r.razred, o.ime || ' ' || o.priimek FROM osebe o INNER JOIN ucitelji u on o.id_osebe = u.id_osebe INNER JOIN razredi_predmeti rp on u.id_ucitelji = rp.id_ucitelji INNER JOIN razredi r on rp.id_razredi = r.id_razredi INNER JOIN predmeti p on rp.id_predmeti = p.id_predmeti WHERE (p.predmet = '" + predmet + "') AND (r.razred = '" + razred + "') AND (ime || ' ' || priimek = '" + ucitelj + "');", conn);
                NpgsqlDataReader bralnik =  com.ExecuteReader();
                if (!bralnik.HasRows)
                {
                    using (NpgsqlConnection conn2 = new NpgsqlConnection("Server=ella.db.elephantsql.com; User Id=finomhzd; Password=qDjavv-S5TXm78zV2dGfIti1PiZZlcer; Database=finomhzd;"))
                    {
                        conn2.Open();
                        NpgsqlCommand com2 = new NpgsqlCommand("INSERT INTO razredi_predmeti (id_predmeti, id_razredi, id_ucitelji) VALUES ((SELECT id_predmeti FROM predmeti WHERE predmet = '" + predmet + "'), (SELECT r.id_razredi FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (r.razred = '" + razred + "') AND (sl.solsko_leto = '" + solskoLeto + "')), (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + ucitelj + "'));", conn2);
                        com2.ExecuteNonQuery();
                        com2.Dispose();
                        conn2.Close();
                    }
                        
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
        }

        public int IDRazrediPredmeti(string predmet, string razred, string solskoLeto, string ucitelj)
        {
            int id = 1;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT id_razredi_predmeti FROM razredi_predmeti WHERE (id_predmeti = (SELECT id_predmeti FROM predmeti WHERE predmet = '" + predmet + "')) AND (id_razredi = (SELECT r.id_razredi FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (r.razred = '" + razred + "') AND (sl.solsko_leto = '" + solskoLeto + "'))) AND (id_ucitelji = (SELECT id_ucitelji FROM ucitelji WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + ucitelj + "'))));", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    id = bralnik.GetInt32(0);
                }
                bralnik.Close();
            }
            return id;
        }
        public void InsertUreIzvedb(int idRazredPredmet, string vrsta_ure, string datum)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO ure_izvedb(id_razredi_predmeti, id_vrste_ur, datum_cas) VALUES ('" + idRazredPredmet + "', (SELECT id_vrste_ur FROM vrste_ur WHERE vrsta_ure = '" + vrsta_ure + "'), '" + datum + "');", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
        public int IDUreIzvedb(int idRazredPredmet, string vrsta_ure, string datum)
        {
            int id = 1;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT id_ure_izvedb FROM ure_izvedb WHERE (id_razredi_predmeti = '" + idRazredPredmet + "') AND (id_vrste_ur = (SELECT id_vrste_ur FROM vrste_ur WHERE vrsta_ure = '" + vrsta_ure + "')) AND (datum_cas LIKE '%" + datum + "%');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    id = bralnik.GetInt32(0);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return id;
        }
        public void InsertPrisotnosti(string ucenec, int idUraIzvedbe, string opomba)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO prisotnosti(id_ucenci, id_ure_izvedb, opomba) VALUES((SELECT id_ucenci FROM ucenci WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + ucenec + "'))), '" + idUraIzvedbe + "', '" + opomba + "')", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
    }
}
