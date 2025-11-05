using Bank_System_Bussiness_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_System_Presentaion_Layer
{
    public static  class GlobalVariable
    {
        public static clsUsers _User;

        public static int Permissions = 0;

        
        public static clsClients _SourceClient;


        public static clsClients _DestinationClient;

        public static DataTable DTCountries = clsCountries.GetAllCountries();

        public static clsCurrency _CurrencyFrom;
        
        public static clsCurrency _CurrencyTo;


    }
}
