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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        clsUsers _User;
     
        

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxCurrentPassword_TextChanged(object sender, EventArgs e)
        {
            if(textBoxCurrentPassword.Text==GlobalVariable._User.Password)
            {
                btnChange.Enabled = true;
            }
            else
            {
                btnChange.Enabled = false;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if(textBoxNewPassword.Text==textBoxConfirmPassword.Text)
            {
                _User = clsUsers.Find(GlobalVariable._User.Username);

                _User.Password = textBoxNewPassword.Text;
                

                if(_User.Save())
                {
                    MessageBox.Show("Change Password Successfully Your Current Password is " + textBoxNewPassword.Text, "Change Password");
                }
                else
                {
                    MessageBox.Show("Change Password Was Faild.","Change Password");
                }
            }
            else
            {
                MessageBox.Show("The new password and confirmation do not match.", "Cahnge Password");
            }
        }
    }
}
