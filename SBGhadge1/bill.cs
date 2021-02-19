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
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
        }

        private void bill_Load(object sender, EventArgs e)
        {

        }
        public string RoundAmount(string s)
        {
            decimal d = Convert.ToDecimal(s);
            d = decimal.Round(d, 2);
            int i = s.IndexOf('.');
            if (i == -1)
            { s += ".00"; return s; }
            if (s.Length - i == 2)
            { s += "0"; return s; }
            if (s.Length - i > 3)
            { s = s.Substring(0, i + 3); }



            return d.ToString(); ;
        }
        private void txtbillno_Leave(object sender, EventArgs e)
        {
            try
            {
                string s = majordal.getmno(txtbillno.Text);
                if (s == "")
                {
                    MessageBox.Show("Bill No Not Found", "Sorry...!");
                }
                else
                {
                    lblmno.Text = s;
                    //txtbilldate.Text = majordal.getbillDate(txtbillno.Text);
                    string[] st ;
                    char[] ch5 = { ' ' };
                    st=DateTime.Now.Date.ToString().Split(ch5);
                      txtbilldate.Text =st[0];
                    lblTotal.Text = majordal.getbillTotal(txtbillno.Text);
                     rtxtSub.Text = "Plant-" + Convert.ToString(majordal.getPlantNo(txtbillno.Text).Tables[0].Rows[0][0]);
                    double tmp =  Convert.ToDouble(lblTotal.Text);
                    double disc = 0;
                    if (chkdisk.Checked == true)
                    {
                      disc=Convert.ToDouble(Decimal.Round(Convert.ToDecimal((3 * tmp / 100)), 2));
                    }
                        double taxable = tmp - disc;
                    double tmp1 = Convert.ToDouble( Decimal.Round(Convert.ToDecimal( (9 * taxable / 100)),2));
                    
                    
                    lbldisc.Text = disc.ToString();
                    lbltaxable.Text = taxable.ToString();

                    lblServTax.Text = tmp1.ToString();

                    double tmp2 = tmp1;
                    double kk = (0 * tmp) / 100;
                    if (chksba.Checked)
                    {
                        
                    }
                    else { tmp2 = 0; }
                    if (chk_kk.Checked)
                    {

                    }
                    else { kk = 0; }
                    lblSBACess.Text = tmp2.ToString(); ;
                    lblkk.Text = kk.ToString(); ;
                   // tmp = tmp + tmp2;
                    double tmp3 = (1 * tmp1) / 100;
                    lblSHcess.Text ="";
                    tmp =Convert.ToDouble( Decimal.Round(Convert.ToDecimal(taxable + tmp1+tmp2+kk),2));
                    tmp = Math.Round(tmp, 2);
                    lblAmount.Text = tmp.ToString();
                    int m = lblAmount.Text.IndexOf(".");
                    if (m != -1 && m + 3 < lblAmount.Text.Length)
                    { tmp = Convert.ToDouble(lblAmount.Text.Substring(0, m + 3)); }
                    amounInWord a = new amounInWord();
                    lblTotal.Text = RoundAmount(lblTotal.Text);
                    lbldisc.Text = RoundAmount(lbldisc.Text);
                    lbltaxable.Text = RoundAmount(lbltaxable.Text);

                    lblServTax.Text = RoundAmount(lblServTax.Text);
                    lblSBACess.Text = RoundAmount(lblSBACess.Text);
                    lblkk.Text = RoundAmount(lblkk.Text);
                   // lblSHcess.Text = RoundAmount(lblSHcess.Text);
                    lblAmount.Text = RoundAmount(lblAmount.Text);

                    lblamtwds.Text = a.Toword(Convert.ToDouble(lblAmount.Text));
                    txtcode.Text = Convert.ToString(majordal.getbill(txtbillno.Text).Tables[0].Rows[0][4]);
                    txtpo.Text = Convert.ToString(majordal.getbill(txtbillno.Text).Tables[0].Rows[0][5]);
                   
                }
            }
            catch (Exception ex)
            { }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Images.Printbill.billno = txtbillno.Text;
                Images.Printbill.billdate = txtbilldate.Text;
                Images.Printbill.total = amounInWord.mk_Currancy( lblTotal.Text);
                Images.Printbill.st = amounInWord.mk_Currancy( lblServTax.Text);
                Images.Printbill.edc =amounInWord.mk_Currancy(  lblSBACess.Text);
                Images.Printbill.hedc =amounInWord.mk_Currancy(  lblSHcess.Text);
                Images.Printbill.net =amounInWord.mk_Currancy(  lblAmount.Text);
                Images.Printbill.to = rtxtTo.Text;
                Images.Printbill.sac = txtsac.Text;
                Images.Printbill.kindatt = txtKindAttn.Text;
                Images.Printbill.subject = rtxtSub.Text;
                Images.Printbill.refno = txtrefno.Text;
                Images.Printbill.cst = txtstno.Text;
                Images.Printbill.Pan = txtpan.Text;
                Images.Printbill.kk = lblkk.Text;
                Images.Printbill.code = txtcode.Text;
                Images.Printbill.po = txtpo.Text;
                Images.Printbill.disc = lbldisc.Text;
                Images.Printbill.taxable = lbltaxable.Text;

                Images.Printbill b = new Images.Printbill();
                b.Show();
            }
            catch (Exception ex)
            { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string s = majordal.getbillno(txtbillno.Text);
                if (s != "0")
                { MessageBox.Show("Bill Record Already Saved"); }
                else
                {
                    majordal.insertbil(txtbillno.Text, txtbilldate.Text, lblAmount.Text, lblmno.Text,txtcode.Text,txtpo.Text);
                    MessageBox.Show("Bill  Saved");
                }
            }
            catch (Exception ex)
            { }
        }

        private void rtxtSub_TextChanged(object sender, EventArgs e)
        {

        }

        private void chksba_CheckedChanged(object sender, EventArgs e)
        {
            txtbillno_Leave(sender, e);
        }

        private void lblSHcess_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void txtrefno_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void chk_kk_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void lblamtwds_Click(object sender, EventArgs e)
        {

        }

        private void lblAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblSBACess_Click(object sender, EventArgs e)
        {

        }

        private void lblServTax_Click(object sender, EventArgs e)
        {

        }

        private void lblkk_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void chkdisk_CheckedChanged(object sender, EventArgs e)
        {
            txtbillno_Leave(sender, e);
        }
    }
}
