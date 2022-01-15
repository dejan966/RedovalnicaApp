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

        public string ReturnImePriimekUcitelja(Ucitelj email)
        {
            string ime_priimek = "";

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime || ' ' || o.priimek AS ucitelj FROM osebe o INNER JOIN ucitelji u ON u.id_osebe = o.id_osebe WHERE (u.solski_email = '" + email.SolskiEmail + "');", conn);
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

        public List<RazredPredmet> ReturnVsePredmete()
        {
            List<RazredPredmet> predmeti = new List<RazredPredmet>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT predmet FROM predmeti", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string predmet = bralnik.GetString(0);
                    RazredPredmet p = new RazredPredmet(predmet);
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
        public List<Ucenec> ReturnUcenci_Razred(Razred ru)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN solska_leta sl on sl.id_solska_leta = r.id_solska_leta WHERE(r.razred = '" + ru.ImeR + "') AND (sl.solsko_leto = '" + ru.SLeto + "');", conn);
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
        public List<Razred> ReturnRazred_SolskoLeto(Solsko_Leto s)
        {
            List<Razred> razredi = new List<Razred>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT r.razred FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (sl.solsko_leto = '" + s.SLeto + "')", conn);
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
                NpgsqlCommand com = new NpgsqlCommand("SELECT DISTINCT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN razredi_predmeti rp ON rp.id_razredi = r.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti INNER JOIN solska_leta s ON r.id_solska_leta = s.id_solska_leta INNER JOIN ure_izvedb ui ON ui.id_razredi_predmeti = rp.id_razredi_predmeti INNER JOIN vrste_ur vu ON vu.id_vrste_ur = ui.id_vrste_ur INNER JOIN prisotnosti pr on ui.id_ure_izvedb = pr.id_ure_izvedb INNER JOIN ucenci u2 ON pr.id_ucenci = u2.id_ucenci WHERE(r.razred = '" + razred + "') AND (p.predmet = '" + predmet + "') AND (s.solsko_leto = '" + solsko_leto + "') AND (vu.vrsta_ure = '" + vrsta_ure + "') AND (ui.datum_cas LIKE '%" + datum + "%');", conn);
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
        /*public List<Ucenec> ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto_DatumR(Prisotnost pZaNazaj)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT DISTINCT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN razredi_predmeti rp ON rp.id_razredi = r.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti INNER JOIN solska_leta s ON r.id_solska_leta = s.id_solska_leta INNER JOIN ure_izvedb ui ON ui.id_razredi_predmeti = rp.id_razredi_predmeti INNER JOIN vrste_ur vu ON vu.id_vrste_ur = ui.id_vrste_ur INNER JOIN prisotnosti pr on ui.id_ure_izvedb = pr.id_ure_izvedb INNER JOIN ucenci u2 ON pr.id_ucenci = u2.id_ucenci WHERE(r.razred = '" + pZaNazaj.Razred + "') AND (p.predmet = '" + pZaNazaj.Predmet + "') AND (s.solsko_leto = '" + pZaNazaj.SolskoLeto + "') AND (vu.vrsta_ure = '" + pZaNazaj.VrstaUre + "') AND (ui.datum_cas LIKE '%" + pZaNazaj.DatumCas + "%');", conn);
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
        }*/
        public List<Ocena> ReturnRazredUcenciOcena(RazredPredmet prs)
        {
            List<Ocena> ocene = new List<Ocena>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT o.ime || ' ' || o.priimek, oc.ocena_st FROM osebe o INNER JOIN ucenci u on o.id_osebe = u.id_osebe INNER JOIN razredi r on r.id_razredi = u.id_razredi INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta INNER JOIN razredi_predmeti rp on r.id_razredi = rp.id_razredi INNER JOIN ocene_ucenci ou on rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN ocene_ucenci ou2 on u.id_ucenci = ou2.id_ucenci INNER JOIN predmeti p on p.id_predmeti = rp.id_predmeti INNER JOIN ocene oc on oc.id_ocene = ou.id_ocene WHERE (sl.solsko_leto = '" + prs.SLeto + "') (r.razred = '" + prs.ImeR + "') AND (p.predmet = '" + prs.ImeP + "'); ", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string ucenec = bralnik.GetString(0);
                    int stO = bralnik.GetInt32(1);

                    Ocena oc = new Ocena(ucenec, stO);
                    ocene.Add(oc);
                }
                conn.Close();
            }
            return ocene;
        }
        public void InsertOcena_Ucenec(Ocena ocenaZaUcenca)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO ocene_ucenci(id_ucenci, id_ocene, datum, id_razredi_predmeti) VALUES ((SELECT id_ucenci FROM ucenci WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + ocenaZaUcenca.Ucenec + "'))), (SELECT id_ocene FROM ocene WHERE ocena_st = '" + ocenaZaUcenca.UOcena + "'), '" + ocenaZaUcenca.DatumOcena + "', (SELECT rp.id_razredi_predmeti FROM razredi_predmeti rp INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti INNER JOIN ucitelji u ON u.id_ucitelji = rp.id_ucitelji INNER JOIN osebe o ON o.id_osebe = u.id_osebe WHERE (r.razred = '" + ocenaZaUcenca.ImeR + "') AND (p.predmet = '" + ocenaZaUcenca.ImeP + "') AND (o.ime || ' ' || o.priimek = '" + ocenaZaUcenca.UciteljP + "')))", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
        
        public void InsertRazrediPredmeti(RazredPredmet rp)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT p.predmet, r.razred, o.ime || ' ' || o.priimek FROM osebe o INNER JOIN ucitelji u on o.id_osebe = u.id_osebe INNER JOIN razredi_predmeti rp on u.id_ucitelji = rp.id_ucitelji INNER JOIN razredi r on rp.id_razredi = r.id_razredi INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta INNER JOIN predmeti p on rp.id_predmeti = p.id_predmeti WHERE (p.predmet = '" + rp.ImeP + "') AND (r.razred = '" + rp.ImeR + "') AND (sl.solsko_leto = '" + rp.SLeto + "') AND (ime || ' ' || priimek = '" + rp.UciteljP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (!bralnik.HasRows)
                {
                    using (NpgsqlConnection conn2 = new NpgsqlConnection("Server=ella.db.elephantsql.com; User Id=finomhzd; Password=qDjavv-S5TXm78zV2dGfIti1PiZZlcer; Database=finomhzd;"))
                    {
                        conn2.Open();
                        NpgsqlCommand com2 = new NpgsqlCommand("INSERT INTO razredi_predmeti (id_predmeti, id_razredi, id_ucitelji) VALUES ((SELECT id_predmeti FROM predmeti WHERE predmet = '" + rp.ImeP + "'), (SELECT r.id_razredi FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (r.razred = '" + rp.ImeR + "') AND (sl.solsko_leto = '" + rp.SLeto + "')), (SELECT id_ucitelji FROM ucitelji WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + rp.UciteljP + "'))));", conn2);
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
        
        public int IDRazrediPredmeti(RazredPredmet rp)
        {
            int id = 1;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT id_razredi_predmeti FROM razredi_predmeti WHERE (id_predmeti = (SELECT id_predmeti FROM predmeti WHERE predmet = '" + rp.ImeP + "')) AND (id_razredi = (SELECT r.id_razredi FROM razredi r INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta WHERE (r.razred = '" + rp.ImeR + "') AND (sl.solsko_leto = '" + rp.SLeto + "'))) AND (id_ucitelji = (SELECT id_ucitelji FROM ucitelji WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + rp.UciteljP + "'))));", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    id = bralnik.GetInt32(0);
                }
                bralnik.Close();
            }
            return id;
        }
        public void InsertUreIzvedb(UreIzvedbe ure)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO ure_izvedb(id_razredi_predmeti, id_vrste_ur, datum_cas) VALUES ('" + ure.Id_R_P_U + "', (SELECT id_vrste_ur FROM vrste_ur WHERE vrsta_ure = '" + ure.VrstaUre + "'), '" + ure.DatumCas + "');", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
        public int IDUreIzvedb(UreIzvedbe ure)
        {
            int id = 1;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT id_ure_izvedb FROM ure_izvedb WHERE (id_razredi_predmeti = '" + ure.Id_R_P_U + "') AND (id_vrste_ur = (SELECT id_vrste_ur FROM vrste_ur WHERE vrsta_ure = '" + ure.VrstaUre + "')) AND (datum_cas LIKE '%" + ure.DatumCas + "%');", conn);
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
        public void InsertPrisotnosti(Prisotnost dPrisotnost)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO prisotnosti(id_ucenci, id_ure_izvedb, opomba) VALUES((SELECT id_ucenci FROM ucenci WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + dPrisotnost.Ucenec + "'))), '" + dPrisotnost.Id_Ure_Izvedbe + "', '" + dPrisotnost.Opomba + "')", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
        public int Return_StUcenci_Razred(Razred r)
        {
            int st_ucencevR = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN razredi r ON r.id_razredi = u.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta WHERE(sl.solsko_leto = '" + r.SLeto + "') AND (r.razred = '" + r.ImeR + "')", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencevR = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencevR;
        }

        public int Return_Ucenci_Ocena1(RazredPredmet r1)
        {
            int st_ucencev1 = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN ocene_ucenci ou ON ou.id_ucenci = u.id_ucenci INNER JOIN ocene o ON o.id_ocene = ou.id_ocene INNER JOIN razredi_predmeti rp ON rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(o.ocena_st = 1) AND (sl.solsko_leto = '" + r1.SLeto + "') AND (r.razred = '" + r1.ImeR + "') AND (p.predmet = '" + r1.ImeP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencev1 = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencev1;
        }
        public int Return_Ucenci_Ocena2(RazredPredmet r2)
        {
            int st_ucencev2 = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN ocene_ucenci ou ON ou.id_ucenci = u.id_ucenci INNER JOIN ocene o ON o.id_ocene = ou.id_ocene INNER JOIN razredi_predmeti rp ON rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(o.ocena_st = 2) AND (sl.solsko_leto = '" + r2.SLeto + "') AND (r.razred = '" + r2.ImeR + "') AND (p.predmet = '" + r2.ImeP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencev2 = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencev2;
        }
        public int Return_Ucenci_Ocena3(RazredPredmet r3)
        {
            int st_ucencev3 = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN ocene_ucenci ou ON ou.id_ucenci = u.id_ucenci INNER JOIN ocene o ON o.id_ocene = ou.id_ocene INNER JOIN razredi_predmeti rp ON rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(o.ocena_st = 3) AND (sl.solsko_leto = '" + r3.SLeto + "') AND (r.razred = '" + r3.ImeR + "') AND (p.predmet = '" + r3.ImeP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencev3 = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencev3;
        }
        public int Return_Ucenci_Ocena4(RazredPredmet r4)
        {
            int st_ucencev4 = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN ocene_ucenci ou ON ou.id_ucenci = u.id_ucenci INNER JOIN ocene o ON o.id_ocene = ou.id_ocene INNER JOIN razredi_predmeti rp ON rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(o.ocena_st = 4) AND (sl.solsko_leto = '" + r4.SLeto + "') AND (r.razred = '" + r4.ImeR + "') AND (p.predmet = '" + r4.ImeP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencev4 = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencev4;
        }
        public int Return_Ucenci_Ocena5(RazredPredmet r5)
        {
            int st_ucencev5 = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT COUNT(u.*) FROM ucenci u INNER JOIN ocene_ucenci ou ON ou.id_ucenci = u.id_ucenci INNER JOIN ocene o ON o.id_ocene = ou.id_ocene INNER JOIN razredi_predmeti rp ON rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN razredi r ON r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON r.id_solska_leta = sl.id_solska_leta INNER JOIN predmeti p ON rp.id_predmeti = p.id_predmeti WHERE(o.ocena_st = 5) AND (sl.solsko_leto = '" + r5.SLeto + "') AND (r.razred = '" + r5.ImeR + "') AND (p.predmet = '" + r5.ImeP + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                if (bralnik.HasRows)
                {
                    while (bralnik.Read())
                    {
                        st_ucencev5 = bralnik.GetInt32(0);
                    }
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return st_ucencev5;
        }
    }
}


