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
    public partial class BankSystem : Form
    {
        public BankSystem()
        {
            InitializeComponent();

        }

        private void _Load()
        {
            lblRegisteredUsers.Text = clsUsers.GetRegisteredUsers().ToString();
            lblWelcome.Text = "Welcome Mr " + GlobalVariable._User.FirstName + " To Our Bank System";
            lblActiveClients.Text = clsClients.GetActiveCleints().ToString();
            lblTotalAccountBalance.Text = clsClients.GetTotalAccountBalance().ToString();
        }

        private void BankSystem_Load(object sender, EventArgs e)
        {
            _Load();
            LoadClientsInfoToDGV();
            _LoadAccountsToDGV();
            FillCountryFromInComboBox();
            FillCountryToInComboBox();
            _RefreshLoginsLog();
            _RefreshTransactionLog();
        }

        private void _RefreshLoginsLog()
        {
            DGVLoginsLog.GridColor = Color.Yellow;//Yellow
            DGVLoginsLog.DefaultCellStyle.BackColor = Color.LightBlue;
            DGVLoginsLog.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            DGVLoginsLog.DataSource = clsLoginLog.GetAllAllLoginsLog();
        }

        private void _RefreshTransactionLog()
        {
            DGVTransactionLog.GridColor = Color.Green;//Yellow
            DGVTransactionLog.DefaultCellStyle.BackColor = Color.LightYellow;
            DGVTransactionLog.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            DGVTransactionLog.DataSource = clsTransactionLog.GetAllTransactionLog();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Username" || textBox1.Text == "Enter Account Number")
            {
                textBox1.Clear();
            }
        }

        private void ColorForUsers()
        {
            DGVUsers_Clients.GridColor = Color.Yellow;//Yellow
            DGVUsers_Clients.DefaultCellStyle.BackColor = Color.LightBlue;
            DGVUsers_Clients.AlternatingRowsDefaultCellStyle.BackColor = Color.White;   
        }


        private void ColorForClients()
        {
            DGVUsers_Clients.GridColor = Color.Green;//Yellow
            DGVUsers_Clients.DefaultCellStyle.BackColor = Color.LightYellow;
            DGVUsers_Clients.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void LoadUsersInfoToDGV()
        {
            if(!GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
            {
                return;
            }

            ColorForUsers();
            DGVUsers_Clients.DataSource = clsUsers.GetAllUsers();
        }

        private void _RefereshAllUsersData()
        {
            LoadUsersInfoToDGV();
        }

        private void _RefershAllClientsData()
        {
            LoadClientsInfoToDGV();
        }

        private void LoadClientsInfoToDGV()
        {
            ColorForClients();
            DGVUsers_Clients.DataSource = clsClients.GetAllClients();
        }

        private void EmptyDGVUsers_Clients()
        {
            DGVUsers_Clients.DataSource = null;
            DGVUsers_Clients.Rows.Clear();
            DGVUsers_Clients.Columns.Clear();
        }

        private void rbManageUsers_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "Enter Username";
            EmptyDGVUsers_Clients();
            LoadUsersInfoToDGV();
        }

        private void rbManageClients_CheckedChanged(object sender, EventArgs e)
        {

            textBox1.Text = "Enter Account Number";
            EmptyDGVUsers_Clients();
            LoadClientsInfoToDGV();
        }

        private void AddNewUser()
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
            {
                AddEidtUser newUser = new AddEidtUser(-1);
                newUser.ShowDialog();
                _RefereshAllUsersData();
                

            }
            else
            {
                MessageBox.Show("You Do not have Permissions.");

            }
        }

        private void UpdateUser()
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
            {
                AddEidtUser updateUser = new AddEidtUser(0);
                updateUser.ShowDialog();
                _RefereshAllUsersData();
            }
            else
            {
                MessageBox.Show("You Do not have Permissions.");

            }
        }
        private void UpdateClient()
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.UpdateClient))
            {
                AddEditClient Update = new AddEditClient(0);
                Update.ShowDialog();
                _RefershAllClientsData();
                _RefereshAccounts();
            }
            else
            {
                MessageBox.Show("You Do not have Permissions.");

            }
        }

        private void AddNewClient()
        {
            if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.AddClients))
            {
                AddEditClient Client = new AddEditClient(-1);
                Client.ShowDialog();
                _RefershAllClientsData();
                _RefereshAccounts();

            }
            else
            {
                MessageBox.Show("You Do not have Permissions.");

            }
        }

        private void DeleteUser()
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
            {
                Delete_User User = new Delete_User();
                User.ShowDialog();
                _RefereshAllUsersData();
            }
            else
            {
                MessageBox.Show("You do not have permissions.");
            }
        }

        private void DeleteClient()
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.DeleteClient))
            {
                Delete_Client Client = new Delete_Client();
                Client.ShowDialog();
                _RefershAllClientsData();
                _RefereshAccounts();
            }
            else
            {
                MessageBox.Show("You do not have permissions.");
            }
        }

        private void AddNew()
        {
            if(rbManageUsers.Checked)
            {
                AddNewUser();

            }
            else
            {
                AddNewClient();
            }
        }

        private void Update()
        {
            if(rbManageUsers.Checked)
            {
                UpdateUser();
            }
            else
            {
                UpdateClient();
            }

        }

        private void Delete()
        {
            if(rbManageUsers.Checked)
            {
                DeleteUser();
            }
            else
            {
                DeleteClient();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNew();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewUser();
        }

        private void clientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewClient();
        }

        private void userToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateUser();
        }

        private void clientToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateClient();
        }

        private void userToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteUser();
        }

        private void clientToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }

        private void editPermissionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
            {
                MessageBox.Show("You Do Not Have Permissions.");
                return;
            }
            Edit_Permissions permissions = new Edit_Permissions();
            permissions.ShowDialog();
            _RefereshAllUsersData();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (rbManageUsers.Checked)
            {
                if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.ManageUsers))
                {
                    DGVUsers_Clients.DataSource = clsUsers.GetAllUsersWithSearch(textBox1.Text);
                }
            }
            else
            {
                DGVUsers_Clients.DataSource = clsClients.GetAllClientsWithSearch(textBox1.Text);
            }
        }

        private void ColorForAccounts()
        {
            DGVAccounts.GridColor = Color.Black;//Yellow
            DGVAccounts.DefaultCellStyle.BackColor = Color.FromArgb(192, 192, 255);
            DGVAccounts.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void _LoadAccountsToDGV()
        {
            DGVAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ColorForAccounts();
            DGVAccounts.DataSource = clsClients.GetAllAccounts();
        }

        private void _RefereshAccounts()
        {
            _LoadAccountsToDGV();
        }

        private void textBoxAccountNumber_Click(object sender, EventArgs e)
        {
            if(textBoxAccountNumber.Text=="Enter Account Number")
            {
                textBoxAccountNumber.Clear();
            }
        }

        private void _MakeControlsEnable()
        {
            btnTransfer.Enabled = true;
            btnDeposit.Enabled = true;
            btnWithdraw.Enabled = true;
            btn50.Enabled = true;
            btn100.Enabled = true;
            btn300.Enabled = true;
            btn500.Enabled = true;
        }

        private void _MakeContorlsDisableDefault()
        {
            btnTransfer.Enabled = false;
            btnDeposit.Enabled =  false;
            btnWithdraw.Enabled = false;
            btn50.Enabled =       false;
            btn100.Enabled =      false;
            btn300.Enabled =      false;
            btn500.Enabled =      false;
            
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            GlobalVariable._SourceClient = clsClients.Find(textBoxAccountNumber.Text);

            if(GlobalVariable._SourceClient!=null)
            {
                _MakeControlsEnable();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                Tranfer T = new Tranfer();
                T.ShowDialog();
                _RefereshAccounts();
                _RefershAllClientsData();
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }

        }

        private void textBoxAccountNumber_TextChanged(object sender, EventArgs e)
        {
            DGVAccounts.DataSource = clsClients.GetAllAccountsWithSearch(textBoxAccountNumber.Text);
            _MakeContorlsDisableDefault();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                Deposit D = new Deposit();
                D.ShowDialog();
                _RefereshAccounts();
                _RefershAllClientsData();
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                Withdraw W = new Withdraw();
                W.ShowDialog();
                _RefereshAccounts();
                _RefershAllClientsData();
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }

        }

        private void btn50_Click(object sender, EventArgs e)
        {
            if(GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                decimal Amount = 50;

                if (Amount > GlobalVariable._SourceClient.AccountBalance)
                {
                    MessageBox.Show("AccountBalance For Account " + GlobalVariable._SourceClient.AccountBalance + " Less Than " + Amount + " .");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are You Sure You Want To Withdraw " + Amount + " From Account" + GlobalVariable._SourceClient.AccountNumber + "?",
                        "Deposit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        GlobalVariable._SourceClient.AccountBalance -= Amount;

                        if (GlobalVariable._SourceClient.Save())
                        {
                            clsTransactionLog.AddNewTransactionLog(
                        GlobalVariable._User.Username,
                        GlobalVariable._SourceClient.AccountNumber,
                        DateTime.Now,
                        "Withdraw",
                        Amount,
                        ""
                        );

                            MessageBox.Show("Withdraw Done Successfully.");
                            _RefereshAccounts();
                            _RefershAllClientsData();
                        }
                        else
                        {
                            MessageBox.Show("Withdraw Faild.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                decimal Amount = 100;

                if (Amount > GlobalVariable._SourceClient.AccountBalance)
                {
                    MessageBox.Show("AccountBalance For Account " + GlobalVariable._SourceClient.AccountBalance + " Less Than " + Amount + " .");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are You Sure You Want To Withdraw " + Amount + " From Account" + GlobalVariable._SourceClient.AccountNumber + "?",
                        "Deposit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        GlobalVariable._SourceClient.AccountBalance -= Amount;

                        if (GlobalVariable._SourceClient.Save())
                        {
                            clsTransactionLog.AddNewTransactionLog(
                    GlobalVariable._User.Username,
                    GlobalVariable._SourceClient.AccountNumber,
                    DateTime.Now,
                    "Withdraw",
                    Amount,
                    ""
                    );

                            MessageBox.Show("Withdraw Done Successfully.");
                            _RefereshAccounts();
                            _RefershAllClientsData();
                        }
                        else
                        {
                            MessageBox.Show("Withdraw Faild.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }
        }

        private void btn300_Click(object sender, EventArgs e)
        {
            if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                decimal Amount = 300;

                if (Amount > GlobalVariable._SourceClient.AccountBalance)
                {
                    MessageBox.Show("AccountBalance For Account " + GlobalVariable._SourceClient.AccountBalance + " Less Than " + Amount + " .");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are You Sure You Want To Withdraw " + Amount + " From Account" + GlobalVariable._SourceClient.AccountNumber + "?",
                        "Deposit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        GlobalVariable._SourceClient.AccountBalance -= Amount;

                        if (GlobalVariable._SourceClient.Save())
                        {
                            clsTransactionLog.AddNewTransactionLog(
                    GlobalVariable._User.Username,
                    GlobalVariable._SourceClient.AccountNumber,
                    DateTime.Now,
                    "Withdraw",
                    Amount,
                    ""
                    );
                            MessageBox.Show("Withdraw Done Successfully.");
                            _RefereshAccounts();
                            _RefershAllClientsData();
                        }
                        else
                        {
                            MessageBox.Show("Withdraw Faild.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            if (GlobalVariable._User.CheckAccessPermissions(clsUsers.enPermissions.Transactions))
            {
                decimal Amount = 500;

                if (Amount > GlobalVariable._SourceClient.AccountBalance)
                {
                    MessageBox.Show("AccountBalance For Account " + GlobalVariable._SourceClient.AccountBalance + " Less Than " + Amount + " .");
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are You Sure You Want To Withdraw " + Amount + " From Account" + GlobalVariable._SourceClient.AccountNumber + "?",
                        "Deposit", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        GlobalVariable._SourceClient.AccountBalance -= Amount;

                        if (GlobalVariable._SourceClient.Save())
                        {
                            clsTransactionLog.AddNewTransactionLog(
                    GlobalVariable._User.Username,
                    GlobalVariable._SourceClient.AccountNumber,
                    DateTime.Now,
                    "Withdraw",
                    Amount,
                    ""
                    );
                            MessageBox.Show("Withdraw Done Successfully.");
                            _RefereshAccounts();
                            _RefershAllClientsData();
                        }
                        else
                        {
                            MessageBox.Show("Withdraw Faild.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You Do Not Have Permissions.");
            }
        }

        private void FillCountryFromInComboBox()
        {
            foreach (DataRow row in GlobalVariable.DTCountries.Rows)
            {
                comboBoxFromCountry.Items.Add(row["CountryName"]);
            }
        }

        private void  FillCountryToInComboBox()
        {
            foreach (DataRow row in GlobalVariable.DTCountries.Rows)
            {
                comboBoxToCurrency.Items.Add(row["CountryName"]);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDownAmountToConvert.Value = 0;
            comboBoxFromCountry.SelectedIndex = -1;
            comboBoxFromCountry.Text = "";
            comboBoxToCurrency.SelectedIndex = -1;
            comboBoxToCurrency.Text = "";

            lblFromCurrency.Text = "";
            lblToCurrency.Text = "";
            
        }

        private void comboBoxFromCountry_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxFromCountry.Text != "")
                GlobalVariable._CurrencyFrom = clsCurrency.Find(comboBoxFromCountry.SelectedItem.ToString());
            else
                return;
        }

        private void comboBoxToCountry_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxToCurrency.Text != "")
                GlobalVariable._CurrencyTo = clsCurrency.Find(comboBoxToCurrency.SelectedItem.ToString());
            else
                return;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBoxFromCountry.SelectedItem != null && comboBoxToCurrency.SelectedItem != null)
            {

                object temp = comboBoxFromCountry.SelectedItem;

                comboBoxFromCountry.SelectedItem = comboBoxToCurrency.SelectedItem;

                comboBoxToCurrency.SelectedItem = temp;


            }
            else
            {
                MessageBox.Show("Choose Countries .");
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if(numericUpDownAmountToConvert.Value==0)
            {
                return;
            }

            if(comboBoxFromCountry.SelectedItem==null
                ||
                comboBoxToCurrency.SelectedItem==null)
            {
                return;
            }

            decimal ValueInDollar = 0;

            ValueInDollar = numericUpDownAmountToConvert.Value / GlobalVariable._CurrencyFrom.Rate;

            decimal Result = ValueInDollar * GlobalVariable._CurrencyTo.Rate;
          

            lblFromCurrency.Text = numericUpDownAmountToConvert.Value.ToString() + " " + GlobalVariable._CurrencyFrom.Code;
            lblToCurrency.Text = Result.ToString() +" " + GlobalVariable._CurrencyTo.Code;
           

        }

        private void numericUpDownAmountToConvert_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRefreshLogin_Click(object sender, EventArgs e)
        {
           
            _RefreshLoginsLog();
        }

        private void btnRefreshTransaction_Click(object sender, EventArgs e)
        {
            _RefreshTransactionLog();
        }

        private void Exite()
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Exite();
        }

        private void LogOut()
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            LogOut();  
        }

        private void overallFinancilReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransactionsLog Transaction = new TransactionsLog();

            Transaction.ShowDialog();
        }

        private void deleteAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteClient();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }

        private void exiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exite();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword Password = new ChangePassword();
            Password.ShowDialog();
        }

        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }


}
