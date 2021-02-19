using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace SBGhadgev1
{
    public partial class Main : Form
    {
        private int childFormNumber = 0;
        public static DataSet user;
        public Main()
        {
            InitializeComponent();
        }
     public static   Bitmap ByteArrayToImage(byte[] b)
        {
            MemoryStream ms = new MemoryStream();
            byte[] pData = b;
            ms.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(ms, false);
            ms.Dispose();
            return bm;
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void measurementSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MeasurementSheet ms = new MeasurementSheet();
            ms.Show();
        }

        private void summaarySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SummarySheet ss = new SummarySheet();
            ss.Show();
        }

        private void Amount_Sheet_Click(object sender, EventArgs e)
        {
            AmountSheet ash = new AmountSheet();
            ash.Show();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bill b = new bill();
            b.Show();
        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            description d = new description();
            d.Show();
        }

        private void rCToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void summarySheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SBGhadge1.UserLogin ul = new SBGhadge1.UserLogin();
            ul.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //if (user.Tables[0].Rows[0][2].ToString() == "Oprator")
            //{  menuStrip.Items[2].Enabled = false;
            //   menuStrip.Items[3].Enabled = false;
            //    menuStrip.Items[4].Enabled = false;
            //    menuStrip.Items[6].Enabled = false;
            //}
            majordal.InitRC();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itemSummaryAnnualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RptItemSummary r = new RptItemSummary();
            r.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRC1 u = new UpdateRC1();
            u.Show();
        }

        private void rCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RCSHEET r = new RCSHEET();
            r.Show();
        }
    }
}
