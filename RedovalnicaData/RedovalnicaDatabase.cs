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
                while (bralnik.Read())
                {
                    string r = bralnik.GetString(0);
                    Razred u = new Razred(r);
                    razredi.Add(u);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return razredi;
        } 
        public List<Ucenec> ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto_Datum(Prisotnost pZaNazaj)
        {
            List<Ucenec> ucenci = new List<Ucenec>();

            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("(SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN prisotnosti p on p.id_ucenci = u.id_ucenci INNER JOIN razredi r ON u.id_razredi = r.id_razredi INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta INNER JOIN razredi_predmeti rp on r.id_razredi = rp.id_razredi INNER JOIN predmeti pr on pr.id_predmeti = rp.id_predmeti WHERE (r.razred = '" + pZaNazaj.ImeR + "') AND (pr.predmet = '" + pZaNazaj.ImeP + "') AND (sl.solsko_leto = '" + pZaNazaj.SLeto + "'))" +
                "UNION (SELECT o.ime, o.priimek FROM osebe o INNER JOIN ucenci u ON u.id_osebe = o.id_osebe INNER JOIN prisotnosti p on p.id_ucenci = u.id_ucenci INNER JOIN ure_izvedb ui on ui.id_ure_izvedb = p.id_ure_izvedb INNER JOIN vrste_ur vu on vu.id_vrste_ur = ui.id_vrste_ur INNER JOIN razredi_predmeti rp on rp.id_razredi_predmeti = ui.id_razredi_predmeti INNER JOIN razredi r on r.id_razredi = rp.id_razredi INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta INNER JOIN predmeti pr on pr.id_predmeti = rp.id_predmeti WHERE(ui.datum_cas LIKE '%" + pZaNazaj.DatumCas + "%') AND(r.razred = '" + pZaNazaj.ImeR + "') AND(pr.predmet = '" + pZaNazaj.ImeP + "') AND(vu.vrsta_ure = '" + pZaNazaj.VrstaUre + "') AND (sl.solsko_leto = '" + pZaNazaj.SLeto + "'))", conn);
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
        public List<Ocena> ReturnRazredUcenciOcena(RazredPredmet prs)
        {
            List<Ocena> ocene = new List<Ocena>();
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT DISTINCT o.ime || ' ' || o.priimek AS ucenec, oc.ocena_st, p.predmet FROM osebe o INNER JOIN ucenci u on o.id_osebe = u.id_osebe INNER JOIN razredi r on r.id_razredi = u.id_razredi INNER JOIN solska_leta sl ON sl.id_solska_leta = r.id_solska_leta INNER JOIN razredi_predmeti rp on r.id_razredi = rp.id_razredi INNER JOIN ocene_ucenci ou on rp.id_razredi_predmeti = ou.id_razredi_predmeti INNER JOIN ocene_ucenci ou2 on u.id_ucenci = ou2.id_ucenci INNER JOIN predmeti p on p.id_predmeti = rp.id_predmeti INNER JOIN ocene oc on oc.id_ocene = ou.id_ocene WHERE (sl.solsko_leto = '" + prs.SLeto + "') AND (r.razred = '" + prs.ImeR + "'); ", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                {
                    string ucenec = bralnik.GetString(0);
                    int stO = bralnik.GetInt32(1);

                    Ocena oc = new Ocena(ucenec, stO);
                    ocene.Add(oc);
                }
                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return ocene;
        }
        public void InsertOcena_Ucenec(Ocena ocenaZaUcenca)
        {
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO ocene_ucenci(id_ucenci, id_ocene, datum, id_razredi_predmeti) VALUES ((SELECT id_ucenci FROM ucenci WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + ocenaZaUcenca.Ucenec + "'))), (SELECT id_ocene FROM ocene WHERE ocena_st = '" + ocenaZaUcenca.StO + "'), '" + ocenaZaUcenca.DatumOcena + "', (SELECT id_razredi_predmeti FROM razredi_predmeti WHERE id_razredi_predmeti = '" + ocenaZaUcenca.Id_R_P_U + "'))", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
        }
        
        public int InsertSelectRazrediPredmeti(RazredPredmet rp)
        {
            int id = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM Insert_Select_RazrediPredmeti('" + rp.ImeP + "', '" + rp.ImeR + "', '" + rp.UciteljP + "', '" + rp.SLeto + "');", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while (bralnik.Read())
                    id = bralnik.GetInt32(0);

                bralnik.Close();
                com.Dispose();
                conn.Close();
            }
            return id;
        }
        public int InsertSelectUreIzvedb(UreIzvedbe ure)
        {
            int id = 0;
            using (conn)
            {
                conn.Open();
                NpgsqlCommand com = new NpgsqlCommand("SELECT * FROM Insert_Select_UreIzvedbe('" + ure.Id_R_P_U + "', '" + ure.VrstaUre + "', '" + ure.DatumCas + "', '" + ure.Datum + "');;", conn);
                NpgsqlDataReader bralnik = com.ExecuteReader();
                while(bralnik.Read())
                    id = bralnik.GetInt32(0);
                
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
                NpgsqlCommand com = new NpgsqlCommand("INSERT INTO prisotnosti(id_ucenci, id_ure_izvedb, opomba) VALUES((SELECT id_ucenci FROM ucenci WHERE (id_osebe = (SELECT id_osebe FROM osebe WHERE ime || ' ' || priimek = '" + dPrisotnost.Ucenec + "'))), '" + dPrisotnost.IdUr + "', '" + dPrisotnost.Opomba + "')", conn);
                com.ExecuteNonQuery();
                com.Dispose();
                conn.Close();
            }
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


