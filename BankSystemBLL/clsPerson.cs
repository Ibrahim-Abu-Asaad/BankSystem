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
        public string Name { get; set; } = "";
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }


        public string FirstName => string.IsNullOrWhiteSpace(Name) ? "" : Name.Split(' ')[0];
        public string LastName => Name.Contains(" ") ? Name.Split(' ').Last() : "";


        public clsPerson()
        {
            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.BirthDate = null;
            this.Address = "";
            this.ImagePath = "";
            this.Country = "";
            this.Phone = "";

        }

        protected clsPerson(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country, string Phone)
        {

            this.Name = Name;
            this.Email = Email;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.Country = Country;
            this.Phone = Phone;
            
        }

        //This maybe will use it to load data(Just in case);
        protected clsPerson(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country, string Phone)
        {

            this.PersonID = PersonID;
            this.Name = Name;
            this.Email = Email;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.Country = Country;
            this.Phone = Phone;

        }





    }
}
