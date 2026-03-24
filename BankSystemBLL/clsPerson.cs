using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsPerson
    {

        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Country { get; set; }


        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.BirthDate = null;
            this.Address = "";
            this.ImagePath = "";
            this.Country = "";
        }

        protected clsPerson(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country)
        {

            this.Name = Name;
            this.Email = Email;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.Country = Country;
            
        }

        // This maybe will use it to load data(Just in case);
        //private clsPerson(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country)
        //{

        //    this.PersonID = PersonID;
        //    this.Name = Name;
        //    this.Email = Email;
        //    this.BirthDate = BirthDate;
        //    this.Address = Address;
        //    this.ImagePath = ImagePath;
        //    this.Country = Country;

        //}





    }
}
