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
    public partial class TransactionsLog : Form
    {
        public TransactionsLog()
        {
            InitializeComponent();
        }

        private void TransactionsLog_Load(object sender, EventArgs e)
        {
            DGVTransactionsLog.GridColor = Color.Green;//Yellow
            DGVTransactionsLog.DefaultCellStyle.BackColor = Color.LightYellow;
            DGVTransactionsLog.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

            DGVTransactionsLog.DataSource = clsTransactionLog.GetAllTransactionLog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
