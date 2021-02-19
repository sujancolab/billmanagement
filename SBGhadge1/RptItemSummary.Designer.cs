namespace SBGhadgev1
{
    partial class RptItemSummary
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
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp1
            // 
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Location = new System.Drawing.Point(140, 15);
            this.dtp1.Name = "dtp1";
            this.dtp1.Size = new System.Drawing.Size(96, 20);
            this.dtp1.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(83, 19);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(262, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "To";
            // 
            // dtp2
            // 
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp2.Location = new System.Drawing.Point(319, 18);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(96, 20);
            this.dtp2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 56);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(376, 116);
            this.textBox1.TabIndex = 4;
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(488, 19);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(54, 35);
            this.btnload.TabIndex = 5;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 189);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(670, 238);
            this.dataGridView1.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(564, 19);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(63, 35);
            this.btnExport.TabIndex = 7;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // RptItemSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 439);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.dtp1);
            this.Name = "RptItemSummary";
            this.Text = "RptItemSummary";
            this.Load += new System.EventHandler(this.RptItemSummary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnExport;
    }
}