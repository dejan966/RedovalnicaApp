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

            OcenaChart.Series["ocene"].Points.AddXY("nzd(1)", st_ucencev1);
            OcenaChart.Series["ocene"].Points.AddXY("zd(2)", st_ucencev2);
            OcenaChart.Series["ocene"].Points.AddXY("db(3)", st_ucencev3);
            OcenaChart.Series["ocene"].Points.AddXY("pdb(4)", st_ucencev4);
            OcenaChart.Series["ocene"].Points.AddXY("odl(5)", st_ucencev5);
            OcenaChart.Series["ocene"].Points.AddXY("Niso pisali", st_ucenci_razred);

            //remova text od ocen v tortnem diagramu, če je vrednost 0, remova pa tud legende za tte ocene, kjer je vrednost 0
            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint point in OcenaChart.Series["ocene"].Points)
            {
                if (point.YValues.Length > 0 && (double)point.YValues.GetValue(0) == 0)
                {
                    point.IsEmpty = true;
                }
                else
                {
                    point.IsEmpty = false;
                }
            }
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
