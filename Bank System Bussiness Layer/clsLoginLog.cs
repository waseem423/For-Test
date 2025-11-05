using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System_Bussiness_Layer
{
    public class clsLoginLog
    {
        public static DataTable  GetAllAllLoginsLog()
        {
            return clsLoginLogDataAccess.GetAllLoginsLog();
        }

        public static  void AddNewLogin(int UserID,DateTime Date)
        {
            clsLoginLogDataAccess.AddNewLogin(UserID, Date);

        }

    }
}
