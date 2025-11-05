using Bank_System_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System_Presentaion_Layer
{
    public partial class Tranfer : Form
    {
        public Tranfer()
        {
            InitializeComponent();
        }

        private void textBoxAccountNumber_TextChanged(object sender, EventArgs e)
        {
            lblAccountNumber.ForeColor = Color.Red;
            lblAccountNumber.Text = textBoxAccountNumber.Text;
            btnDone.Enabled = false;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            GlobalVariable._DestinationClient = clsClients.Find(textBoxAccountNumber.Text);

            if(GlobalVariable._DestinationClient!=null)
            {
                lblAccountNumber.ForeColor = Color.Green;
                btnDone.Enabled = true;
            }
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if(numericUpDownAmount.Value<=0)
            {
                return;
            }

            if(numericUpDownAmount.Value>GlobalVariable._SourceClient.AccountBalance)
            {
                numericUpDownAmount.Value = GlobalVariable._SourceClient.AccountBalance;
            }
            
            if(MessageBox.Show("Are You Sure You Want To Transfer "+numericUpDownAmount.Value+" To Account "+
                GlobalVariable._DestinationClient.AccountNumber+"?","Transfer",
                MessageBoxButtons.YesNoCancel)==DialogResult.Yes)
            {
                GlobalVariable._SourceClient.AccountBalance -= numericUpDownAmount.Value;
                GlobalVariable._DestinationClient.AccountBalance += numericUpDownAmount.Value;

                if(GlobalVariable._SourceClient.Save()
                    &&
                    GlobalVariable._DestinationClient.Save())
                {
                    clsTransactionLog.AddNewTransactionLog(
                        GlobalVariable._User.Username,
                        GlobalVariable._SourceClient.AccountNumber,
                        DateTime.Now,
                        "Transfer",
                        numericUpDownAmount.Value,
                        GlobalVariable._DestinationClient.AccountNumber);

                    lblWelcome.Text = "Welcome " + GlobalVariable._SourceClient.FirstName + " Your Balance Is : " + GlobalVariable._SourceClient.AccountBalance.ToString();


                    MessageBox.Show("Transfer Done Successfully.");
                    
                }
                else
                {
                    MessageBox.Show("Transfer Faild.");
                }
            }

        }

        private void Tranfer_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + GlobalVariable._SourceClient.FirstName + " Your Balance Is : " + GlobalVariable._SourceClient.AccountBalance.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblAccountNumber_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblWelcome_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
