using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Data_Access_Layer
{
    public class clsClientsDataAccess
    {

        public static int GetActiveClients()
        {

            int NumberOfClients = 0;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "select Count(*) From Clients_Accounts;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    NumberOfClients = (int)result;
                }

            }
            catch
            {
                
            }
            finally
            {
                connection.Close();

            }

            return NumberOfClients;
        }

        public static decimal GetTotalBalanceInSystem()
        {
            decimal TotalBalance=0;
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "select Sum(Clients_Accounts.AccountBalance) From Clients_Accounts;";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();
               
                if (result != null)
                {
                    TotalBalance = (decimal)result;
                }
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return TotalBalance;
        }

        public static DataTable GetAllClients()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Clients_Accounts.ID,Clients_Accounts.AccountNumber,Clients_Accounts.PinCode,
							Persons.FirstName,Persons.lastName,Persons.DateOfBirth
							,Persons.Address,Persons.Email,Persons.Phone,
                            Clients_Accounts.AccountBalance
                            From Clients_Accounts
                            inner join Persons On Persons.ID=Clients_Accounts.PersonID
							";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
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

        public static DataTable GetAllAccounts()
        {
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"Select Clients_Accounts.AccountNumber,
                            Persons.FirstName,Clients_Accounts.AccountBalance
                            from Clients_Accounts 
                            inner join Persons On Persons.ID = Clients_Accounts.PersonID;";

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

        public static DataTable GetAllClientsWithSearch(string AccountNumber)
        {

            AccountNumber += "%";
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Clients_Accounts.ID,Clients_Accounts.AccountNumber,Clients_Accounts.PinCode,
							Persons.FirstName,Persons.lastName,Persons.DateOfBirth
							,Persons.Address,Persons.Email,Persons.Phone,
                            Clients_Accounts.AccountBalance
                            From Clients_Accounts
                            inner join Persons On Persons.ID=Clients_Accounts.PersonID
                            Where AccountNumber Like @AccountNumber;
							";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

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

        public static DataTable GetAllAccountsWithSearch(string AccountNumber)
        {

            AccountNumber += "%";
            DataTable Dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Clients_Accounts.AccountNumber,
							Persons.FirstName,
                            Clients_Accounts.AccountBalance
                            From Clients_Accounts
                            inner join Persons On Persons.ID=Clients_Accounts.PersonID
                            Where AccountNumber Like @AccountNumber;
							";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

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

        public static bool GetClientInfoByAccountNumber(ref int ClientID, ref int PersonID,ref string  FirstName,
            ref string LastName,ref  string Email,ref  string Phone,ref string Address,
            string AccountNumber, ref string PinCode, ref decimal AccountBalance, ref  DateTime DateOfBirth)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Clients_Accounts.ID,Clients_Accounts.PersonID,
			Persons.FirstName,Persons.lastName,Persons.Email,Persons.Phone,Persons.Address,
			Clients_Accounts.AccountNumber,Clients_Accounts.PinCode,Clients_Accounts.AccountBalance,
			Persons.DateOfBirth From Clients_Accounts
			inner join Persons ON 
			Persons.ID=Clients_Accounts.PersonID
			where Clients_Accounts.AccountNumber=@AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    ClientID = (int)reader["ID"];
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    PinCode = (string)reader["PinCode"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    AccountBalance = (decimal)reader["AccountBalance"];

                    isFound = true;
                    
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
                
            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;


        }

        public static bool GetClientInfoByAccountNumberAndPinCode(ref int ClientID, ref int PersonID, ref string FirstName,
            ref string LastName, ref string Email, ref string Phone, ref string Address,
            string AccountNumber, string PinCode, ref decimal AccountBalance, ref DateTime DateOfBirth)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Clients_Accounts.ID,Clients_Accounts.PersonID,
			Persons.FirstName,Persons.lastName,Persons.Email,Persons.Phone,Persons.Address,
			Clients_Accounts.AccountNumber,Clients_Accounts.PinCode,Clients_Accounts.AccountBalance,
			Persons.DateOfBirth From Clients_Accounts
			inner join Persons ON 
			Persons.ID=Clients_Accounts.PersonID
			where Clients_Accounts.AccountNumber=@AccountNumber;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    ClientID = (int)reader["ID"];
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    AccountBalance = (decimal)reader["AccountBalance"];

                    isFound = true;

                }
                else
                {
                    isFound = false;
                }

                reader.Close();

            }
            catch
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;


        }

        public static bool IsAccountNumberExist(string AccountNumber)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "select Found=1 From Clients_Accounts where Clients_Accounts.AccountNumber=@AccountNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isExist = reader.HasRows;

                reader.Close();

            }
            catch
            {
                isExist = false;
            }
            finally
            {
                connection.Close();
            }
            return isExist;
        }


        public static int AddNewClient(string AccountNumber,string PinCode,decimal AccountBalance,int PersonID)

        {

            int ClientID = -1;
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"insert into Clients_Accounts (AccountNumber,PinCode,AccountBalance,PersonID)
								Values (@AccountNumber,@PinCode,@AccountBalance,@PersonID)
								Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@AccountBalance", AccountBalance);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ClientID= InsertedID;
                }

            }
            catch
            {
                ClientID = -1;
            }
            finally
            {
                connection.Close();
            }

            return ClientID;

        }


        public static bool UpdateClient(string AccountNumber, string PinCode, decimal AccountBalance,int ClientID)
        {
            int rowaffected = 0;
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);
            string query = @"Update Clients_Accounts Set AccountNumber=@AccountNumber,PinCode=@PinCode,
                            AccountBalance=@AccountBalance
                            where Clients_Accounts.ID=@ClientID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"AccountNumber", AccountNumber);
            command.Parameters.AddWithValue(@"PinCode", PinCode);
            command.Parameters.AddWithValue(@"AccountBalance", AccountBalance);
            command.Parameters.AddWithValue(@"ClientID", ClientID);
            
            try
            {
                connection.Open();

                rowaffected = command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowaffected > 0);

        }


        public static bool DeleteClient(int ClientID)
        {
            int rowaffected = 0;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "Delete From Clients_Accounts Where Clients_Accounts.ID=@ClientID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ClientID", ClientID);

            try
            {
                connection.Open();

                rowaffected = command.ExecuteNonQuery();

            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowaffected > 0);
        }
    }
}
