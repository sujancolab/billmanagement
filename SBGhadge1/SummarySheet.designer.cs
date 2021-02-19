namespace SBGhadgev1
{
    partial class SummarySheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummarySheet));
            this.btnExpoToExcel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.lblPageNo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmno = new System.Windows.Forms.TextBox();
            this.lblmeasurmentNO = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExpoToExcel
            // 
            this.btnExpoToExcel.BackgroundImage = global::SBGhadge1.Properties.Resources.Export;
            this.btnExpoToExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExpoToExcel.Location = new System.Drawing.Point(548, 38);
            this.btnExpoToExcel.Name = "btnExpoToExcel";
            this.btnExpoToExcel.Size = new System.Drawing.Size(80, 32);
            this.btnExpoToExcel.TabIndex = 12;
            this.btnExpoToExcel.Text = "  Export";
            this.btnExpoToExcel.UseVisualStyleBackColor = true;
            this.btnExpoToExcel.Visible = false;
            this.btnExpoToExcel.Click += new System.EventHandler(this.btnExpoToExcel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = global::SBGhadge1.Properties.Resources.Print;
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrint.Location = new System.Drawing.Point(449, 38);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 32);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "   Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackgroundImage = global::SBGhadge1.Properties.Resources.Save;
            this.BtnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSave.Location = new System.Drawing.Point(336, 38);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 32);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "   Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnload
            // 
            this.btnload.BackgroundImage = global::SBGhadge1.Properties.Resources.Load;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.Location = new System.Drawing.Point(223, 38);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 32);
            this.btnload.TabIndex = 9;
            this.btnload.Text = "   Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // lblPageNo
            // 
            this.lblPageNo.AutoSize = true;
            this.lblPageNo.Location = new System.Drawing.Point(530, 8);
            this.lblPageNo.Name = "lblPageNo";
            this.lblPageNo.Size = new System.Drawing.Size(13, 13);
            this.lblPageNo.TabIndex = 4;
            this.lblPageNo.Text = "1";
            this.lblPageNo.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(461, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sheetno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Algerian", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(184, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "S. B.  Ghadge && Co";
            // 
            // txtmno
            // 
            this.txtmno.Location = new System.Drawing.Point(324, 5);
            this.txtmno.Name = "txtmno";
            this.txtmno.Size = new System.Drawing.Size(100, 20);
            this.txtmno.TabIndex = 8;
            // 
            // lblmeasurmentNO
            // 
            this.lblmeasurmentNO.AutoSize = true;
            this.lblmeasurmentNO.BackColor = System.Drawing.Color.Transparent;
            this.lblmeasurmentNO.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmeasurmentNO.ForeColor = System.Drawing.Color.Black;
            this.lblmeasurmentNO.Location = new System.Drawing.Point(185, 9);
            this.lblmeasurmentNO.Name = "lblmeasurmentNO";
            this.lblmeasurmentNO.Size = new System.Drawing.Size(133, 18);
            this.lblmeasurmentNO.TabIndex = 7;
            this.lblmeasurmentNO.Text = "Measurment No:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarMonthBackground = System.Drawing.Color.Transparent;
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.Transparent;
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(675, -2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(86, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(597, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.pageno,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 195);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(871, 503);
            this.dataGridView1.TabIndex = 3;
            // 
            // srno
            // 
            this.srno.HeaderText = "srno";
            this.srno.Name = "srno";
            // 
            // pageno
            // 
            this.pageno.HeaderText = "pageno";
            this.pageno.Name = "pageno";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "15 NB 1/2\"";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "20 NB 3/4\"";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "25 NB 1\"";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "40 NB 11/2\"";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "50 NB 2\"";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "65 NB 21/2\"";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "80 NB 3\"";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "100 NB 4\"";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "150 NB 6\"";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "200 NB 8\"";
            this.Column10.Name = "Column10";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // SummarySheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(871, 698);
            this.Controls.Add(this.btnExpoToExcel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPageNo);
            this.Controls.Add(this.lblmeasurmentNO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtmno);
            this.Name = "SummarySheet";
            this.Text = "SummarySheet";
            this.Load += new System.EventHandler(this.SummarySheet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblPageNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn pageno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label lblmeasurmentNO;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExpoToExcel;
        public System.Windows.Forms.TextBox txtmno;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

    }
}