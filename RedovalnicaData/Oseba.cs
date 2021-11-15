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
        public Sola(string imes)
        {
            ImeS = imes;
        }
        public Sola(string ime, string kratica, string naslov, string telefon, string email, string davcna, string kraj):base(kraj)
        {
            ImeS = ime;
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
        public string Naslov { get; set; }
        public string Email { get; set; }

        public Oseba()
        {

        }
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            Naslov = naslov;
            Email = email;
        }
        public Oseba(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj):base(kraj)
        {
            Ime = ime;
            Priimek = priimek;
            Spol = spol;
            Datum_R = datum_r;
            Naslov = naslov;
            Email = email;
        }
    }
    public class Ucenec:Oseba
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
            Razred = razred;
            UcSola = imeSola;
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
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {

        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj, string imeSola, string telefon, string solskiEmail) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            USola = imeSola;
            Telefon = telefon;
            SolskiEmail = solskiEmail;
        }
    }
    public class Ocena : Ucenec
    {
        public string UOcena { get; set; }
        public string DatumOcena { get; set; }
        public string OPredmet { get; set; }
        public string OUcitelj { get; set; }
        public Ocena()
        {

        }
        public Ocena(string uOcena)
        {
            UOcena = uOcena;
        }
        public Ocena(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj, string razred, string sola, string predmet, string ucitelj, string uOcena, string datum) : base(ime, priimek, spol, datum_r, naslov, email, kraj, razred, sola)
        {
            OPredmet = predmet;
            OUcitelj = ucitelj;
            UOcena = uOcena;
            DatumOcena = datum;
        }
    }
    public class Razred
    {
        public Razred()
        {

        }
        public string ImeR { get; set; }
        public int St { get; set; }
        
    }
    public class Predmet
    {
        public string ImeP { get; set; }
        public Predmet()
        {

        }
        
    }
}
