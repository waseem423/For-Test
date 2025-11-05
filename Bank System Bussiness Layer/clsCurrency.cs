using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Bussiness_Layer
{
    public class clsCurrency
    {

         public   int ID { set; get; }

        public int CountryID { set; get; }

        public string CurrencyName { set; get; }

        public decimal  Rate { set; get; }

        public string Code { set; get; }


        clsCurrency()
        {
            this.ID = 0;
            this.CountryID = 0;
            this.CurrencyName = "";
            this.Rate = 0;
            this.Code = "";

        }

        clsCurrency(int ID,int CountryID,string CurrencyName,decimal   Rate,string Code)
        {
            this.ID = ID;
            this.CountryID = CountryID;
            this.CurrencyName = CurrencyName;
            this.Rate = Rate;
            this.Code = Code;
        }

        public static clsCurrency Find(string CountryName)
        {
            int ID = 0, CountryID = 0;
            string CurrencyName = "", Code = "";
            decimal  Rate = 0;

            if(clsCurrencyDataAccess.GetCurrencyByCountryName(CountryName,ref ID,ref CountryID,ref CountryName,ref Rate,ref Code))
            {
                return new clsCurrency(ID, CountryID, CurrencyName, Rate, Code);
            }
            return null;
        }

    }
}
