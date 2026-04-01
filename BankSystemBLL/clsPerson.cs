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
        public int CountryID { get; set; }
        public string Phone { get; set; }
        public int MarkDeleted { get; set; }
        public string Gender { get; set; }

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
            this.CountryID = -1;
            this.Phone = "";
            this.MarkDeleted = 0;
            this.Gender = "Male";
        }

        protected clsPerson(string Name, string Email, DateTime BirthDate, string Address,
            string ImagePath, int CountryID, string Phone, int MarkDeleted, string Gender)
        {
            this.Name = Name;
            this.Email = Email;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;
            this.Phone = Phone;
            this.MarkDeleted = MarkDeleted;
            this.Gender = Gender;
        }

        protected clsPerson(int PersonID, string Name, string Email, DateTime BirthDate,
            string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, string Gender)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.Email = Email;
            this.BirthDate = BirthDate;
            this.Address = Address;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;
            this.Phone = Phone;
            this.MarkDeleted = MarkDeleted;
            this.Gender = Gender;
        }
    }
}