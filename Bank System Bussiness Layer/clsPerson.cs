using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


using Bank_System_Data_Access_Layer;

namespace Bank_System_Bussiness_Layer
{
    public class clsPerson
    {
        public int ID { set; get; }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        


        public DateTime DateOfBirth { set; get; }
        public clsPerson()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            
            DateOfBirth = DateTime.Now;

        }

        public clsPerson(int ID,string FirstName,string LastName,string Email,string Phone ,string Address,DateTime DateOfBirth)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            
            this.DateOfBirth = DateOfBirth;
        }

        public bool AddNewPerson()
        {
            this.ID = clsPersonDataAccess.AddNewPerson(this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth);
            return (this.ID != -1);

        }

        public bool UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(this.ID, this.FirstName, this.LastName, this.Email, this.Phone, this.Address, this.DateOfBirth);

        }
        protected bool DeletePerson()
        {
            return clsPersonDataAccess.DeletePerson(this.ID);
        }
      

    }
}
