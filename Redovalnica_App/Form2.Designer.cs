
namespace Redovalnica_App
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Predmet_Combobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_PotrdiDanasnjoPrisotnost = new System.Windows.Forms.Button();
            this.Btn_PrisotnostZaNazaj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Razred_Combobox = new System.Windows.Forms.ComboBox();
            this.SolskoLeto_Combobox = new System.Windows.Forms.ComboBox();
            this.Vrsta_Ur_Combobox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(831, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.monthCalendar1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(823, 464);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Preverjanje prisotnosti";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(522, 243);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Predmet_Combobox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Btn_PotrdiDanasnjoPrisotnost);
            this.groupBox1.Controls.Add(this.Btn_PrisotnostZaNazaj);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.Razred_Combobox);
            this.groupBox1.Controls.Add(this.SolskoLeto_Combobox);
            this.groupBox1.Controls.Add(this.Vrsta_Ur_Combobox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(24, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 441);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Prisotnost";
            // 
            // Predmet_Combobox
            // 
            this.Predmet_Combobox.FormattingEnabled = true;
            this.Predmet_Combobox.Location = new System.Drawing.Point(119, 64);
            this.Predmet_Combobox.Name = "Predmet_Combobox";
            this.Predmet_Combobox.Size = new System.Drawing.Size(148, 24);
            this.Predmet_Combobox.TabIndex = 13;
            this.Predmet_Combobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Vrsta_Ur_Combobox_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "Predmet:";
            // 
            // Btn_PotrdiDanasnjoPrisotnost
            // 
            this.Btn_PotrdiDanasnjoPrisotnost.Location = new System.Drawing.Point(302, 124);
            this.Btn_PotrdiDanasnjoPrisotnost.Name = "Btn_PotrdiDanasnjoPrisotnost";
            this.Btn_PotrdiDanasnjoPrisotnost.Size = new System.Drawing.Size(93, 48);
            this.Btn_PotrdiDanasnjoPrisotnost.TabIndex = 11;
            this.Btn_PotrdiDanasnjoPrisotnost.Text = "Potrdi prisotnost";
            this.Btn_PotrdiDanasnjoPrisotnost.UseVisualStyleBackColor = true;
            this.Btn_PotrdiDanasnjoPrisotnost.Click += new System.EventHandler(this.Btn_PotrdiDanasnjoPrisotnost_Click);
            // 
            // Btn_PrisotnostZaNazaj
            // 
            this.Btn_PrisotnostZaNazaj.Location = new System.Drawing.Point(302, 243);
            this.Btn_PrisotnostZaNazaj.Name = "Btn_PrisotnostZaNazaj";
            this.Btn_PrisotnostZaNazaj.Size = new System.Drawing.Size(93, 61);
            this.Btn_PrisotnostZaNazaj.TabIndex = 10;
            this.Btn_PrisotnostZaNazaj.Text = "Preveri prisotnost za nazaj";
            this.Btn_PrisotnostZaNazaj.UseVisualStyleBackColor = true;
            this.Btn_PrisotnostZaNazaj.Click += new System.EventHandler(this.Btn_PrisotnostZaNazaj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Razred:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Šolsko leto:";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(26, 187);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(241, 238);
            this.treeView1.TabIndex = 5;
            // 
            // Razred_Combobox
            // 
            this.Razred_Combobox.FormattingEnabled = true;
            this.Razred_Combobox.Location = new System.Drawing.Point(119, 24);
            this.Razred_Combobox.Name = "Razred_Combobox";
            this.Razred_Combobox.Size = new System.Drawing.Size(148, 24);
            this.Razred_Combobox.TabIndex = 1;
            this.Razred_Combobox.SelectionChangeCommitted += new System.EventHandler(this.Razred_Combobox_SelectionChangeCommitted);
            this.Razred_Combobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Razred_Combobox_KeyDown);
            // 
            // SolskoLeto_Combobox
            // 
            this.SolskoLeto_Combobox.FormattingEnabled = true;
            this.SolskoLeto_Combobox.Location = new System.Drawing.Point(119, 144);
            this.SolskoLeto_Combobox.Name = "SolskoLeto_Combobox";
            this.SolskoLeto_Combobox.Size = new System.Drawing.Size(148, 24);
            this.SolskoLeto_Combobox.TabIndex = 6;
            this.SolskoLeto_Combobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SolskoLeto_Combobox_KeyDown);
            // 
            // Vrsta_Ur_Combobox
            // 
            this.Vrsta_Ur_Combobox.FormattingEnabled = true;
            this.Vrsta_Ur_Combobox.Location = new System.Drawing.Point(119, 104);
            this.Vrsta_Ur_Combobox.Name = "Vrsta_Ur_Combobox";
            this.Vrsta_Ur_Combobox.Size = new System.Drawing.Size(148, 24);
            this.Vrsta_Ur_Combobox.TabIndex = 2;
            this.Vrsta_Ur_Combobox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Predmet_ComboBox_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Vrsta ur:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(579, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Prijavljeni ste kot bla bla";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(823, 464);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 493);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form2";
            this.Text = "Aplikacija";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Vrsta_Ur_Combobox;
        private System.Windows.Forms.ComboBox Razred_Combobox;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox SolskoLeto_Combobox;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_PotrdiDanasnjoPrisotnost;
        private System.Windows.Forms.Button Btn_PrisotnostZaNazaj;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox Predmet_Combobox;
    }
}