using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Bussiness_Layer
{
    public class clsCountries
    {

        public int ID { set; get; }

        public string CountryName { set; get; }


        public clsCountries()
        {
            ID = 0;
            CountryName = "";
        }

        public clsCountries(int ID,string CountryName)
        {
            this.ID = ID;
            this.CountryName = CountryName;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountriesDataAccess.GetAllCountries();
        }

    }
}
