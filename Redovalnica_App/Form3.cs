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
    public partial class Form3 : Form
    {
        static int st_ucencev1, st_ucencev2, st_ucencev3, st_ucencev4, st_ucencev5;
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
        
        private void Form3_Load(object sender, EventArgs e)
        {
            int[] st_ucencev = new int[] { st_ucencev1, st_ucencev2, st_ucencev3, st_ucencev4, st_ucencev5};
            string[] vrste_ocen = new string[] { "nzd(1)", "zd(2)", "db(3)", "pdb(4)", "odl(5)" };

            OcenaChart.Series["ocene"].Points.DataBindXY(vrste_ocen, st_ucencev);
            OcenaChart.Series["ocene"].Label = "#PERCENT";

            for(int i = 0; i<vrste_ocen.Length; i++)
                OcenaChart.Series["ocene"].Points[i].LegendText = vrste_ocen[i];
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void OcenaChart_MouseHover(object sender, EventArgs e)
        {
            OcenaChart.Series[0].ToolTip = "#VALY";
        }
    }
}
