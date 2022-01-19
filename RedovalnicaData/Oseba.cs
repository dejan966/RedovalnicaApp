using System;
using System.Collections.Generic;
using System.Text;

namespace RedovalnicaData
{
    public class Drzava
    {
        public string Drzava_Slo { get; set; }
        public string Drzava_Iso { get; set; }
        public string DKratica { get; set; }
        public Drzava()
        {

        }
        public Drzava(string drzava_slo)
        {
            Drzava_Slo = drzava_slo;
        }
        public Drzava(string drzava_slo, string drzava_iso, string kratica)
        {
            Drzava_Slo = drzava_slo;
            Drzava_Iso = drzava_iso;
            DKratica = kratica;
        }
    }
    public class Kraj:Drzava
    {
        public string ImeK { get; set; }
        public string Post_St { get; set; }

        public Kraj()
        {


        }
        public Kraj(string imek)
        {
            ImeK = imek;
        }
        public Kraj(string imek, string imed):base(imed)
        {
            ImeK = imek;
        }

    }
    public class Sola:Kraj
    {
        public string ImeS { get; set; }
        public string Kratica { get; set; }
        public string Naslov{ get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Davcna { get; set; }

        public Sola()
        {

        }
        public Sola(string imeS)
        {
            ImeS = imeS;
        }
        public Sola(string imeK, string imeS):base(imeK)
        {
            ImeS = imeS;
        }
        public Sola(string imeS, string kratica, string naslov, string telefon, string email, string davcna, string kraj):base(kraj)
        {
            ImeS = imeS;
            Kratica = kratica;
            Naslov = naslov;
            Telefon = telefon;
            Email = email;
            Davcna = davcna;
        }
    }
    
    public class Oseba:Kraj
    {
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public char Spol { get; set; }
        public string Datum_R { get; set; }
        public string NaslovO { get; set; }
        public string EmailO { get; set; }

        public Oseba()
        {

        }
        public Oseba(string ime, string priimek)
        {
            Ime = ime;
            Priimek = priimek;
        }
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj):base(kraj)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            NaslovO = naslov;
            EmailO = email;
        }
        
    }

    public class Ucenec:Oseba
    {
        public string URazred { get; set; }
        public string USola { get; set; }
        public string UcTelefon { get; set; }
        public Ucenec()
        {

        }
        public Ucenec(string ime, string priimek):base(ime, priimek)
        {

        }
        public Ucenec(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {

        }
        public Ucenec(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string imeSola) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            USola = imeSola;
            URazred = razred;
        }
    }
    public class Ucitelj : Oseba
    {
        public string UcSola { get; set; }
        public string Telefon { get; set; }
        public string SolskiEmail { get; set; }
        public string Geslo { get; set; }
        public Ucitelj()
        {

        }
        public Ucitelj(string email)
        {
            SolskiEmail = email;
        }
        public Ucitelj(string sEmail, string geslo)
        {
            SolskiEmail = sEmail;
            Geslo = geslo;
        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {

        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj, string imeSola, string telefon, string solskiEmail) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            UcSola = imeSola;
            Telefon = telefon;
            SolskiEmail = solskiEmail;
        }
    }
    public class Solsko_Leto
    {
        public string SLeto { get; set; }
        public Solsko_Leto()
        {

        }
        public Solsko_Leto(string solsko_leto)
        {
            SLeto = solsko_leto;
        }
    }
    public class Razred: Solsko_Leto
    {
        public string ImeR { get; set; }
        public int St { get; set; }
        public Razred()
        {

        }
        public Razred(string imeR)
        {
            ImeR = imeR;
        }
        public Razred(string imeR, string s_leto):base(s_leto)
        {
            ImeR = imeR;
        }
    }
    public class RazredPredmet:Razred
    {
        public int Id_R_P_U { get; set; }
        public string ImeP { get; set; }
        public string KraticaP { get; set; }
        public string UciteljP{ get; set; }
        public RazredPredmet()
        {

        }
        public RazredPredmet(int id_p_r_u)
        {
            Id_R_P_U = id_p_r_u;
        }
        public RazredPredmet(string imeP)
        {
            ImeP = imeP;
        }
        public RazredPredmet(string imeP, string imeR):base(imeR)
        {
            ImeP = imeP;
        }
        public RazredPredmet(string imeP, string imeR, string sLeto):base(imeR, sLeto)
        {
            ImeP = imeP;
        }
        public RazredPredmet(string predmet, string razred, string ucitelj, string solsko_leto):base(razred, solsko_leto)
        {
            ImeP = predmet;
            UciteljP = ucitelj;
        }
    }
    public class Ocena : RazredPredmet
    {
        public string Ucenec { get; set; }
        public string UOcena { get; set; }
        public int StO { get; set; }
        public string DatumOcena { get; set; }
        public Ocena()
        {

        }
        public Ocena(int stO)
        {
            StO = stO;
        }
        public Ocena(string ucenec, int stO)
        {
            Ucenec = ucenec;
            StO = stO;
        }
        public Ocena(string ucenec, string uOcena, string datum, int id_p_r_u) : base(id_p_r_u)
        {
            Ucenec = ucenec;
            UOcena = uOcena;
            DatumOcena = datum;
        }
        public Ocena(string ucenec, string uOcena, string datum, string predmet, string razred, string solsko_leto, string ucitelj):base(predmet, razred, ucitelj, solsko_leto)
        {
            Ucenec = ucenec;
            UOcena = uOcena;
            DatumOcena = datum;
        }
       
    }
    public class Vrsta_Ur
    {
        public string Ura { get; set; }
        public Vrsta_Ur()
        {

        }
        public Vrsta_Ur(string vrsta_ur)
        {
            Ura = vrsta_ur;
        }
    }
    public class UreIzvedbe: RazredPredmet
    {
        public int IdUr { get; set; }
        public string VrstaUre { get; set; }
        public string DatumCas { get; set; }
        public UreIzvedbe()
        {

        }
        public UreIzvedbe(int idUr)
        {
            IdUr = idUr;
        }

        public UreIzvedbe(string predmet, string razred, string sLeto, string vrstaure, string datumCas):base(predmet, razred, sLeto)
        {
            VrstaUre = vrstaure;
            DatumCas = datumCas;
        }
        public UreIzvedbe(int id_razredi_predmeti, string vrsta_ure, string datumCas):base(id_razredi_predmeti)
        {
            VrstaUre = vrsta_ure;
            DatumCas = datumCas;
        }
        public UreIzvedbe(string predmet, string razred, string solsko_leto, string ucitelj, string vrstaure, string datumCas):base(predmet, razred, solsko_leto, ucitelj)
        {
            VrstaUre = vrstaure;
            DatumCas = datumCas;
        }
    }
    public class Prisotnost:UreIzvedbe
    {
        public string Ucenec { get; set; }
        public int Id_Ure_Izvedbe { get; set; }
        public string Opomba { get; set; }
        public Prisotnost()
        {
            
        }
        public Prisotnost(string predmet, string razred, string solsko_leto, string vrsta_ure, string datum):base(predmet, razred, solsko_leto, vrsta_ure, datum)
        {

        }
        public Prisotnost(string ucenec,int id_ure_izvedbe, string opomba):base(id_ure_izvedbe)
        {
            Ucenec = ucenec;
            Id_Ure_Izvedbe = id_ure_izvedbe;
            Opomba = opomba;
        }
    }
}
