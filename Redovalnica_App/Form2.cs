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
        //removanje izbranih nodes - treeView1.Nodes.Remove(treeView1.SelectedNode);
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //nared da se preveri na keri šoli je učitelj da ne bo vrglo vse razrede ki obstajajo v bazi
            Razred_Combobox.Text = "-Select-";
            Predmet_ComboBox.Text = "-Select-";
            SolskoLeto_Combobox.Text = "-Select-";
            Vrsta_Ur_Combobox.Text = "-Select-";

            RedovalnicaDatabase r = new RedovalnicaDatabase();
            foreach (Razred item in r.ReturnVseRazrede())
            {
                Razred_Combobox.Items.Add(item.ImeR);
            }

            RedovalnicaDatabase p = new RedovalnicaDatabase();
            foreach (Predmet item in p.ReturnVsePredmete())
            {
                Predmet_ComboBox.Items.Add(item.ImeP);
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
        private void Predmet_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            if (Razred_Combobox.Text != "-Select-" && SolskoLeto_Combobox.Text != "-Select-")
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Učenci");
                foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_SolskoLeto(Razred_Combobox.Text, Predmet_ComboBox.Text, SolskoLeto_Combobox.Text))
                {
                    treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                }
            }
        }

        private void SolskoLeto_Combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            if (Predmet_ComboBox.Text != "-Select-" && Razred_Combobox.Text != "-Select-")
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Učenci");
                foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_SolskoLeto(Razred_Combobox.Text, Predmet_ComboBox.Text, SolskoLeto_Combobox.Text))
                {
                    treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                }
            }
        }

        private void Razred_Combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            if (Predmet_ComboBox.Text != "-Select-" && SolskoLeto_Combobox.Text != "-Select-")
            {
                treeView1.Nodes.Clear();
                treeView1.Nodes.Add("Učenci");
                foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_SolskoLeto(Razred_Combobox.Text, Predmet_ComboBox.Text, SolskoLeto_Combobox.Text))
                {
                    treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                }
            }
        }

        private void Vrsta_Ur_Combobox_SelectionChangeCommitted(object sender, EventArgs e)
        {

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
    }
}
