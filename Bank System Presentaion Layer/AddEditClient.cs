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
    public partial class AddEditClient : Form
    {
        clsClients _Client;
        enum enMode { AddNew,Update};

        int _ClientID;
        enMode Mode;

        public AddEditClient(int ClientID)
        {
            InitializeComponent();

            _ClientID = ClientID;
        
            if(_ClientID==-1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }
        }


        private void _MakeControlDisable()
        {
            textBoxAccountNumber.Enabled = false;
            textBoxPinCode.Enabled = false;
            textBoxFirstName.Enabled = false;
            textBoxLastName.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxPhone.Enabled = false;
            textBoxAddress.Enabled = false;
            numericUpDownAccountBalance.Enabled = false;
            btnAddEditClient.Enabled = false;
            dateTimePickerDateOfBirth.Enabled = false;
        }

        private void LoadData()
        {
            if(Mode==enMode.AddNew)
            {
                _Client = new clsClients();

                lblMode.Text = "Add New Client";
                lblAccountNumber.Visible = false;
                textBoxAccountNumberForUpdate.Visible = false;
                btnSearch.Visible = false;
                return;

            }
            else
            {


                lblMode.Text = "Update Client";
                lblAccountNumber.Visible = true;
                textBoxAccountNumberForUpdate.Visible = true;
                btnSearch.Visible = true;
                btnAddEditClient.Text = "Update";

                _MakeControlDisable();
            }
        }

        private void textBoxAccountNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxAccountNumber.Text))
            {
                errorProvider1.SetError(textBoxAccountNumber, "Please Enter An Account Number");
                e.Cancel = true;
                textBoxAccountNumber.Focus();
            }
            else
            {
                errorProvider1.SetError(textBoxAccountNumber, "");
                e.Cancel = false;

            }

            if (clsClients.IsAccountNumberExist(textBoxAccountNumber.Text))
            {
                errorProvider1.SetError(textBoxAccountNumber, "Account Number Already Exist.");
                e.Cancel = true;
                textBoxAccountNumber.Focus();

            }
            else
            {
                errorProvider1.SetError(textBoxAccountNumber, "");
                e.Cancel = false;

            }
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPinCode.Text))
            {
                errorProvider1.SetError(textBoxPinCode, "Please Enter A Password");
                e.Cancel = true;
                textBoxPinCode.Focus();

            }
            else
            {
                errorProvider1.SetError(textBoxPinCode, "");
                e.Cancel = false;

            }
        }

        private void Save()
        {
            _Client.AccountNumber = textBoxAccountNumber.Text;
            _Client.PinCode = textBoxPinCode.Text;
            _Client.FirstName = textBoxFirstName.Text;
            _Client.LastName = textBoxLastName.Text;
            _Client.Phone = textBoxPhone.Text;
            _Client.Email = textBoxEmail.Text;
            _Client.Address = textBoxAddress.Text;
            _Client.AccountBalance = (decimal)numericUpDownAccountBalance.Value;
            _Client.DateOfBirth = dateTimePickerDateOfBirth.Value;

            if(_Client.Save())
            {
                if (Mode == enMode.AddNew)
                {
                    MessageBox.Show("Client Added Successfully.");
                }
                else
                {
                    MessageBox.Show("Client Updated Successfully.");

                }
            }
            else
            {

                if(Mode==enMode.AddNew)
                {
                    MessageBox.Show("Cleint Added Faild.");

                }
                else
                {
                    MessageBox.Show("Cleint Updated Faild.");

                }
            }

        }

        private void btnAddEditClient_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }

        private void AddEditClient_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void _MakeControlsEnable()
        {
            textBoxAccountNumber.Enabled =       true;
            textBoxPinCode.Enabled =             true;
            textBoxFirstName.Enabled =           true;
            textBoxLastName.Enabled =            true;
            textBoxEmail.Enabled =               true;
            textBoxPhone.Enabled =               true;
            textBoxAddress.Enabled =             true;
            numericUpDownAccountBalance.Enabled =true;
            btnAddEditClient.Enabled =           true;
            dateTimePickerDateOfBirth.Enabled = true;
        }

        private void FillClientInfoToForm()
        {
            _MakeControlsEnable();
            textBoxAccountNumber.Text = _Client.AccountNumber;
            textBoxPinCode.Text = _Client.PinCode;
            textBoxFirstName.Text = _Client.FirstName;
            textBoxLastName.Text = _Client.LastName;
            textBoxEmail.Text = _Client.Email;
            textBoxPhone.Text = _Client.Phone;
            textBoxAddress.Text = _Client.Address;
            numericUpDownAccountBalance.Value =(decimal) _Client.AccountBalance;
            dateTimePickerDateOfBirth.Value = _Client.DateOfBirth;
            textBoxAccountNumber.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _Client = clsClients.Find(textBoxAccountNumberForUpdate.Text);

            if(_Client!=null)
            {
                FillClientInfoToForm();
            }
            else
            {
                MessageBox.Show("Cleint With [" + textBoxAccountNumberForUpdate.Text + "] Is Not Found.");
            }
        }
    }
}
