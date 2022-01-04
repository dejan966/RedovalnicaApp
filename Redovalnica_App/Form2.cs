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
        //nared da se preveri na keri šoli je učitelj da ne bo vrglo vse razrede ki obstajajo v bazi
        //removanje izbranih nodes - treeView1.Nodes.Remove(treeView1.SelectedNode);
        Form3 a;
        static string uMail;
        static string imePriimekUcitelja;
        List<string> mankjkajociUcenci = new List<string>();
        string[] mU;
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
            imePriimekUcitelja = rb.ReturnImePriimekUcitelja(uMail);
            label1.Text = "Prijavljeni ste kot " + imePriimekUcitelja;
            label12.Text = "Prijavljeni ste kot " + imePriimekUcitelja;

            //prisotnost
            Razred_ComboboxP.Text = "-Select-";
            Vrsta_Ur_ComboboxP.Text = "-Select-";
            SolskoLeto_ComboboxP.Text = "-Select-";
            Predmet_ComboboxP.Text = "-Select-";

            //ocene
            Razred_ComboboxO.Text = "-Select-";
            Predmet_ComboboxO.Text = "-Select-";
            SolskoLeto_ComboboxO.Text = "-Select-";
            OcenaCombobox.Text = "-Select-";

            RedovalnicaDatabase r = new RedovalnicaDatabase();
            foreach (Razred item in r.ReturnVseRazrede())
            {
                Razred_ComboboxP.Items.Add(item.ImeR);
                Razred_ComboboxO.Items.Add(item.ImeR);
            }

            RedovalnicaDatabase p = new RedovalnicaDatabase();
            foreach (Predmet item in p.ReturnVsePredmete())
            {
                Predmet_ComboboxP.Items.Add(item.ImeP);
                Predmet_ComboboxO.Items.Add(item.ImeP);
            }

            RedovalnicaDatabase s = new RedovalnicaDatabase();
            foreach (Solsko_Leto item in s.ReturnVsaSolskaLeta())
            {
                SolskoLeto_ComboboxP.Items.Add(item.SLeto);
                SolskoLeto_ComboboxO.Items.Add(item.SLeto);
            }

            RedovalnicaDatabase v = new RedovalnicaDatabase();
            foreach(Vrsta_Ur item in v.ReturnVseVrsteUr())
                Vrsta_Ur_ComboboxP.Items.Add(item.Ura);

            RedovalnicaDatabase o = new RedovalnicaDatabase();
            foreach (Ocena item in o.ReturnVseOcene())
                OcenaCombobox.Items.Add(item.StO);

            PrisotnostTreeView.Nodes.Add("Učenci");
            treeView2.Nodes.Add("Učenci");
        }

        private void Btn_PrisotnostZaNazaj_Click(object sender, EventArgs e)
        {
            //morem nardit da izpise vse ucenci tud mankjkajoce(naj jih izpise z rdeco), da lahko odstranim da so manjkali
            string date = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            if (Razred_ComboboxP.Text != "-Select-" && Predmet_ComboboxP.Text != "-Select-" && Vrsta_Ur_ComboboxP.Text != "-Select-" && SolskoLeto_ComboboxP.Text != "-Select-")
            {
                PrisotnostTreeView.Nodes.Clear();
                PrisotnostTreeView.Nodes.Add("Učenci");

                RedovalnicaDatabase rd = new RedovalnicaDatabase();
                foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto_Datum(Razred_ComboboxP.SelectedItem.ToString(), Predmet_ComboboxP.SelectedItem.ToString(), Vrsta_Ur_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString(), date))
                {
                    if(item.Ime != "" && item.Priimek != "")
                        PrisotnostTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                }
            }
            else
                MessageBox.Show("Morate izbrati vrednosti v Comboboxih", "Opozorilo");
            
        }

        private void Btn_PotrdiDanasnjoPrisotnost_Click(object sender, EventArgs e)
        {
            //selectam ucence v treeview za prisotnost
            string Idate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string Sdate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            if (Razred_ComboboxP.Text != "-Select-" && Predmet_ComboboxP.Text != "-Select-" && Vrsta_Ur_ComboboxP.Text != "-Select-" && SolskoLeto_ComboboxP.Text != "-Select-")
            {
                RedovalnicaDatabase rp = new RedovalnicaDatabase();
                rp.InsertRazrediPredmeti(Predmet_ComboboxP.SelectedItem.ToString(), Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString(), imePriimekUcitelja);
                
                RedovalnicaDatabase ra = new RedovalnicaDatabase();
                int idRazredPredmet = ra.IDRazrediPredmeti(Predmet_ComboboxP.SelectedItem.ToString(), Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString(), imePriimekUcitelja);
                
                RedovalnicaDatabase ru = new RedovalnicaDatabase();
                ru.InsertUreIzvedb(idRazredPredmet, Vrsta_Ur_ComboboxP.SelectedItem.ToString(), Idate);

                RedovalnicaDatabase rd = new RedovalnicaDatabase();
                int idUreIzvedb = rd.IDUreIzvedb(idRazredPredmet, Vrsta_Ur_ComboboxP.SelectedItem.ToString(), Sdate);

                string opomba = textBox1.Text;
                for (int i = 0; i < mU.Length; i++)
                {
                    RedovalnicaDatabase re = new RedovalnicaDatabase();
                    re.InsertPrisotnosti(mU[i], idUreIzvedb, opomba);
                }
                
                PrisotnostTreeView.Nodes.Clear();
                PrisotnostTreeView.Nodes.Add("Učenci");
                RedovalnicaDatabase rd2 = new RedovalnicaDatabase();
                foreach (Ucenec item in rd2.ReturnUcenci_Razred(Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString()))
                {
                    //preverim a vrne ucence funkcija
                    if (item.Ime != "" && item.Priimek != "")
                        PrisotnostTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                    else
                    {
                        PrisotnostTreeView.Nodes.Clear();
                        PrisotnostTreeView.Nodes.Add("Učenci");
                    }
                }

            }
            else
                MessageBox.Show("Morate izbrati vrednosti v Comboboxih", "Opozorilo");
        }

        private void Razred_ComboboxP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PrisotnostTreeView.Nodes.Clear();
            PrisotnostTreeView.Nodes.Add("Učenci");
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            foreach (Ucenec item in rd.ReturnUcenci_Razred(Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString()))
            {
                //preverim a vrne ucence funkcija
                if (item.Ime != "" && item.Priimek != "")
                {
                    PrisotnostTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                    mankjkajociUcenci.Add(item.Ime + ' ' + item.Priimek);
                    mU = mankjkajociUcenci.ToArray();

                    /* tk se doda direkt iz treeview subnode v list
                    foreach (TreeNode node in PrisotnostTreeView.Nodes[0].Nodes)
                    {
                        mankjkajociUcenci.Add(node.Text);
                    }
                    */
                }
                else
                {
                    PrisotnostTreeView.Nodes.Clear();
                    PrisotnostTreeView.Nodes.Add("Učenci");
                }
            }
        }

        private void Vrsta_Ur_ComboboxP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Predmet_ComboboxP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Razred_ComboboxP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SolskoLeto_ComboboxP_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void SolskoLeto_ComboboxP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //pokaže razrede glede na šolsko leto
            Razred_ComboboxP.Items.Clear();
            Razred_ComboboxP.Text = "";
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            foreach (Razred item in rd.ReturnRazred_SolskoLeto(SolskoLeto_ComboboxP.SelectedItem.ToString()))
            {
                Razred_ComboboxP.Items.Add(item.ImeR);
            }
        }

        private void Razred_ComboboxO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            treeView2.Nodes.Clear();
            treeView2.Nodes.Add("Učenci");
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            foreach (Ucenec item in rd.ReturnUcenci_Razred(Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString()))
            {
                //preverim a vrne ucence funkcija
                if (item.Ime != "" && item.Priimek != "")
                    treeView2.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                else
                {
                    treeView2.Nodes.Clear();
                    treeView2.Nodes.Add("Učenci");
                }
            }
        }

        private void SolskoLeto_ComboboxO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Razred_ComboboxO.Items.Clear();
            Razred_ComboboxO.Text = "";
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            foreach (Razred item in rd.ReturnRazred_SolskoLeto(SolskoLeto_ComboboxO.SelectedItem.ToString()))
            {
                Razred_ComboboxO.Items.Add(item.ImeR);
            }
        }

        private void SolskoLeto_ComboboxO_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Razred_ComboboxO_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Predmet_ComboboxO_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Vrsta_Ur_ComboboxO_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void OcenaCombobox_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void Btn_InsertOcena_Click(object sender, EventArgs e)
        {
            if (Razred_ComboboxO.Text != "-Select-" && Predmet_ComboboxO.Text != "-Select-" && SolskoLeto_ComboboxO.Text != "-Select-")
            {
                string datum = DateTime.Parse(dateTimePicker2.Text).ToString("yyyy-MM-dd");
                string ucenec = treeView2.SelectedNode.Text;

                RedovalnicaDatabase r = new RedovalnicaDatabase();
                int idRazredPredmet = r.IDRazrediPredmeti(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString(), imePriimekUcitelja);

                RedovalnicaDatabase o = new RedovalnicaDatabase();
                o.InsertOcena_Ucenec(ucenec, OcenaCombobox.SelectedItem.ToString(), datum, idRazredPredmet);
            }
            else
                MessageBox.Show("Izberite vrednosti iz comboboxov", "Opozorilo");
        }

        private void Btn_Statistika_Ocene_Click(object sender, EventArgs e)
        {
            if (Razred_ComboboxO.Text != "-Select-" && Predmet_ComboboxO.Text != "-Select-" && SolskoLeto_ComboboxO.Text != "-Select-")
            {
                RedovalnicaDatabase rd = new RedovalnicaDatabase();
                int st_ucencevR = rd.Return_StUcenci_Razred(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString());

                RedovalnicaDatabase rd1 = new RedovalnicaDatabase();
                int st_Uocen1 = rd1.Return_Ucenci_Ocena1(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), Predmet_ComboboxO.SelectedItem.ToString());

                RedovalnicaDatabase rd2 = new RedovalnicaDatabase();
                int st_Uocen2 = rd2.Return_Ucenci_Ocena2(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), Predmet_ComboboxO.SelectedItem.ToString());

                RedovalnicaDatabase rd3 = new RedovalnicaDatabase();
                int st_Uocen3 = rd3.Return_Ucenci_Ocena3(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), Predmet_ComboboxO.SelectedItem.ToString());

                RedovalnicaDatabase rd4 = new RedovalnicaDatabase();
                int st_Uocen4 = rd4.Return_Ucenci_Ocena4(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), Predmet_ComboboxO.SelectedItem.ToString());

                RedovalnicaDatabase rd5 = new RedovalnicaDatabase();
                int st_Uocen5 = rd5.Return_Ucenci_Ocena5(SolskoLeto_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), Predmet_ComboboxO.SelectedItem.ToString());

                Form3.StUcenci_Razred(st_ucencevR);
                Form3.Ocene_Ucenci(st_Uocen1, st_Uocen2, st_Uocen3, st_Uocen4, st_Uocen5);
                
                if (a == null)
                    a = new Form3();
                a.ShowDialog();
            }
            else
                MessageBox.Show("Morate izbrati vrednosti v Comboboxih", "Opozorilo");
        }

        private void PrisotnostTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //dodam v list to ko selectam in convertam v array
            Btn_PotrdiDanasnjoPrisotnost.Enabled = true;
            PrisotnostTreeView.SelectedNode.ForeColor = Color.Red;
            mankjkajociUcenci.Remove(PrisotnostTreeView.SelectedNode.Text);
            mU = mankjkajociUcenci.ToArray();
        }
    }
}
