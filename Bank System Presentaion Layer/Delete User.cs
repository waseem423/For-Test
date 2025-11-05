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
    public partial class Delete_User : Form
    {

        clsUsers _User;

        public Delete_User()
        {
            InitializeComponent();
        }


        private void FillUserInfoToForm()
        {
            lblUserName.Text = _User.Username;
            lblPassword.Text = _User.Password;
            lblFullName.Text = _User.FirstName.ToString() + " " + _User.LastName.ToString();
            lblPhone.Text = _User.Phone;
            btnDelete.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _User = clsUsers.Find(textBoxUserNameForDelete.Text);

            if(_User!=null)
            {
                FillUserInfoToForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(lblUserName.Text=="Admin".ToLower())
            {
                MessageBox.Show("You Can not delete The Admin.");

                return;

            }
            if(_User.DeleteUser())
            {
                MessageBox.Show("Deleted Was Successfully.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Deleted Faild.");

            }
        }
    }
}
