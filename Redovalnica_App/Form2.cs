using System;
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
            RedovalnicaDatabase r = new RedovalnicaDatabase();
            foreach (Razred item in r.ReturnVseRazrede())
            {
                comboBox1.Items.Add(item.ImeR);
            }

            RedovalnicaDatabase p = new RedovalnicaDatabase();
            foreach (Predmet item in p.ReturnVsePredmete())
            {
                comboBox2.Items.Add(item.ImeP);
            }

            RedovalnicaDatabase s = new RedovalnicaDatabase();
            foreach (Solsko_Leto item in s.ReturnVsaSolskaLeta())
            {
                comboBox3.Items.Add(item.SLeto);
            }

            treeView1.Nodes.Add("Učenci");

            RedovalnicaDatabase u = new RedovalnicaDatabase();
            foreach(Ucenec item in u.ReturnVseUcence())
            {
                treeView1.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
            }
            
        }
        //mogoc bom tree view uporabu za prisotnost ali datagridview
    }
}
