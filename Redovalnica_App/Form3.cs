using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Redovalnica_App
{
    public partial class Form3 : Form
    {
        static int st_ucenci_razred;
        static int st_ucencev1;
        static int st_ucencev2;
        static int st_ucencev3;
        static int st_ucencev4;
        static int st_ucencev5;
        public Form3()
        {
            InitializeComponent();
        }
        public static void Ocene_Ucenci(int st1, int st2, int st3, int st4, int st5)
        {
            st_ucencev1 = st1;
            st_ucencev2 = st2;
            st_ucencev3 = st3;
            st_ucencev4 = st4;
            st_ucencev5 = st5;
        }
        public static void StUcenci_Razred(int st)
        {
            st_ucenci_razred = st;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            st_ucenci_razred = st_ucenci_razred - st_ucencev1 - st_ucencev2 - st_ucencev3 - st_ucencev4 - st_ucencev5;
            
            ocenaChart.Titles.Add("Ocene v razredu");
            ocenaChart.Series["ocene"].Points.AddXY("nzd(1)", st_ucencev1);
            ocenaChart.Series["ocene"].Points.AddXY("zd(2)", st_ucencev2);
            ocenaChart.Series["ocene"].Points.AddXY("db(3)", st_ucencev3);
            ocenaChart.Series["ocene"].Points.AddXY("pdb(4)", st_ucencev4);
            ocenaChart.Series["ocene"].Points.AddXY("odl(5)", st_ucencev5);
            ocenaChart.Series["ocene"].Points.AddXY("Niso pisali", st_ucenci_razred);
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void ocenaChart_MouseHover(object sender, EventArgs e)
        {
            ocenaChart.Series[0].ToolTip = "#VALY";
        }
    }
}
