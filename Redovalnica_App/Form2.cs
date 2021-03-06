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
        Form3 a;
        static string sMail;
        static string imePriimekUcitelja;
        List<string> manjkajociUcenci = new List<string>();
        List<string> oceneUcenci = new List<string>();
        List<int> ocene = new List<int>();
        public Form2()
        {
            InitializeComponent();
        }

        public static void MailUcitelja(string mail)
        {
            sMail = mail;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RedovalnicaDatabase rb = new RedovalnicaDatabase();
            Ucitelj mail = new Ucitelj(sMail);
            imePriimekUcitelja = rb.ReturnImePriimekUcitelja(mail);
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
            foreach (RazredPredmet item in p.ReturnVsePredmete())
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
            OcenaTreeView.Nodes.Add("Učenci");
        }

        private void Btn_PrisotnostZaNazaj_Click(object sender, EventArgs e)
        {
            string date = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            if (Razred_ComboboxP.Text != "-Select-" && Predmet_ComboboxP.Text != "-Select-" && Vrsta_Ur_ComboboxP.Text != "-Select-" && SolskoLeto_ComboboxP.Text != "-Select-")
            {
                PrisotnostTreeView.Nodes.Clear();
                PrisotnostTreeView.Nodes.Add("Učenci");

                Prisotnost prisotnostZaNazaj = new Prisotnost(Predmet_ComboboxP.SelectedItem.ToString(), Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString(), Vrsta_Ur_ComboboxP.SelectedItem.ToString(), date);
                RedovalnicaDatabase rd = new RedovalnicaDatabase();
                foreach (Ucenec item in rd.ReturnUcenci_Razred_Predmet_Vrsta_Ure_SolskoLeto_Datum(prisotnostZaNazaj))
                {
                    if (item.Ime != "" && item.Priimek != "")
                        PrisotnostTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                }
            }
            else
                MessageBox.Show("Morate izbrati vrednosti v Comboboxih", "Opozorilo");
            
        }

        private void Btn_PotrdiDanasnjoPrisotnost_Click(object sender, EventArgs e)
        {
            //selectam ucence v treeview za prisotnost v funkciji PrisotnostTreeView_AfterSelect
            string Idate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string Sdate = DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd");
            if (Razred_ComboboxP.Text != "-Select-" && Predmet_ComboboxP.Text != "-Select-" && Vrsta_Ur_ComboboxP.Text != "-Select-" && SolskoLeto_ComboboxP.Text != "-Select-")
            {
                string opomba = textBox1.Text;
                try
                {
                    RedovalnicaDatabase rp = new RedovalnicaDatabase();
                    RazredPredmet razredPredmet = new RazredPredmet(Predmet_ComboboxP.SelectedItem.ToString(), Razred_ComboboxP.SelectedItem.ToString(), imePriimekUcitelja, SolskoLeto_ComboboxP.SelectedItem.ToString());
                    int idRazredPredmetR = rp.InsertSelectRazrediPredmeti(razredPredmet);
                    MessageBox.Show(idRazredPredmetR.ToString());
              
                    RedovalnicaDatabase ru = new RedovalnicaDatabase();
                    UreIzvedbe ure = new UreIzvedbe(idRazredPredmetR, Vrsta_Ur_ComboboxP.SelectedItem.ToString(), Sdate, Idate);
                    int idUreIzvedbR  = ru.InsertSelectUreIzvedb(ure);
                    MessageBox.Show(idUreIzvedbR.ToString());

                    for (int i = 0; i < manjkajociUcenci.Count; i++)
                    {
                        Prisotnost danasnjaPrisotnost = new Prisotnost(manjkajociUcenci[i], idUreIzvedbR, opomba);
                        RedovalnicaDatabase re = new RedovalnicaDatabase();
                        re.InsertPrisotnosti(danasnjaPrisotnost);
                    }
                    MessageBox.Show("Uspešno dodana prisotnost za ta dan.", "Prisotnost", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ni bilo mogoče dodati prisotnosti za ta dan.\n'" + ex.Message + "'", "Prisotnost", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                PrisotnostTreeView.Nodes.Clear();
                PrisotnostTreeView.Nodes.Add("Učenci");
                RedovalnicaDatabase rd2 = new RedovalnicaDatabase();
                Razred rU = new Razred(Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString());
                foreach (Ucenec item in rd2.ReturnUcenci_Razred(rU))
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
            Razred rU = new Razred(Razred_ComboboxP.SelectedItem.ToString(), SolskoLeto_ComboboxP.SelectedItem.ToString());
            foreach (Ucenec item in rd.ReturnUcenci_Razred(rU))
            {
                //preverim a vrne ucence funkcija
                if (item.Ime != "" && item.Priimek != "")
                {
                    if (!manjkajociUcenci.Any())
                    {
                        for (int i = 0; i < manjkajociUcenci.Count(); i++)
                            manjkajociUcenci.RemoveAt(i);
                    }
                    PrisotnostTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                    manjkajociUcenci.Add(item.Ime + ' ' + item.Priimek);

                    /* tk se doda direkt iz treeview subnode v list
                    foreach (TreeNode node in PrisotnostTreeView.Nodes[0].Nodes)
                    {
                        manjkajociUcenci.Add(node.Text);
                    } */
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
            Solsko_Leto sl = new Solsko_Leto(SolskoLeto_ComboboxP.SelectedItem.ToString());
            foreach (Razred item in rd.ReturnRazred_SolskoLeto(sl))
            {
                Razred_ComboboxP.Items.Add(item.ImeR);
            }
            PrisotnostTreeView.Nodes.Clear();
            PrisotnostTreeView.Nodes.Add("Učenci");
        }

        private void Razred_ComboboxO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //prikaže učence glede na razred
            OcenaTreeView.Nodes.Clear();
            OcenaTreeView.Nodes.Add("Učenci");
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            Razred rU = new Razred(Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
            foreach (Ucenec item in rd.ReturnUcenci_Razred(rU))
            {
                //preverim a vrne ucence funkcija
                if (item.Ime != "" && item.Priimek != "")
                    OcenaTreeView.Nodes[0].Nodes.Add(item.Ime + ' ' + item.Priimek);
                else
                {
                    OcenaTreeView.Nodes.Clear();
                    OcenaTreeView.Nodes.Add("Učenci");
                }
            }
            if (!ocene.Any() || !oceneUcenci.Any())
            {
                for (int i = 0; i < ocene.Count(); i++)
                    ocene.RemoveAt(i);

                for (int i = 0; i < oceneUcenci.Count(); i++)
                    oceneUcenci.RemoveAt(i);
            }
        }

        private void SolskoLeto_ComboboxO_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Razred_ComboboxO.Items.Clear();
            Razred_ComboboxO.Text = "";
            RedovalnicaDatabase rd = new RedovalnicaDatabase();
            Solsko_Leto sl = new Solsko_Leto(SolskoLeto_ComboboxO.SelectedItem.ToString());
            foreach (Razred item in rd.ReturnRazred_SolskoLeto(sl))
            {
                Razred_ComboboxO.Items.Add(item.ImeR);
            }
            PrisotnostTreeView.Nodes.Clear();
            PrisotnostTreeView.Nodes.Add("Učenci");
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
                try
                {
                    RedovalnicaDatabase rp = new RedovalnicaDatabase();
                    RazredPredmet razredPredmet = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), imePriimekUcitelja, SolskoLeto_ComboboxO.SelectedItem.ToString());
                    int id_rp = rp.InsertSelectRazrediPredmeti(razredPredmet);

                    for(int i = 0; i<oceneUcenci.Count; i++)
                    {
                        Ocena ocena = new Ocena(oceneUcenci[i], ocene[i], datum, id_rp);
                        RedovalnicaDatabase o = new RedovalnicaDatabase();
                        o.InsertOcena_Ucenec(ocena);
                    }
                    MessageBox.Show("Uspešno dodane ocene za učence.", "Ocena", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocen ni bilo mogoče dodati.\n'" + ex.Message + "'", "Ocena", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Izberite vrednosti iz comboboxov", "Opozorilo");
        }

        private void Btn_Statistika_Ocene_Click(object sender, EventArgs e)
        {
            if (Razred_ComboboxO.Text != "-Select-" && Predmet_ComboboxO.Text != "-Select-" && SolskoLeto_ComboboxO.Text != "-Select-")
            {
                RedovalnicaDatabase rd1 = new RedovalnicaDatabase();
                RazredPredmet rp1 = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
                int st_Uocen1 = rd1.Return_Ucenci_Ocena1(rp1);

                RedovalnicaDatabase rd2 = new RedovalnicaDatabase();
                RazredPredmet rp2 = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
                int st_Uocen2 = rd2.Return_Ucenci_Ocena2(rp2);

                RedovalnicaDatabase rd3 = new RedovalnicaDatabase();
                RazredPredmet rp3 = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
                int st_Uocen3 = rd3.Return_Ucenci_Ocena3(rp3);

                RedovalnicaDatabase rd4 = new RedovalnicaDatabase();
                RazredPredmet rp4 = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
                int st_Uocen4 = rd4.Return_Ucenci_Ocena4(rp4);

                RedovalnicaDatabase rd5 = new RedovalnicaDatabase();
                RazredPredmet rp5 = new RazredPredmet(Predmet_ComboboxO.SelectedItem.ToString(), Razred_ComboboxO.SelectedItem.ToString(), SolskoLeto_ComboboxO.SelectedItem.ToString());
                int st_Uocen5 = rd5.Return_Ucenci_Ocena5(rp5);

                Form3.Ocene_Ucenci(st_Uocen1, st_Uocen2, st_Uocen3, st_Uocen4, st_Uocen5);
                
                a = new Form3();
                a.ShowDialog();
            }
            else
                MessageBox.Show("Morate izbrati vrednosti v Comboboxih", "Opozorilo");
        }

        private void PrisotnostTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Btn_PotrdiDanasnjoPrisotnost.Enabled = true;
            PrisotnostTreeView.SelectedNode.ForeColor = Color.Red;
            manjkajociUcenci.Remove(PrisotnostTreeView.SelectedNode.Text);
            
            /*TreeNode tn = PrisotnostTreeView.GetNodeAt(PrisotnostTreeView.PointToClient(Control.MousePosition));
            if (tn != null) {
                //dodam v list to ko selectam in convertam v array
                Btn_PotrdiDanasnjoPrisotnost.Enabled = true;
                PrisotnostTreeView.SelectedNode.ForeColor = Color.Red;
                manjkajociUcenci.Remove(PrisotnostTreeView.SelectedNode.Text);
                mU = manjkajociUcenci.ToArray();
            }
            else
                Btn_PotrdiDanasnjoPrisotnost.Enabled = false;*/
        }

        private void OcenaTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Btn_InsertOcena.Enabled = true;
            OcenaTreeView.SelectedNode.ForeColor = Color.Red;
            oceneUcenci.Add(OcenaTreeView.SelectedNode.Text);
        }

        private void OcenaCombobox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ocene.Add(Convert.ToInt32(OcenaCombobox.SelectedItem));
        }
    }
}
