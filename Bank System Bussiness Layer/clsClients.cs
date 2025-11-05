using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bank_System_Bussiness_Layer
{
    public class clsClients : clsPerson
    {

        enum enMode { Update,AddNew};
        
        enMode Mode;
        
        public int ClientID { set; get; }

        public int PersonID { set; get; }

        public string AccountNumber { set; get; }

        public string PinCode { set; get; }

        public decimal AccountBalance { set; get; }

        public clsClients()
        :base()
        {
            this.ClientID = -1;
            this.PersonID = -1;
            this.AccountNumber = "";
            this.AccountBalance = 0;
            this.PinCode = "";

            Mode = enMode.AddNew;
        }

        private clsClients(int ClientID,int PersonID,string FirstName,string LastName,string Email,string Phone,string Address,
            string AccountNumber,string PinCode,decimal AccountBalance,DateTime DateOfBirth)
            :base(PersonID,FirstName,LastName,Email,Phone,Address,DateOfBirth)
        {
            this.ClientID = ClientID;
            this.PersonID =  PersonID;
            this.AccountNumber = AccountNumber;
            this.AccountBalance = AccountBalance;
            this.PinCode = PinCode;

            Mode = enMode.Update;
        }


        public static int GetActiveCleints()
        {
           return clsClientsDataAccess.GetActiveClients();
        }

        public static decimal GetTotalAccountBalance()
        {
            return clsClientsDataAccess.GetTotalBalanceInSystem();
        }

        public static DataTable GetAllClients()
        {
            return clsClientsDataAccess.GetAllClients();
        }

        public static DataTable GetAllAccounts()
        {
            return clsClientsDataAccess.GetAllAccounts();
        }

        public static DataTable GetAllClientsWithSearch(string AccountNumber)
        {
            return clsClientsDataAccess.GetAllClientsWithSearch(AccountNumber);
        }


        public static DataTable GetAllAccountsWithSearch(string AccountNumber)
        {
            return clsClientsDataAccess.GetAllAccountsWithSearch(AccountNumber);
        }
        public static clsClients Find(string AccountNumber)
        {
            int ClientID = 0, PersonID = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "",PinCode = "";
            decimal AccountBalance = 0;
            DateTime DateOfBirth = DateTime.Now;

            if(clsClientsDataAccess.GetClientInfoByAccountNumber(ref ClientID,ref PersonID
                ,ref FirstName,ref LastName,ref Email,ref Phone,ref Address,AccountNumber,
                ref PinCode,ref AccountBalance,ref DateOfBirth ))
            {
                return new clsClients(ClientID, PersonID, FirstName, LastName, Email, Phone, Address, AccountNumber, PinCode, AccountBalance, DateOfBirth);
            }
            return null;

        }

        public static clsClients Find(string AccountNumber , string PinCode)
        {
            int ClientID = 0, PersonID = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "" ;
            decimal AccountBalance = 0;
            DateTime DateOfBirth = DateTime.Now;

            if (clsClientsDataAccess.GetClientInfoByAccountNumberAndPinCode(ref ClientID, ref PersonID
                , ref FirstName, ref LastName, ref Email, ref Phone, ref Address, AccountNumber,
                PinCode, ref AccountBalance, ref DateOfBirth))
            {
                return new clsClients(ClientID, PersonID, FirstName, LastName, Email, Phone, Address, AccountNumber, PinCode, AccountBalance, DateOfBirth);
            }
            return null;
        }

        public static bool IsAccountNumberExist(string AccountNumber)
        {
            return clsClientsDataAccess.IsAccountNumberExist(AccountNumber);
        }

        private bool _AddNew()
        {
            if(this.AddNewPerson())
            {
                this.ClientID = clsClientsDataAccess.AddNewClient(this.AccountNumber, this.PinCode, this.AccountBalance, this.ID);
            }
            return (this.ClientID != -1);
        }

        private bool _Update()
        {
            if(this.UpdatePerson())
            {
                return clsClientsDataAccess.UpdateClient(this.AccountNumber, this.PinCode, this.AccountBalance, this.ClientID);
            }
            return false;
        }

        public bool DeleteClient()
        {
            return (clsClientsDataAccess.DeleteClient(this.ClientID) && this.DeletePerson());
        }

        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNew())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        if(_Update())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
            }
            return false;
        }
    }
}
