namespace SBGhadgev1
{
    partial class MeasurementSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeasurementSheet));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblmeasurmentNO = new System.Windows.Forms.Label();
            this.txtmno = new System.Windows.Forms.TextBox();
            this.txtplantno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.HScrollBar();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnload = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(750, 900);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SizeChanged += new System.EventHandler(this.tabControl1_SizeChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(742, 874);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(742, 824);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblmeasurmentNO
            // 
            this.lblmeasurmentNO.AutoSize = true;
            this.lblmeasurmentNO.BackColor = System.Drawing.Color.Transparent;
            this.lblmeasurmentNO.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmeasurmentNO.ForeColor = System.Drawing.Color.FloralWhite;
            this.lblmeasurmentNO.Location = new System.Drawing.Point(30, 15);
            this.lblmeasurmentNO.Name = "lblmeasurmentNO";
            this.lblmeasurmentNO.Size = new System.Drawing.Size(58, 18);
            this.lblmeasurmentNO.TabIndex = 3;
            this.lblmeasurmentNO.Text = "Bill No:";
            // 
            // txtmno
            // 
            this.txtmno.Location = new System.Drawing.Point(135, 12);
            this.txtmno.Name = "txtmno";
            this.txtmno.Size = new System.Drawing.Size(100, 20);
            this.txtmno.TabIndex = 4;
            // 
            // txtplantno
            // 
            this.txtplantno.Location = new System.Drawing.Point(135, 38);
            this.txtplantno.Name = "txtplantno";
            this.txtplantno.Size = new System.Drawing.Size(100, 20);
            this.txtplantno.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Plant No.:";
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(135, 64);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(96, 20);
            this.dtp1.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(37, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Date:";
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(0, 0);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(80, 17);
            this.s.TabIndex = 0;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnDelete.BackgroundImage = global::SBGhadge1.Properties.Resources.Delete;
            this.BtnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnDelete.Location = new System.Drawing.Point(528, 38);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 40);
            this.BtnDelete.TabIndex = 13;
            this.BtnDelete.Text = "  Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpload.BackgroundImage = global::SBGhadge1.Properties.Resources.up1;
            this.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpload.Location = new System.Drawing.Point(357, 1);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(75, 33);
            this.btnUpload.TabIndex = 12;
            this.btnUpload.Text = "      Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsearch.BackgroundImage = global::SBGhadge1.Properties.Resources.Search1;
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearch.Location = new System.Drawing.Point(357, 38);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(75, 38);
            this.btnsearch.TabIndex = 11;
            this.btnsearch.Text = "  Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnload
            // 
            this.btnload.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnload.BackgroundImage = global::SBGhadge1.Properties.Resources.Load;
            this.btnload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnload.Location = new System.Drawing.Point(438, 1);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 31);
            this.btnload.TabIndex = 6;
            this.btnload.Text = "  Load";
            this.btnload.UseVisualStyleBackColor = false;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprint.BackgroundImage = global::SBGhadge1.Properties.Resources.Print;
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.Location = new System.Drawing.Point(528, 1);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 33);
            this.btnprint.TabIndex = 5;
            this.btnprint.Text = "    Print";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.BackgroundImage = global::SBGhadge1.Properties.Resources.Save;
            this.btnsave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsave.Location = new System.Drawing.Point(438, 38);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 38);
            this.btnsave.TabIndex = 2;
            this.btnsave.Text = "  Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.BackgroundImage = global::SBGhadge1.Properties.Resources.Next;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(241, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "          NextPage";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MeasurementSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(766, 698);
            this.Controls.Add(this.BtnDelete);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtplantno);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.txtmno);
            this.Controls.Add(this.lblmeasurmentNO);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeasurementSheet";
            this.Text = "MeasurementSheet";
            this.Load += new System.EventHandler(this.MeasurementSheet_Load);
            this.SizeChanged += new System.EventHandler(this.MeasurementSheet_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MeasurementSheet_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label lblmeasurmentNO;
        private System.Windows.Forms.TextBox txtmno;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.TextBox txtplantno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.HScrollBar s;
        private System.Windows.Forms.Button BtnDelete;
    }
}