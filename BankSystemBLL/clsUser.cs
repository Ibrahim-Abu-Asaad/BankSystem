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

        // Properties
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Permissions { get; set; }
        public DateTime LastLogin { get; set; }


        // Enums
        // Enum (Mode AddNew/Create Or Mode Update)
        public enum enMode
        {
            Create,
            Update
        }
        public enMode Mode;


        // Enum (Permissions)
        [Flags]
        public enum enPermissions
        {
            None = 0,
            ManageUsers = 1,
            ManageCLients = 2,
            ManageCurrencies = 4,
            ManageTransactions = 8,
            LoginsRegister = 16
        }
        //enPermissions ePermissions;

        // 0 + 2 + 8 = 10
        int UserPermissions = (int)(enPermissions.ManageCLients | enPermissions.ManageTransactions);

        // 0 + 8 = 8
        int ClientPermissions = (int)(enPermissions.ManageTransactions);

        // Full Control
        // 0 + 1 + 2 + 4 + 8 + 16 = 31
        public static int AdminPermissions = (int)(enPermissions.ManageUsers | enPermissions.ManageCLients | enPermissions.ManageTransactions | enPermissions.ManageCurrencies | enPermissions.LoginsRegister);


        // Constructors
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


        // Private Functions Used Inside The Class;

        private static bool _CreateNewUser(clsUser User)
        {

            return true;

        }

        private static bool _UpdateUser(clsUser User)
        {

            return true;

        }



        // Functions Used In Programm
        public static int IsUserExist(string Username, string Password)
        {

            return clsDataUser.IsUserExist(Username, Password);

        }

        public static int IsUserExist(string Username)
        {
            return clsDataUser.IsUserExist(Username);
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

        public static DataTable ListUsers()
        {

            return clsDataUser.ListUsers();

        }
        
        public static void DeleteUser(int UserID)
        {
            //
        }

        public static void UpdateLastLogin(int UserID)
        {

            clsDataUser.UpdateLastLogin(UserID);

        }

        public bool HasPermissions(enPermissions Permission)
        {

            if (this.Permissions == (int)AdminPermissions)
                return true;

            return ((Permissions & (int)Permission) == (int)Permission);

        }

        public static int GetUserCount()
        {
            return clsDataUser.GetUserCount();
        }

        public static int GetAdminCount()
        {
            return clsDataUser.GetAdminCount();
        }

        public static bool CheckIfPasswordRight(int UserID, string PasswordHash)
        {

            return clsDataUser.CheckIfPasswordRight(UserID, PasswordHash);

        }


        public bool Save()
        {

            switch (Mode)
            {


                case enMode.Create:
                    if (_CreateNewUser(this))
                        return true;
                    break;

                
                case enMode.Update:
                    if (_UpdateUser(this))
                        return true;
                    break;
                    

            
            }

            return false;

        }




    }
}
