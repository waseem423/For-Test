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
    public partial class Delete_Client : Form
    {
        public Delete_Client()
        {
            InitializeComponent();
        }

        clsClients _Client;

        private void _FillClientInfoToForm()
        {
            btnDelete.Enabled = true;

            lblAccountNumber.Text = _Client.AccountNumber;
            lblFullName.Text = _Client.FirstName + " " + _Client.LastName;
            lblPhone.Text = _Client.Phone;
            lblAccountBalance.Text = _Client.AccountBalance.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Client = clsClients.Find(textBoxAccountNumber.Text);

            if(_Client!=null)
            {
                _FillClientInfoToForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(_Client.DeleteClient())
            {
                MessageBox.Show("Client Deleted Was Successfully.");
            }
            else
            {
                MessageBox.Show("Client Deleted Was Faild.");
            }
        }
    }
}
