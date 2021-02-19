using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SBGhadgev1
{
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            if (checkBox1.Checked)
            { ds = SBGhadgev1.majordal.getmeasurebydate(Convert.ToDateTime(dateTimePicker1.Text).Year.ToString(), Convert.ToDateTime(dateTimePicker1.Text).Month.ToString()); }
            else { ds = SBGhadgev1.majordal.getmeasurebydate(); }
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            UpdateMeasure u = new UpdateMeasure();
            u.txtmno.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            u.Show();
        }
    }
}
