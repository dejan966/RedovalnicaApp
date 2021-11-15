using System;
using System.Collections.Generic;
using System.Text;

namespace RedovalnicaData
{
    public class Drzava
    {
        public string ImeD { get; set; }
        public Drzava()
        {

        }
        public Drzava(string imeD)
        {
            ImeD = imeD;
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
    
    public class Oseba:Sola
    {
        //default osebe
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public char Spol { get; set; }
        public string Datum_R { get; set; }
        public string NaslovO { get; set; }
        public string EmailO { get; set; }
        //ucenci
        public string UcTelefon { get; set; }
        //ucitelji
        public string UTelefon { get; set; }
        public string USolskiEmail { get; set; }

        public Oseba()
        {

        }
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            NaslovO = naslov;
            EmailO = email;
            ImeK = kraj;
        }
        //ucenci
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj, string sola, string telefon):base(kraj, sola)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            NaslovO = naslov;
            EmailO = email;
            UcTelefon = telefon;
        }
        //ucitelji
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string imeSola, string telefon, string sMail) : base(kraj, imeSola)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            NaslovO = naslov;
            EmailO = email;
            UTelefon = telefon;
            USolskiEmail = sMail;
        }
    }

    /*public class Ucenec:Oseba
    {
        public string Razred { get; set; }
        public string UcSola { get; set; }
        public string UcTelefon { get; set; }
        public Ucenec()
        {

        }
        public Ucenec(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {

        }
        public Ucenec(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string imeSola) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            UcSola = imeSola;
            Razred = razred;
        }
    }
    public class Ucitelj : Oseba
    {
        public string USola { get; set; }
        public string Telefon { get; set; }
        public string UEmail{ get; set; }
        public string SolskiEmail { get; set; }

        public Ucitelj()
        {

        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string sola) : base(ime, priimek, spol, datum_r, naslov, email, kraj, sola)
        {

        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj, string imeSola, string telefon, string solskiEmail) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            USola = imeSola;
            Telefon = telefon;
            SolskiEmail = solskiEmail;
        }
    }*/
    public class Razred:Oseba
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
        public Razred(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string telefon): base(ime, priimek, spol, datum_r, naslov, email, kraj, sola, telefon)
        {
            ImeR = razred;
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
        public Predmet(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string telefon, string imeP) : base(ime, priimek, spol, datum_r, naslov, email, kraj, sola, telefon, razred)
        {
            ImeP = imeP;
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
        public Ocena(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string telefon, string predmet, string uOcena, string datum) : base(ime, priimek, spol, datum_r, naslov, email, kraj, sola, telefon, razred, predmet)
        {
            UOcena = uOcena;
            DatumOcena = datum;
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
        public UreIzvedbe(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string telefon, string predmet, string uOcena, string datum, string datumCas) : base(ime, priimek, spol, datum_r, naslov, email, kraj, sola, telefon, razred, predmet, datum, uOcena)
        {
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
        public Prisotnost(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string telefon, string predmet, string uOcena, string datum, string datumCas, string opomba) : base(ime, priimek, spol, datum_r, naslov, email, kraj, sola, telefon, razred, predmet, datum, uOcena, datumCas)
        {
            Opomba = opomba;
        }
    }
}
