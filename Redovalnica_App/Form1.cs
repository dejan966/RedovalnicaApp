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
    public partial class Form1 : Form
    {
        Form2 a;
        public Form1()
        {
            InitializeComponent();
        }

        private void Btn_Prijava_Click(object sender, EventArgs e)
        {
            string Uemail = textBox1.Text;
            string Ugeslo = textBox2.Text;
            Ucitelj u = new Ucitelj(Uemail, Ugeslo);

            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            if (rd.PreveriPrijavo(u) == false)
                MessageBox.Show("Napačno geslo ali email", "Opozorilo");
            else
            {
                if (a == null)
                    a = new Form2();

                Form2.MailUcitelja(textBox1.Text);
                a.Show();
                Hide();
            }  
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
