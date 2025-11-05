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
    public partial class AddEidtUser : Form
    {

        clsUsers _User;
        int _UserID;

        enum enMode { AddNew,Update};

        enMode Mode;

        public AddEidtUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;

            if(_UserID==-1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }

        private void _MakeDisableUntilFindUser()
        {
            textBoxUsername.Enabled = false;
            textBoxPassword.Enabled = false;
            textBoxFName.Enabled = false;
            textBoxLName.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxAddress.Enabled = false;
            btnPermissions.Enabled = false;
            dateTimePicker1.Enabled = false;
            btnAddUser.Enabled = false;
        }

        private void _MakeEnableAfterFindUser()
        {
            textBoxUsername.Enabled = true;
            textBoxPassword.Enabled = true;
            textBoxFName.Enabled =    true;
            textBoxLName.Enabled =    true;
            textBoxEmail.Enabled =    true;
            textBoxPhone.Enabled =    true;
            textBoxAddress.Enabled =  true;
            btnPermissions.Enabled =  true;
            dateTimePicker1.Enabled = true;
            btnAddUser.Enabled =      true;
        }

        private void _LoadData()
        {
            if(Mode==enMode.AddNew)
            {
                _User = new clsUsers();

                lblMode.Text = "Add New User";
                btnAddUser.Text = "Add User";
                return;
            }

            lblMode.Text = "Update User";
            btnAddUser.Text = "Update";
            lblUserName.Visible = true;
            textBoxUsernameForSearch.Visible = true;
            buttonbtnSearch.Visible = true;
            _MakeDisableUntilFindUser();

        }

        private void textBoxUsername_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(textBoxUsername.Text))
            {
                errorProvider1.SetError(textBoxUsername, "Please Enter A UserName");
                e.Cancel = true;
                textBoxUsername.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxUsername, "");
                e.Cancel = false;
                
            }

            if(clsUsers.IsUsernameExist(textBoxUsername.Text))
            {
                errorProvider1.SetError(textBoxUsername, "Username Already Exist.");
                e.Cancel = true;
                textBoxUsername.Focus();
               
            }
            else
            {
                errorProvider1.SetError(textBoxUsername, "");
                e.Cancel = false;

            }

        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorProvider1.SetError(textBoxPassword, "Please Enter A Password");
                e.Cancel = true;
                textBoxPassword.Focus();
               
            }
            else
            {
                errorProvider1.SetError(textBoxPassword, "");
                e.Cancel = false;
                
               
            }
        }


        private void Save()
        {
            _User.Username = textBoxUsername.Text;
            _User.Password = textBoxPassword.Text;
            _User.FirstName = textBoxFName.Text;
            _User.LastName = textBoxLName.Text;
            _User.Email = textBoxEmail.Text;
            _User.Phone = textBoxPhone.Text;
            _User.Address = textBoxAddress.Text;
            _User.Permission = GlobalVariable.Permissions;
            _User.DateOfBirth = dateTimePicker1.Value;

           if(_User.Save())
           {
                if(Mode==enMode.AddNew)
                    MessageBox.Show("User Added Successfully.");
                else
                    MessageBox.Show("User Updated Successfully.");

            }
            else
           {
                if (Mode == enMode.AddNew)
                    MessageBox.Show("User Added Faild.");
                else
                    MessageBox.Show("User Updated Faild.");

            }

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(
                string.IsNullOrEmpty(textBoxUsername.Text)
                ||
                string.IsNullOrEmpty(textBoxPassword.Text)
              )
            {
                MessageBox.Show("Enter Username And Password.");
                return;
            }
            else
            {
                Save();
                this.Close();
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User_s_Permissions AddPermissions = new User_s_Permissions();

            AddPermissions.ShowDialog();
        }

        private void AddEidtUser_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void FillUserInfoToForm()
        {
            _MakeEnableAfterFindUser();

            textBoxUsername.Text = _User.Username;
            textBoxPassword.Text = _User.Password;
            textBoxFName.Text = _User.FirstName;
            textBoxLName.Text = _User.LastName;
            textBoxEmail.Text = _User.Email;
            textBoxPhone.Text = _User.Phone;
            textBoxAddress.Text = _User.Address;
            dateTimePicker1.Value = _User.DateOfBirth;
            GlobalVariable.Permissions = _User.Permission;
            textBoxUsername.Enabled = false;


        }

        private void buttonbtnSearch_Click(object sender, EventArgs e)
        {
            _User = clsUsers.Find(textBoxUsernameForSearch.Text);

            if(_User!=null)
            {
                FillUserInfoToForm();
            }
                
        }
    }
}
