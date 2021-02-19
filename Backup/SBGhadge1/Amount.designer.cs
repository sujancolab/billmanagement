namespace SBGhadgev1
{
    partial class Amount
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblpageTotal = new System.Windows.Forms.Label();
            this.txtpono = new System.Windows.Forms.TextBox();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.txtBillno = new System.Windows.Forms.TextBox();
            this.txtPageno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unitrate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemarkAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblpageTotal);
            this.panel1.Controls.Add(this.txtpono);
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Controls.Add(this.txtBillno);
            this.panel1.Controls.Add(this.txtPageno);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1057, 129);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblpageTotal
            // 
            this.lblpageTotal.AutoSize = true;
            this.lblpageTotal.Location = new System.Drawing.Point(791, 100);
            this.lblpageTotal.Name = "lblpageTotal";
            this.lblpageTotal.Size = new System.Drawing.Size(28, 13);
            this.lblpageTotal.TabIndex = 13;
            this.lblpageTotal.Text = "0.00";
            // 
            // txtpono
            // 
            this.txtpono.Location = new System.Drawing.Point(629, 93);
            this.txtpono.Name = "txtpono";
            this.txtpono.Size = new System.Drawing.Size(100, 20);
            this.txtpono.TabIndex = 12;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(629, 65);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(100, 20);
            this.txtdate.TabIndex = 11;
            // 
            // txtBillno
            // 
            this.txtBillno.Location = new System.Drawing.Point(629, 35);
            this.txtBillno.Name = "txtBillno";
            this.txtBillno.Size = new System.Drawing.Size(100, 20);
            this.txtBillno.TabIndex = 10;
            // 
            // txtPageno
            // 
            this.txtPageno.Location = new System.Drawing.Point(629, 4);
            this.txtPageno.Name = "txtPageno";
            this.txtPageno.Size = new System.Drawing.Size(100, 20);
            this.txtPageno.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(461, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "P.O No";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 7;
            this.label6.Text = "Bill date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bill No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(461, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Page No";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(27, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(301, 100);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "M/s. Sun Pharmaceutical Industries Ltd. \nPlot No:-A-7/8,M.I.D.C Nagapur, \nAhmedna" +
                "gar-414111";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.itemcode,
            this.Description,
            this.Qty,
            this.Unit,
            this.Unitrate,
            this.amount1,
            this.RemarkAmount});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Tan;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 156);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1060, 684);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellLeave);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // srno
            // 
            this.srno.HeaderText = "Sr No";
            this.srno.Name = "srno";
            // 
            // itemcode
            // 
            this.itemcode.HeaderText = "Item Code";
            this.itemcode.Name = "itemcode";
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Width = 300;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // Unitrate
            // 
            this.Unitrate.HeaderText = "Unit Rate";
            this.Unitrate.Name = "Unitrate";
            // 
            // amount1
            // 
            this.amount1.HeaderText = "Amount";
            this.amount1.Name = "amount1";
            // 
            // RemarkAmount
            // 
            this.RemarkAmount.HeaderText = "RemarkAmount";
            this.RemarkAmount.Name = "RemarkAmount";
            // 
            // Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Amount";
            this.Size = new System.Drawing.Size(940, 700);
            this.Load += new System.EventHandler(this.Amount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtpono;
        public System.Windows.Forms.TextBox txtdate;
        public System.Windows.Forms.TextBox txtBillno;
        public System.Windows.Forms.TextBox txtPageno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.Label lblpageTotal;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unitrate;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount1;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemarkAmount;
    }
}
