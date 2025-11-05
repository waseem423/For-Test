using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Data_Access_Layer
{
    public class clsTransactionLogDataAccess
    {
        public static DataTable GetAllTransactionLog()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select * From TransactionLog;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Dt.Load(reader);
                }
                reader.Close();


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
            return Dt;
        }

        public static void AddNewTransactionLog(string LogUserName,string AccountNumber,DateTime ProcessDate,string FinancialProcess,decimal FinancialAmount,string AccountTo)
        {
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"insert Into TransactionLog (LogUserName,AccountNumber,ProcessDate,
                            FinancialProcess,FinancialAmount,AccountTo)
                            Values (@LogUserName,@AccountNumber,@ProcessDate,@FinancialProcess,@FinancialAmount,@AccountTo);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LogUserName", LogUserName);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@ProcessDate", ProcessDate);
            command.Parameters.AddWithValue("@FinancialProcess", FinancialProcess);
            command.Parameters.AddWithValue("@FinancialAmount", FinancialAmount);
            command.Parameters.AddWithValue("@AccountTo", AccountTo);





            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }
        }
    }
}
