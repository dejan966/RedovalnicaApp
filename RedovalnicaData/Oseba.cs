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
    public class Solska_Leta
    {
        public string Solsko_Leto { get; set; }
        public Solska_Leta()
        {

        }
        public Solska_Leta(string solsko_leto)
        {
            Solsko_Leto = solsko_leto;
        }
    }
    public class Razred:Solska_Leta
    {
        //Solsko leto bo blo na vrhu programa pa bom v WHERE delu selectu solsko leto enako temu
        //SELECT id FROM razred WHERE ime = bla bla AND id_solska_leta = (SELECT id FROM solska_leta WHERE solsko_leto = bla bla
        public string ImeR { get; set; }
        public int St { get; set; }
        public Razred()
        {

        }
        public Razred(string imeR, int st)
        {
            ImeR = imeR;
            St = st;
        }
        public Razred(string imeR, int st, string s_leto):base(s_leto)
        {
            ImeR = imeR;
            St = st;
        }
        
    }
    public class Predmet:Razred
    {
        public string ImeP { get; set; }
        public string KraticaP { get; set; }
        public Predmet()
        {

        }
        public Predmet(string imeP, string kratica)
        {
            ImeP = imeP;
            KraticaP = kratica;
        }
        

    }
    public class Ocena : Predmet
    {
        public string UOcena { get; set; }
        public int StO { get; set; }
        public string DatumOcena { get; set; }
        public Ocena()
        {

        }
        public Ocena(string uOcena, int stO)
        {
            UOcena = uOcena;
            StO = stO;
        }
       
    }
    public class Vrste_Ur
    {
        public string Vrsta_Ur { get; set; }
        public Vrste_Ur()
        {

        }
        public Vrste_Ur(string vrsta_ur)
        {
            Vrsta_Ur = vrsta_ur;
        }
    }
    public class UreIzvedbe:Ocena
    {
        public string VrstaUr { get; set; }
        public string DatumCas { get; set; }
        public UreIzvedbe()
        {

        }
        public UreIzvedbe(string vrstaUr, string datumCas)
        {
            VrstaUr = vrstaUr;
            DatumCas = datumCas;
        }
        
    }
    public class Prisotnost:UreIzvedbe
    {
        public string Opomba { get; set; }
        public Prisotnost()
        {

        }
        public Prisotnost(string opomba)
        {
            Opomba = opomba;
        }
        
    }
}
