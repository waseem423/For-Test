using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Data_Access_Layer
{
    public class clsPersonDataAccess
    {
        public static int AddNewPerson(string FirstName,string LastName,string Email,string Phone
           , string Address,DateTime DateOfBirth)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"insert Into Persons(FirstName,lastName,Email,Phone ,Address,DateOfBirth)
		                    Values(@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth);
                            Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result!=null&&int.TryParse(result.ToString(), out int InsertedID))
                {
                    PersonID = InsertedID;
                }


            }
            catch
            {
                PersonID = -1;
            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }

        public static bool UpdatePerson(int ID,string FirstName,string LastName,string Email,string Phone,string Address,DateTime DateOfBirth)
        {
            int rowaffected = 0;
            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"update Persons set FirstName=@FirstName,lastName=@LastName,
                            Email=@Email,Phone=@Phone,
					        Address=@Address,DateOfBirth=@DateOfBirth
					        where Persons.ID=@ID;";

            SqlCommand command = new SqlCommand(query, connection);


            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
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


        public static bool DeletePerson(int ID)
        {
            int rowaffected = 0;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = "Delete From Persons where Persons.ID=@ID";

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
