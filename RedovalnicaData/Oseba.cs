using System;
using System.Collections.Generic;
using System.Text;

namespace RedovalnicaData
{
    public class Kraj
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

    }
    public class Sola:Kraj
    {
        public string ImeS { get; set; }

        public Sola()
        {


        }
        public Sola(string imes)
        {
            ImeS = imes;
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
        //public string Razred { get; set; }
        public Ucenec(string ime, string priimek, char spol, string datum_r, string naslov, string email, string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            
        }
    }
    public class Ucitelj : Oseba
    {
        public Ucitelj()
        {

        }
        public Ucitelj(string ime, string priimek, char spol, string datum_r, string naslov, string email,string kraj) : base(ime, priimek, spol, datum_r, naslov, email, kraj)
        {
            
        }
    }
    /*public class Razred : Ucitelj
    {
        public Razred()
        {

        }
        public string ImeR { get; set; }
        public int St { get; set; }
        
        public Razred(string ime, string priimek, char spol, string datum_r, string naslov, string email, string sola, string kraj, string razred) : base(ime, priimek, spol, datum_r, naslov, email, sola, kraj)
        {
            ImeR = razred;
        }
    }
    public class Predmet: Razred
    {
        public string ImeP { get; set; }
        public Predmet()
        {

        }
        public Predmet(string ime, string priimek, char spol, string datum_r, string naslov, string email, string sola, string kraj, string razred, string predmet) : base(ime, priimek, spol, datum_r, naslov, email, sola, kraj, razred)
        {
            ImeP = predmet;
        }
    }*/
}
