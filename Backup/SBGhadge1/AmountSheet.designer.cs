namespace SBGhadgev1
{
    partial class AmountSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmountSheet));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPo = new System.Windows.Forms.TextBox();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.txtmno = new System.Windows.Forms.TextBox();
            this.dtpdate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 143);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(950, 500);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(942, 474);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(942, 474);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtPo);
            this.panel1.Controls.Add(this.btnexport);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.BtnSave);
            this.panel1.Controls.Add(this.btnload);
            this.panel1.Controls.Add(this.txtmno);
            this.panel1.Controls.Add(this.dtpdate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(950, 140);
            this.panel1.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(58, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "PO No:";
            // 
            // txtPo
            // 
            this.txtPo.Location = new System.Drawing.Point(150, 99);
            this.txtPo.Name = "txtPo";
            this.txtPo.Size = new System.Drawing.Size(100, 20);
            this.txtPo.TabIndex = 18;
            this.txtPo.Text = "SUN/MUM/MECH-034/2019-20";
            this.txtPo.TextChanged += new System.EventHandler(this.txtPo_TextChanged);
            // 
            // btnexport
            // 
            this.btnexport.BackgroundImage = global::SBGhadge1.Properties.Resources.Export;
            this.btnexport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnexport.Location = new System.Drawing.Point(660, 102);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(117, 35);
            this.btnexport.TabIndex = 17;
            this.btnexport.Text = "Export To Exel";
            this.btnexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Visible = false;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackgroundImage = global::SBGhadge1.Properties.Resources.Print;
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.Location = new System.Drawing.Point(553, 102);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(85, 34);
            this.btnprint.TabIndex = 16;
            this.btnprint.Text = "Print";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Bill No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Algerian", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(325, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mumbai, Phone No. 9960400803";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Algerian", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(284, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(572, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Address: Thaur Mansion, Bldg. No. 2 Room No.3 Mazgoan Road";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Algerian", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(305, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(472, 54);
            this.label4.TabIndex = 11;
            this.label4.Text = "S. B.  Ghadge && Co";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = global::SBGhadge1.Properties.Resources.Save;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.Location = new System.Drawing.Point(450, 104);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(82, 32);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Save";
            this.BtnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnload
            // 
            this.btnload.BackgroundImage = global::SBGhadge1.Properties.Resources.Load;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.Location = new System.Drawing.Point(345, 104);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 33);
            this.btnload.TabIndex = 9;
            this.btnload.Text = "Load";
            this.btnload.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // txtmno
            // 
            this.txtmno.Location = new System.Drawing.Point(150, 62);
            this.txtmno.Name = "txtmno";
            this.txtmno.Size = new System.Drawing.Size(100, 20);
            this.txtmno.TabIndex = 8;
            // 
            // dtpdate
            // 
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpdate.Location = new System.Drawing.Point(729, 81);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(86, 20);
            this.dtpdate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(656, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // AmountSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(803, 615);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "AmountSheet";
            this.Text = "AmountSheet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AmountSheet_Load);
            this.tabControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.TextBox txtmno;
        private System.Windows.Forms.DateTimePicker dtpdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPo;
    }
}