namespace SBGhadgev1
{
    partial class UpdateMeasure
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtplantno = new System.Windows.Forms.TextBox();
            this.btnload = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtmno = new System.Windows.Forms.TextBox();
            this.lblmeasurmentNO = new System.Windows.Forms.Label();
            this.btnsave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 67);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 750);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(922, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(922, 724);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(615, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Date:";
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(665, 47);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(96, 20);
            this.dtp1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Plant No.:";
            // 
            // txtplantno
            // 
            this.txtplantno.Location = new System.Drawing.Point(354, 44);
            this.txtplantno.Name = "txtplantno";
            this.txtplantno.Size = new System.Drawing.Size(200, 20);
            this.txtplantno.TabIndex = 17;
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(605, 16);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(75, 23);
            this.btnload.TabIndex = 16;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(479, 16);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 23);
            this.btnprint.TabIndex = 15;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // txtmno
            // 
            this.txtmno.Location = new System.Drawing.Point(354, 17);
            this.txtmno.Name = "txtmno";
            this.txtmno.Size = new System.Drawing.Size(100, 20);
            this.txtmno.TabIndex = 14;
            // 
            // lblmeasurmentNO
            // 
            this.lblmeasurmentNO.AutoSize = true;
            this.lblmeasurmentNO.Location = new System.Drawing.Point(286, 21);
            this.lblmeasurmentNO.Name = "lblmeasurmentNO";
            this.lblmeasurmentNO.Size = new System.Drawing.Size(40, 13);
            this.lblmeasurmentNO.TabIndex = 13;
            this.lblmeasurmentNO.Text = "Bill No:";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(694, 17);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 23);
            this.btnsave.TabIndex = 12;
            this.btnsave.Text = "Update";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(40, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "NextPage";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(780, 17);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(75, 23);
            this.btndelete.TabIndex = 21;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // UpdateMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(947, 698);
            this.Controls.Add(this.btndelete);
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
            this.Name = "UpdateMeasure";
            this.Text = "UpdateMeasure";
            this.Load += new System.EventHandler(this.UpdateMeasure_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtplantno;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnprint;
        public System.Windows.Forms.TextBox txtmno;
        private System.Windows.Forms.Label lblmeasurmentNO;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btndelete;
    }
}