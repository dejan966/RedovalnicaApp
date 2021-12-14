﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RedovalnicaData;
using Npgsql;

namespace Redovalnica_App
{
    public partial class Form2 : Form
    {
        //nared da se preveri na keri šoli je učitelj da ne bo vrglo vse razrede ki obstajajo v bazi
        //removanje izbranih nodes - treeView1.Nodes.Remove(treeView1.SelectedNode);
        //Prisotnost za nazaj morm preverit vrednosti v comboboxih
        //za današnjo prisotnost preverim če mam kej v treeview selectano
        static string uMail;
        static string imePriimekUcitelja;
        public Form2()
        {
            InitializeComponent();
        }

        public static void MailUcitelja(string mail)
        {
            uMail = mail;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RedovalnicaDatabase rb = new RedovalnicaDatabase();
            imePriimekUcitelja = rb.ReturnImePriimekUcenca(uMail);
            label1.Text = "Prijavljeni ste kot " + imePriimekUcitelja;
            
            //MessageBox.Show(monthCalendar1.TodayDate.ToString());
            Razred_Combobox.Text = "-Select-";
            Vrsta_Ur_Combobox.Text = "-Select-";
            SolskoLeto_Combobox.Text = "-Select-";
            Predmet_Combobox.Text = "-Select-";
            
            RedovalnicaDatabase r = new RedovalnicaDatabase();
            foreach (Razred item in r.ReturnVseRazrede())
            {
                Razred_Combobox.Items.Add(item.ImeR);
            }

            RedovalnicaDatabase p = new RedovalnicaDatabase();
            foreach (Predmet item in p.ReturnVsePredmete())
            {
                Predmet_Combobox.Items.Add(item.ImeP);
            }

            RedovalnicaDatabase s = new RedovalnicaDatabase();
            foreach (Solsko_Leto item in s.ReturnVsaSolskaLeta())
            {
                SolskoLeto_Combobox.Items.Add(item.SLeto);
            }

            RedovalnicaDatabase v = new RedovalnicaDatabase();
            foreach(Vrsta_Ur item in v.ReturnVseVrsteUr())
            {
                Vrsta_Ur_Combobox.Items.Add(item.Ura);
            }

            treeView1.Nodes.Add("Učenci");
            RedovalnicaDatabase u = new RedovalnicaDatabase();
            foreach(Ucenec item in u.ReturnVseUcence())
            {
                treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
            }
        }

        private void Razred_Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Predmet_ComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SolskoLeto_Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Vrsta_Ur_Combobox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Btn_PrisotnostZaNazaj_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add("Učenci");

            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto(Razred_Combobox.Text, Predmet_Combobox.Text, Vrsta_Ur_Combobox.Text, SolskoLeto_Combobox.Text))
            {
                treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
            }
        }

        private void Btn_PotrdiDanasnjoPrisotnost_Click(object sender, EventArgs e)
        {
            //izberes razred v comboboxu in ti vrze vse ucence v tem razredu
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            //rd.InsertRazrediPredmeti(Razred_Combobox.Text, Predmet_Combobox.Text, imePriimekUcitelja);
            //int idRazredPredmet = rd.IDRazrediPredmeti(Razred_Combobox.Text, Predmet_Combobox.Text, imePriimekUcitelja);
            //rd.InsertUreIzvedb
            //int idUreIzvedb = rd.IDUreIzvedb(idRazredPredmet, Vrsta_Ur_Combobox.Text, datum);
            /*dal bom ucence v array pa bom s for zanko insertu v 
            rd.InsertPrisotnosti(ucenec, idUreIzvedb, opomba);*/
        }
    }
}
