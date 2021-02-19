namespace SBGhadge1
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.btnbrowsephoto = new System.Windows.Forms.Button();
            this.btnbrowseSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtrepass = new System.Windows.Forms.TextBox();
            this.pbPhoto = new System.Windows.Forms.PictureBox();
            this.pbSign = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.lblerror = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign)).BeginInit();
            this.SuspendLayout();
            // 
            // btnbrowsephoto
            // 
            this.btnbrowsephoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowsephoto.Location = new System.Drawing.Point(523, 117);
            this.btnbrowsephoto.Name = "btnbrowsephoto";
            this.btnbrowsephoto.Size = new System.Drawing.Size(106, 29);
            this.btnbrowsephoto.TabIndex = 0;
            this.btnbrowsephoto.Text = "Browse Photo";
            this.btnbrowsephoto.UseVisualStyleBackColor = true;
            this.btnbrowsephoto.Click += new System.EventHandler(this.btnbrowsephoto_Click);
            // 
            // btnbrowseSign
            // 
            this.btnbrowseSign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowseSign.Location = new System.Drawing.Point(512, 214);
            this.btnbrowseSign.Name = "btnbrowseSign";
            this.btnbrowseSign.Size = new System.Drawing.Size(106, 28);
            this.btnbrowseSign.TabIndex = 1;
            this.btnbrowseSign.Text = "Browse Sign.";
            this.btnbrowseSign.UseVisualStyleBackColor = true;
            this.btnbrowseSign.Click += new System.EventHandler(this.btnbrowseSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(43, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(42, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(5, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Retype Password. :";
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.Location = new System.Drawing.Point(129, 51);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(166, 22);
            this.txtname.TabIndex = 10;
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(129, 92);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(166, 22);
            this.txtpassword.TabIndex = 11;
            // 
            // txtrepass
            // 
            this.txtrepass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtrepass.Location = new System.Drawing.Point(129, 127);
            this.txtrepass.Name = "txtrepass";
            this.txtrepass.Size = new System.Drawing.Size(166, 22);
            this.txtrepass.TabIndex = 12;
            this.txtrepass.Leave += new System.EventHandler(this.textBox4_Leave);
            // 
            // pbPhoto
            // 
            this.pbPhoto.ImageLocation = "";
            this.pbPhoto.Location = new System.Drawing.Point(545, 5);
            this.pbPhoto.Name = "pbPhoto";
            this.pbPhoto.Size = new System.Drawing.Size(73, 98);
            this.pbPhoto.TabIndex = 16;
            this.pbPhoto.TabStop = false;
            // 
            // pbSign
            // 
            this.pbSign.ImageLocation = "";
            this.pbSign.Location = new System.Drawing.Point(523, 186);
            this.pbSign.Name = "pbSign";
            this.pbSign.Size = new System.Drawing.Size(95, 34);
            this.pbSign.TabIndex = 17;
            this.pbSign.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(104, 243);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.Location = new System.Drawing.Point(215, 243);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 19;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(61, 214);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(0, 13);
            this.lblerror.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(77, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Role :";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Admin",
            "Oprator"});
            this.comboBox1.Location = new System.Drawing.Point(129, 166);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(166, 26);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.Text = "---Select Role---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(124, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 29);
            this.label5.TabIndex = 23;
            this.label5.Text = "User Registration";
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(630, 278);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.pbSign);
            this.Controls.Add(this.pbPhoto);
            this.Controls.Add(this.txtrepass);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbrowseSign);
            this.Controls.Add(this.btnbrowsephoto);
            this.Name = "UserLogin";
            this.Text = "UserLogin";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnbrowsephoto;
        private System.Windows.Forms.Button btnbrowseSign;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtrepass;
        private System.Windows.Forms.PictureBox pbPhoto;
        private System.Windows.Forms.PictureBox pbSign;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lblerror;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
    }
}