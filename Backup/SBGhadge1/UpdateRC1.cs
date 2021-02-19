using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
namespace SBGhadgev1
{
    public partial class UpdateRC1 : Form
    {
        public UpdateRC1()
        {
            InitializeComponent();
        }

        private void UpdateRC1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = majordal.GetRC().Tables[0];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            majordal.SaveRC(dataGridView1);
            MessageBox.Show("Record Saved");
        }
    }
}
