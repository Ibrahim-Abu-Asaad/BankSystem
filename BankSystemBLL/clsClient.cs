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


        // Mode

        public enum enMode
        {
            Create,
            Update
        }
        public enMode Mode;



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

            Mode = enMode.Create;

        }

        private clsClient(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, string Gender, int ID, string AccountNO, string PINcode, decimal Balance) : base(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, Gender)
        {

            this.ID = ID;
            this.AccountNO = AccountNO;
            this.PINcode = PINcode;
            this.Balance = Balance;
            this.CreatedAt = DateTime.Now;

            Mode = enMode.Update;

        }






        // Functions

        private bool _AddNewClient(clsClient Client)
            => clsDataClient.AddNewClient(Client.Name, Client.Email, Client.BirthDate.Value,
                Client.Address, Client.ImagePath, Client.CountryID,
                Client.Phone, Client.Gender,
                Client.AccountNO, Client.PINcode, Client.Balance) != -1;
        //{

        //    int newClientID = clsDataClient.AddNewClient
        //        (Client.Name, Client.Email, Client.BirthDate.Value,
        //        Client.Address, Client.ImagePath, Client.CountryID,
        //        Client.Phone, Client.Gender,
        //        Client.AccountNO, Client.PINcode, Client.Balance);

        //    return (newClientID != -1);

        //}

        private bool _UpdateClient(clsClient Client)
            => clsDataClient.UpdateClient(Client.PersonID, Client.Name, Client.Email, Client.BirthDate.Value,
                Client.Address, Client.ImagePath, Client.CountryID, Client.Phone, Client.Gender,
                Client.ID, Client.AccountNO, Client.PINcode, Client.Balance);
        //{

        //    bool updated = clsDataClient.UpdateClient(
        //        Client.PersonID, Client.Name, Client.Email, Client.BirthDate.Value,
        //        Client.Address, Client.ImagePath, Client.CountryID, Client.Phone, Client.Gender,
        //        Client.ID, Client.AccountNO, Client.PINcode, Client.Balance);

        //    return updated;

        //}
        public static bool DeleteClient(int ID)
            => clsDataClient.DeleteClient(ID);
                

        public static DataTable ListAllClients()
            => clsDataClient.ListAllClients();

        public static int GetClientCount()
            => clsDataClient.GetClientCount();







        public bool Save()
        {

            switch (Mode)
            {
                case enMode.Create:
                    _AddNewClient(this);
                    break;


                case enMode.Update:
                    _UpdateClient(this);
                    break;
            }




            return false;
        }

    }
}
