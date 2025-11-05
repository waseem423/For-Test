using Bank_System_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System_Presentaion_Layer
{
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome " + GlobalVariable._SourceClient.FirstName + "Your Balance Is : " + GlobalVariable._SourceClient.AccountBalance.ToString();

        }

        private void btnDone_Click(object sender, EventArgs e)
        {
          

            if(numericUpDownAmount.Value>GlobalVariable._SourceClient.AccountBalance)
            {
                numericUpDownAmount.Value = GlobalVariable._SourceClient.AccountBalance;
            }
            if (numericUpDownAmount.Value <= 0)
            {
                return;
            }

            if (MessageBox.Show("Are You Sure You Want To Withdraw "+numericUpDownAmount.Value+" From Account"+GlobalVariable._SourceClient.AccountNumber+"?",
                "Withdraw",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                GlobalVariable._SourceClient.AccountBalance -= numericUpDownAmount.Value;

                if(GlobalVariable._SourceClient.Save())
                {
                    clsTransactionLog.AddNewTransactionLog(
                        GlobalVariable._User.Username,
                        GlobalVariable._SourceClient.AccountNumber,
                        DateTime.Now,
                        "Withdraw",
                        numericUpDownAmount.Value,
                        ""
                        );

                    MessageBox.Show("Withdraw Done Successfully.");
                    lblWelcome.Text = "Welcome " + GlobalVariable._SourceClient.FirstName + "Your Balance Is : " + GlobalVariable._SourceClient.AccountBalance.ToString();

                }
                else
                {
                    MessageBox.Show("Withdraw Faild.");

                }
            }
        }
    }
}
