using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bank_System_Bussiness_Layer;

namespace Bank_System_Presentaion_Layer
{
    
    public partial class Login : Form
    {
        

        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(txtBoxUsername.Text)||string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                MessageBox.Show("Please Enter Username And Password.");
                return;
            }
            
           GlobalVariable._User = clsUsers.Find(txtBoxUsername.Text, txtBoxPassword.Text);

            if(GlobalVariable._User !=null)
            {
                this.Hide();

                clsLoginLog.AddNewLogin(GlobalVariable._User.ID, DateTime.Now);

                BankSystem bank = new BankSystem();
                bank.ShowDialog();
                
                this.Close();
            }
            else
            {
                MessageBox.Show($"User Name Or Password Is Uncorrect");

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnHidePassword_Click(object sender, EventArgs e)
        {
            if(btnHidePassword.Tag.ToString()=="0")
            {
                btnHidePassword.Tag = 1;
                txtBoxPassword.PasswordChar = '*';
                btnHidePassword.BackgroundImage = Properties.Resources.eye;
            }
            else
            {
                btnHidePassword.Tag = 0;
                txtBoxPassword.PasswordChar = default;
                btnHidePassword.BackgroundImage = Properties.Resources.visible;

            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
