using Bank_System_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Bank_System_Bussiness_Layer
{
    public class clsUsers : clsPerson 
    {

        enum enMode { Update,AddNew};

        enMode _Mode;

        public  enum enPermissions { AllPermissions=-1,AddClients=1,UpdateClient=2,
                                    DeleteClient=4,ManageUsers=8,Transactions=16};

        
        public int UserID { set; get; }

        public int PersonID { set; get; }
        public string Username { set; get; }

        public string Password { set; get; }

        public int Permission { set; get; }



        public clsUsers()
            :base()
        {
            this.UserID = -1;
            this.Username = "";
            this.Password = "";
            this.Permission = 0;
            _Mode = enMode.AddNew;
            this.PersonID = ID;
        }


        private clsUsers(int UserID,int PersonID, string FirstName, string LastName, string Email, string Phone, string Address
         ,string UserName, string Password, int Permissions,DateTime DateOfBirth)
            : base(PersonID, FirstName, LastName, Email, Phone, Address,DateOfBirth)         
        {
            this._Mode = enMode.Update;

            this.UserID = UserID;
            this.Username = UserName;
            this.Password = Password;
            this.Permission = Permissions;
        }

        private bool _AddNewUser()
        {
            if (this.AddNewPerson())
            {
                this.ID = clsUsersDataAccess.AddNewUser(this.ID, this.Username, this.Password, this.Permission);
            }
            return (this.ID != -1);
        }

        private bool _UpdateUser()
        {
            if(this.UpdatePerson())
            {
               return  clsUsersDataAccess.UpdateUser(this.UserID, this.ID, this.Username, this.Password, this.Permission);
            }
            return false;
        }

       public bool DeleteUser()
        {
            return (clsUsersDataAccess.DeleteUser(this.UserID)&&this.DeletePerson());
        }

        public static clsUsers Find(string UserName,string Password)
        {
            int UserID = -1;
            int PersonID = 0;
            int Permission = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "";
            DateTime DateOfBirth = DateTime.Now;
            if (clsUsersDataAccess.GetUserInfoByUserNameAndPassword(ref UserID,ref PersonID,ref FirstName, ref LastName, ref Email, ref Phone, ref Address,
              UserName, Password,ref Permission,ref DateOfBirth))
            {
                return new clsUsers(UserID,PersonID,FirstName, LastName, Email, Phone, Address, UserName, Password, Permission,DateOfBirth);
            }
            return null;
        }

        public static clsUsers Find(string UserName)
        {
            int UserID = -1;
            int PersonID = 0;
            int Permission = 0;
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "",Password="";
            DateTime DateOfBirth = DateTime.Now;

            if(clsUsersDataAccess.GetUserInfoByUserName(ref UserID,ref PersonID, ref FirstName, ref LastName, ref Email, ref Phone, ref Address,
              UserName,ref Password, ref Permission, ref DateOfBirth))
            {
                return new clsUsers(UserID,PersonID, FirstName, LastName, Email, Phone, Address, UserName, Password, Permission, DateOfBirth);

            }
            return null;
        }

        public static int GetRegisteredUsers()
        {
            return clsUsersDataAccess.GetRegistredUsers();
        }

        public static DataTable GetAllUsers()
        {
            return clsUsersDataAccess.GetAllUsers();
        }

        public static DataTable GetAllUsersWithSearch(string UserName)
        {
            return clsUsersDataAccess.GetAllUsersWithSearch(UserName);
        }

        public static bool IsUsernameExist(string Username)
        {
           return clsUsersDataAccess.IsUsernameExist(Username);
        }

       public  bool CheckAccessPermissions(enPermissions Permission)
        {
            if (this.Permission==(int)enPermissions.AllPermissions)
                return true;

            if (((int)Permission & this.Permission) == (int)Permission)
                return true;

            return false;
        }

        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewUser())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                case enMode.Update:
                    {
                        if(_UpdateUser())
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
