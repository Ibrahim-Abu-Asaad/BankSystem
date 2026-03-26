using BankSystemDAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsUser : clsPerson
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public DateTime LastLogin { get; set; }

        
        public enum enMode
        {
            Create,
            Update
        }
        public enMode Mode;


        [Flags]
        enum enPermissions
        {
            None = 0,
            ManageUsers = 1,
            ManageCLients = 2,
            ManageCurrencies = 4,
            ManageTransactions = 8
        }
        //enPermissions ePermissions;

        // 0 + 2 + 8 = 10
        int UserPermissions = (int)(enPermissions.ManageCLients | enPermissions.ManageTransactions);


        // 0 + 8 = 8
        int ClientPermissions = (int)(enPermissions.ManageTransactions);

        // Full Control
        // 0 + 1 + 2 + 4 + 8 = 15
        int AdminPermissions = (int)(enPermissions.ManageUsers | enPermissions.ManageCLients | enPermissions.ManageTransactions | enPermissions.ManageCurrencies);



        public clsUser() : base()
        {

            this.UserID = -1;
            this.Username = "";
            this.Password = "";
            this.Permissions = 0;
            this.LastLogin = DateTime.Now;

            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.BirthDate = null;
            this.Address = "";
            this.ImagePath = "";
            this.Country = "";
            this.Phone = "";



            //base();

        }

        private clsUser(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country, string Phone, string Username, string Password, int Permissions, DateTime LastLogin) : base(Name, Email, BirthDate, Address, ImagePath, Country, Phone)
        {

            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.LastLogin = LastLogin;
            
            //base(this.PersonID,this.Name,this.Email,this.BirthDate,this.Address,this.ImagePath,this.Country);

        }

        private clsUser(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country, string Phone, int UserID, string Username, string Password, int Permissions, DateTime LastLogin) : base(PersonID, Name, Email, BirthDate, Address, ImagePath, Country, Phone)
        {
            
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.LastLogin = LastLogin;

            //base(this.PersonID,this.Name,this.Email,this.BirthDate,this.Address,this.ImagePath,this.Country);

        }

        public static int IsUserExist(string Username, string Password)
        {

            return clsDataUser.IsUserExist(Username, Password);

        }

        public static bool IsUserExist(int UserID)
        {

            return clsDataUser.IsUserExist(UserID);

        }

        public static clsUser GetUserByUserID(int UserID)
        {

            int PersonID = -1;
            string Name = "";
            string Email = "";
            DateTime BirthDate = DateTime.Now;
            string Address = "";
            string ImagePath = "";
            string Country = "";
            string Phone = "";

            string Username = "";
            string Password = "";
            int Permissions = 0;
            DateTime LastLogin = DateTime.Now;

            if(clsDataUser.GetUserByUserID(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address, ref ImagePath, ref Country, ref Phone, UserID, ref Username, ref Password, ref Permissions, ref LastLogin))
                return new clsUser(PersonID, Name, Email, BirthDate, Address, ImagePath, Country, Phone, UserID, Username, Password, Permissions, LastLogin);

            return null;


        }

        public static clsUser GetUserByUsername(string Username)
        {

            int PersonID = -1;
            string Name = "";
            string Email = "";
            DateTime BirthDate = DateTime.Now;
            string Address = "";
            string ImagePath = "";
            string Country = "";
            string Phone = "";

            int UserID = -1;
            //string Username = "";
            string Password = "";
            int Permissions = 0;
            DateTime LastLogin = DateTime.Now;

            if (clsDataUser.GetUserByUsername(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address, ref ImagePath, ref Country, ref Phone, ref UserID, Username, ref Password, ref Permissions, ref LastLogin))
                return new clsUser(PersonID, Name, Email, BirthDate, Address, ImagePath, Country, Phone, UserID, Username, Password, Permissions, LastLogin);

            return null;


        }

        public clsUser CreateNewUser()
        {

            return new clsUser();

        }

        public bool Save()
        {

            switch (Mode)
            {

                case enMode.Create:


                case enMode.Update:

                    break;

            }

            return false;

        }




    }
}
