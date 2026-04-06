using BankSystemDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsClient : clsPerson
    {


        // Fields

        int ID { get; set; }
        string AccountNO { get; set; }
        string PINcode { get; set; }
        decimal Balance { get; set; }
        DateTime CreatedAt { get; set; }



        // Constructors
        public clsClient() : base()
        {

            this.ID = -1;
            this.AccountNO = "";
            this.PINcode = "";
            this.Balance = 0m;
            this.CreatedAt = DateTime.Now;

            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.BirthDate = null;
            this.Address = "";
            this.ImagePath = "";
            this.CountryID = -1;
            this.Phone = "";
            this.Gender = "Male";

        }

        private clsClient(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, string Gender, int ID, string AccountNO, string PINcode, decimal Balance, DateTime CreatedAt) : base(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, Gender)
        {

            this.ID = ID;
            this.AccountNO = AccountNO;
            this.PINcode = PINcode;
            this.Balance = Balance;
            this.CreatedAt = CreatedAt;

        }






        // Functions

        public static DataTable ListAllClients()
            => clsDataClient.ListAllClients();



    }
}
