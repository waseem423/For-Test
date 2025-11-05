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
    public partial class Edit_Permissions : Form
    {
        public Edit_Permissions()
        {
            InitializeComponent();
        }

        clsUsers _User;

        private void Edit_Permissions_Load(object sender, EventArgs e)
        {

        }


        private void btnCheck_Click_1(object sender, EventArgs e)
        {
            _User = clsUsers.Find(textBoxUserName.Text);

            if (_User != null)
            {
                lblPermissions.Text = _User.Permission.ToString();
                btnEditPermissions.Enabled = true;
            }
            else
            {
                MessageBox.Show("User With Username [" + textBoxUserName.Text + " ] Is Not Found.");
            }
        }

        private void btnEditPermissions_Click_1(object sender, EventArgs e)
        {
            User_s_Permissions User = new User_s_Permissions();
            User.ShowDialog();
            _User.Permission = GlobalVariable.Permissions;
            if (_User.Save())
            {
                MessageBox.Show("Edited Permissions Was Successfully.");
                lblPermissions.Text = GlobalVariable.Permissions.ToString();
            }
            else
            {
                MessageBox.Show("Edited Permissions Was Faild.");

            }
        }
    }
}
