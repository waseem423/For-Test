using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Bussiness_Layer
{
    public class clsTransactionLog
    {
        public static DataTable GetAllTransactionLog()
        {
            return clsTransactionLogDataAccess.GetAllTransactionLog();
        }

        public static void AddNewTransactionLog(string LogUserName, string AccountNumber, DateTime ProcessDate, string FinancialProcess, decimal FinancialAmount, string AccountTo)
        {
            clsTransactionLogDataAccess.AddNewTransactionLog(LogUserName, AccountNumber, ProcessDate, FinancialProcess, FinancialAmount, AccountTo);
        }
    }
}
