namespace SBGhadgev1
{
    partial class description
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(description));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtmno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnlaod = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(902, 1080);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(894, 974);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(894, 1054);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnprint
            // 
            this.btnprint.BackgroundImage = global::SBGhadge1.Properties.Resources.Print;
            this.btnprint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnprint.Location = new System.Drawing.Point(360, 3);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(75, 36);
            this.btnprint.TabIndex = 1;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtmno
            // 
            this.txtmno.Location = new System.Drawing.Point(142, 6);
            this.txtmno.Name = "txtmno";
            this.txtmno.Size = new System.Drawing.Size(100, 20);
            this.txtmno.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(42, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Measurement No.:";
            // 
            // btnlaod
            // 
            this.btnlaod.BackgroundImage = global::SBGhadge1.Properties.Resources.Load;
            this.btnlaod.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnlaod.Location = new System.Drawing.Point(265, 3);
            this.btnlaod.Name = "btnlaod";
            this.btnlaod.Size = new System.Drawing.Size(71, 36);
            this.btnlaod.TabIndex = 4;
            this.btnlaod.Text = "Load";
            this.btnlaod.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlaod.UseVisualStyleBackColor = true;
            this.btnlaod.Click += new System.EventHandler(this.btnlaod_Click);
            // 
            // description
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(903, 698);
            this.Controls.Add(this.btnlaod);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtmno);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.tabControl1);
            this.Name = "description";
            this.Text = "description";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.description_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtmno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnlaod;

    }
}