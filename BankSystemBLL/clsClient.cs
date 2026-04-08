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

        public int ID { get; set; }
        public string AccountNO { get; set; }
        public string PINcode { get; set; }
        public decimal Balance { get; set; }
        public int CurrencyID { get; set; }
        public DateTime CreatedAt { get; set; }


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
            this.CurrencyID = -1;
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

        private clsClient(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, string Gender, int ID, string AccountNO, string PINcode, decimal Balance, int CurrencyID) : base(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, Gender)
        {

            this.ID = ID;
            this.AccountNO = AccountNO;
            this.PINcode = PINcode;
            this.Balance = Balance;
            this.CurrencyID = CurrencyID;
            this.CreatedAt = DateTime.Now;

            Mode = enMode.Update;

        }






        // Functions

        private bool _AddNewClient(clsClient Client)
            => clsDataClient.AddNewClient(Client.Name, Client.Email, Client.BirthDate.Value,
                Client.Address, Client.ImagePath, Client.CountryID,
                Client.Phone, Client.Gender,
                Client.AccountNO, Client.PINcode, Client.Balance, Client.CurrencyID) != -1;
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
                Client.ID, Client.AccountNO, Client.PINcode, Client.Balance, Client.CurrencyID);

        public static bool DeleteClient(int ID)
            => clsDataClient.DeleteClient(ID);
                

        public static DataTable ListAllClients()
            => clsDataClient.ListAllClients();


        public static DataTable ListAllClientsWithoutThisClient(int ClientID)
            => clsDataClient.ListAllClientsWithoutThisClient(ClientID);


        public static int GetClientCount()
            => clsDataClient.GetClientCount();


        public static clsClient GetClientByClientID(int ClientID)
        {
            int PersonID = -1, CountryID = -1, MarkDeleted = 0;
            string Name = "", Email = "", Address = "", ImagePath = "", Phone = "", Gender = "", AccountNO = "", PINcode = "";
            DateTime BirthDate = DateTime.Now;
            decimal Balance = 0;
            int CurrencyID = -1;

            if (clsDataClient.GetClientByClientID(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address,
                ref ImagePath, ref CountryID, ref Phone, ref MarkDeleted, ref Gender, ClientID, ref AccountNO, ref PINcode, ref Balance, ref CurrencyID))
            {
                return new clsClient(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, Gender, ClientID, AccountNO, PINcode, Balance, CurrencyID);
            }
            else
                return null;
        }

        // Find Client by Account Number
        public static clsClient GetClientByAccountNO(string AccountNO)
        {
            int PersonID = -1, CountryID = -1, MarkDeleted = 0, ClientID = -1;
            string Name = "", Email = "", Address = "", ImagePath = "", Phone = "", Gender = "", PINcode = "";
            DateTime BirthDate = DateTime.Now;
            decimal Balance = 0;
            int CurrencyID = -1;

            if (clsDataClient.GetClientByAccountNO(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address,
                ref ImagePath, ref CountryID, ref Phone, ref MarkDeleted, ref Gender, ref ClientID, AccountNO, ref PINcode, ref Balance, ref CurrencyID))
            {
                return new clsClient(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, Gender, ClientID, AccountNO, PINcode, Balance, CurrencyID);
            }
            else
                return null;
        }

        public static bool IsClientExist(string AccountNO)
            => clsDataClient.IsClientExist(AccountNO);

        public static bool IsClientExist(int ClientID)
            => clsDataClient.IsClientExist(ClientID);

        public static int GetTotalClients()
            => clsDataClient.GetClientCount();
        
        public bool CheckPIN(string PIN)
            => clsDataClient.CheckIfPINcodeRight(this.ID, PIN);






        //public bool Save()
        //{

        //    switch (Mode)
        //    {
        //        case enMode.Create:
        //            _AddNewClient(this);
        //            break;


        //        case enMode.Update:
        //            _UpdateClient(this);
        //            break;
        //    }

        //    return false;
        //}

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create:
                    if (_AddNewClient(this))
                        return true;

                    return false;

                case enMode.Update:
                    return _UpdateClient(this);
            }

            return false;
        }




    }
}
