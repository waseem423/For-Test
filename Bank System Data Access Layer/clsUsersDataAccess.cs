using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;


namespace Bank_System_Data_Access_Layer
{
    public class clsUsersDataAccess
    {

        public static bool GetUserInfoByUserNameAndPassword(ref int UserID,ref int PersonID,ref string FirstName,ref string LastName,ref string Email,ref string Phone,ref string Address,
             string UserName, string Password ,ref int Permission,ref DateTime DateOfBirth)
        {
            bool isFound;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"Select Users.ID,Persons.FirstName,Persons.lastName,Persons.DateOfBirth,Persons.Email,Persons.Phone,Persons.Address,
		                    Users.UserName,Users.Password,Users.Permissions From Users
		                    inner join Persons On Persons.ID=Users.PersonID
                            Where Username=@UserName And Password = @Password;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    UserID = (int)reader["Id"];
                    PersonID = (int)reader["ID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                   
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permission = (int)reader["Permissions"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    
                    isFound = true;
                    reader.Close();
                }
                else
                {
                    isFound = false;
                }
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


        public static bool GetUserInfoByUserName(ref int UserID,ref int PersonID, ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Address,
            string UserName,ref string Password, ref int Permission, ref DateTime DateOfBirth)
        {
            bool isFound;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"Select Persons.ID , Users.ID As UserID,Persons.FirstName,Persons.lastName,Persons.DateOfBirth,Persons.Email,Persons.Phone,Persons.Address,
		                    Users.UserName,Users.Password,Users.Permissions From Users
		                    inner join Persons On Persons.ID=Users.PersonID
                            Where Username=@UserName ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);
            

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["ID"];
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];

                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    Permission = (int)reader["Permissions"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];

                    isFound = true;
                    reader.Close();
                }
                else
                {
                    isFound = false;
                }
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

        public static int GetRegistredUsers()
        {
            int NumberOfUsers = 0 ;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "select Count(*) From Users;";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null)
                {
                    NumberOfUsers = (int)result;
                }


            }
            catch
            {

            }
            finally
            {
                connection.Close();
            }

            return NumberOfUsers;

        }

        public static DataTable GetAllUsers()
        {
            DataTable DT = new DataTable();
            
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"Select Users.ID,Users.UserName,Users.Password,Persons.FirstName,Persons.lastName,
                            Persons.DateOfBirth,Persons.Email,Persons.Phone,Persons.Address,Users.Permissions From Users
                            inner join Persons On Users.PersonID=Persons.ID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
                {
                    DT.Load(reader);
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

            return DT;
        }

        public static DataTable GetAllUsersWithSearch(string UserName)
        {
            UserName += "%"; 
            DataTable DT = new DataTable();

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @" Select Users.ID,Users.UserName,Users.Password,Persons.FirstName,Persons.lastName,
                            Persons.DateOfBirth,Persons.Email,Persons.Phone,Persons.Address,Users.Permissions From Users
                            inner join Persons On Users.PersonID=Persons.ID
							where Users.UserName like @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    DT.Load(reader);
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

            return DT;
        }

        public static bool IsUsernameExist(string Username)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Found=1 From Users where Users.UserName=@Username";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;
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

        public static int AddNewUser(int PersonID,string UserName,string Password,int Permissions)
        {
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"insert Into Users(PersonID,UserName,Password,Permissions)
					                values(@PersonID,@UserName,@Password,@Permissions)
					                select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@Permissions", Permissions);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null&&int.TryParse(result.ToString(),out int InsertedID))
                {
                    UserID = InsertedID;
                }

            }
            catch
            {
                UserID = -1;
            }
            finally
            {
                connection.Close();
            }

            return UserID;
        }

        public static bool UpdateUser(int UserID,int PersonID,string UserName,string Password,int Permissions)
        {
            int rowaffected = 0;
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);
            string query = @"update Users set PersonID=@PersonID,UserName=@UserName,
                            Password=@Password,Permissions=@Permissions
                            where Users.ID=@UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue(@"PersonID", PersonID);
            command.Parameters.AddWithValue(@"UserName", UserName);
            command.Parameters.AddWithValue(@"Password", Password);
            command.Parameters.AddWithValue(@"Permissions", Permissions);
            command.Parameters.AddWithValue(@"UserID", UserID);

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

        public static bool DeleteUser(int ID)
        {
            int rowaffected = 0;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "Delete From Users Where Users.ID=@ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);

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
