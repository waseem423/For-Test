using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Data_Access_Layer
{
    public class clsLoginLogDataAccess
    {

        public static DataTable GetAllLoginsLog()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"Select Users.ID As LogUserID ,Users.UserName As LogUserName ,Users.Permissions,
                                LoginsLog.LoginDate From LoginsLog 
                                inner join Users ON Users.ID=LoginsLog.UserID;;";

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

        public static void AddNewLogin(int UserID,DateTime dateTime)
        {
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @" insert into LoginsLog (UserID,LoginDate) 
						                     Values  (@UserID,@dateTime);";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@dateTime", dateTime);

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
