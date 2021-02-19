using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class Amount : UserControl
    {
        public Amount()
        {
            InitializeComponent();
            for (int i = 0; i < 21; i++)
            {
                dataGridView1.Rows.Add();

            }
        }
        public string gridsum()
        {
            string final = "0";
            double sum = 0; ;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double t = 0;
                if (double.TryParse(Convert.ToString(dataGridView1.Rows[i].Cells[6].Value), out t))
                { t = Convert.ToDouble(Convert.ToString(dataGridView1.Rows[i].Cells[6].Value)); }
                sum += t;
            }
            final = Convert.ToString(sum);
            return final;

        }
        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                double t = 0;
                if (double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue), out t))
                { t = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue); }
                double t2 = 0;
                if (double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].Value),out t2))
                {t2=Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);}
                //Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = (decimal.Round(Convert.ToDecimal(t * t2),2)).ToString();
                lblpageTotal.Text = gridsum();
                if (Application.OpenForms["AmountSheet"] != null)
                {
                    ((AmountSheet)Application.OpenForms["AmountSheet"]).changetotalpage();
                }
            }
            if (e.ColumnIndex == 5)
            {
                double t = 0;
                if (double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value), out t))
                { t = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[3].Value); }
                double t2 = 0;
                if (double.TryParse(Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[5].EditedFormattedValue), out t2))
                { t2 = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].EditedFormattedValue); }
                //Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
                dataGridView1.Rows[e.RowIndex].Cells[6].Value = (decimal.Round(Convert.ToDecimal(t * t2), 2)).ToString();
                lblpageTotal.Text = gridsum();
                if (Application.OpenForms["AmountSheet"] != null)
                {
                    ((AmountSheet)Application.OpenForms["AmountSheet"]).changetotalpage();
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Amount_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
