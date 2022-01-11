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
    public class Predmet
    {
        public string ImeP { get; set; }
        public string KraticaP { get; set; }
        public Predmet()
        {

        }
        public Predmet(string imeP)
        {
            ImeP = imeP;
        }
        public Predmet(string imeP, string kratica)
        {
            ImeP = imeP;
            KraticaP = kratica;
        }
    }
    public class Ocena : Predmet
    {
        public string Ucenec { get; set; }
        public string RazredU { get; set; }
        public string Ucitelj { get; set; }
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
        public Ocena(string ucenec, string uOcena, string datum, string predmet, string razred, string ucitelj):base(predmet)
        {
            Ucenec = ucenec;
            UOcena = uOcena;
            DatumOcena = datum;
            RazredU = razred;
            Ucitelj = ucitelj;
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
    public class UreIzvedbe:Vrsta_Ur
    {
        public string Predmet { get; set; }
        public string Razred { get; set; }
        public string Ucitelj { get; set; }
        public string VrstaUre { get; set; }
        public string DatumCas { get; set; }
        public UreIzvedbe()
        {

        }
        public UreIzvedbe(string vrstaure):base(vrstaure)
        {
            VrstaUre = vrstaure;
        }
        public UreIzvedbe(string predmet, string razred, string vrstaure, string datumCas):this(vrstaure)
        {
            Predmet = predmet;
            Razred = razred;
            DatumCas = datumCas;
        }
        public UreIzvedbe(string predmet, string razred, string ucitelj, string vrstaure, string datumCas) : this(vrstaure)
        {
            Predmet = predmet;
            Razred = razred;
            Ucitelj = ucitelj;
            DatumCas = datumCas;
        }
    }
    public class Prisotnost:UreIzvedbe
    {
        public string Ucenec { get; set; }
        public string SolskoLeto { get; set; }
        public string Opomba { get; set; }
        public Prisotnost()
        {

        }
        public Prisotnost(string predmet, string razred, string vrstaure, string solskoLeto, string datum):base(predmet, razred, vrstaure, datum)
        {
            SolskoLeto = solskoLeto;
        }
        public Prisotnost(string ucenec, string predmet, string razred, string vrstaure, string datum, string ucitelj, string opomba) : base(predmet, razred, ucitelj, vrstaure, datum)
        {
            Ucenec = ucenec;
            Opomba = opomba;
        }
    }
}
