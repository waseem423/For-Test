using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Data_Access_Layer
{
    public  class clsCurrencyDataAccess
    {

       public static bool GetCurrencyByCountryName( string CountryName, ref int ID, ref int CountryID,ref string CurrencyName, ref decimal  Rate, ref string Code)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsBankSystemDataAccessSettings.ConnectionString);

            string query = @"select Currency.ID,Currency.CountryID,Currency.CurrencyName,
                            Currency.Rate,Currency.Code From Currency 
                            inner join Countries On Currency.CountryID=Countries.ID
                            where Countries.CountryName=@CountryName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    ID = (int)reader["ID"];
                    CountryID = (int)reader["CountryID"];
                    CurrencyName = (string)reader["CurrencyName"];
                    Rate = (decimal  )reader["Rate"];
                    Code = (string)reader["Code"];

                    reader.Close();
                    isFound = true;
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

    }
}
