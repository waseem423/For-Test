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
    public partial class User_s_Permissions : Form
    {

       

        public User_s_Permissions()
        {
            InitializeComponent();

            GlobalVariable.Permissions = 0;
        }

        

        private void _MakeAllCheckBoxDisable()
        {
            checkBoxAddClients.Enabled =    false;
            checkBoxUpdateClients.Enabled = false;
            checkBoxDeleteClients.Enabled = false;
            checkBoxManageUsers.Enabled =   false;
            checkBoxTransactions.Enabled =  false;
            
        }

        private void _MakeAllCheckBoxEnable()
        {
            checkBoxAddClients.Enabled =    true;
            checkBoxUpdateClients.Enabled = true;
            checkBoxDeleteClients.Enabled = true;
            checkBoxManageUsers.Enabled =   true;
            checkBoxTransactions.Enabled =  true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxAllPermissions.Checked)
            {
                GlobalVariable.Permissions = -1;
                this.Close();
                return;
            }

            if (checkBoxAddClients.Checked) GlobalVariable.Permissions += 1;

            if (checkBoxUpdateClients.Checked) GlobalVariable.Permissions += 2;

            if (checkBoxDeleteClients.Checked) GlobalVariable.Permissions += 4;

            if (checkBoxManageUsers.Checked) GlobalVariable.Permissions += 8;

            if (checkBoxTransactions.Checked) GlobalVariable.Permissions += 16;

            this.Close();
        }

        private void checkBoxAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
           if(checkBoxAllPermissions.Checked)
           {
                GlobalVariable.Permissions = -1;
                _MakeAllCheckBoxDisable();
           }
           else
           {
                _MakeAllCheckBoxEnable();
           }

            
        }
    }
}
