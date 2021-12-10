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
        public Form1()
        {
            InitializeComponent();

            /* dela
             * RedovalnicaDatabase rd = new RedovalnicaDatabase();
               label1.Text = rd.ReturnPredmet();*/
        }
    }
}
