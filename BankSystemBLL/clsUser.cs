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
        public int PermissionID { get; set; }
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
        //public static int UserPermissions = (int)(enPermissions.ManageCLients | enPermissions.ManageTransactions);

        // 0 + 8 = 8
        //public static int ClientPermissions = (int)(enPermissions.ManageTransactions);

        // Full Control
        // 0 + 1 + 2 + 4 + 8 + 16 = 31
        public static int AdminPermissions = (int)(enPermissions.ManageUsers | enPermissions.ManageCLients | enPermissions.ManageTransactions | enPermissions.ManageCurrencies | enPermissions.LoginsRegister);


        // Constructors
        public clsUser() : base()
        {

            this.UserID = -1;
            this.Username = "";
            this.Password = "";
            this.PermissionID = -1;
            this.LastLogin = DateTime.Now;

            this.PersonID = -1;
            this.Name = "";
            this.Email = "";
            this.BirthDate = null;
            this.Address = "";
            this.ImagePath = "";
            this.CountryID = -1;
            this.Phone = "";



            //base();

        }

        private clsUser(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, string Username, string Password, int PermissionID, DateTime LastLogin) : base(Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted)
        {

            this.Username = Username;
            this.Password = Password;
            this.PermissionID = PermissionID;
            this.LastLogin = LastLogin;
            
            //base(this.PersonID,this.Name,this.Email,this.BirthDate,this.Address,this.ImagePath,this.Country);

        }

        private clsUser(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, int MarkDeleted, int UserID, string Username, string Password, int PermissionID, DateTime LastLogin) : base(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted)
        {
            
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.PermissionID = PermissionID;
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

        public static clsUser GetUserByUserID(int ID)
        {

            int PersonID = -1;
            string Name = "";
            string Email = "";
            DateTime BirthDate = DateTime.Now;
            string Address = "";
            string ImagePath = "";
            int CountryID = -1;
            string Phone = "";
            int MarkDeleted = 0;

            string Username = "";
            string Password = "";
            int PermissionID = -1;
            DateTime LastLogin = DateTime.Now;

            if(clsDataUser.GetUserByUserID(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address, ref ImagePath, ref CountryID, ref Phone, ref MarkDeleted, ID, ref Username, ref Password, ref PermissionID, ref LastLogin))
                return new clsUser(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, ID, Username, Password, PermissionID, LastLogin);

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
            int CountryID = -1;
            string Phone = "";
            int MarkDeleted = 0;

            int UserID = -1;
            //string Username = "";
            string Password = "";
            int PermissionID = -1;
            DateTime LastLogin = DateTime.Now;

            if (clsDataUser.GetUserByUsername(ref PersonID, ref Name, ref Email, ref BirthDate, ref Address, ref ImagePath, ref CountryID, ref Phone, ref MarkDeleted, ref UserID, Username, ref Password, ref PermissionID, ref LastLogin))
                return new clsUser(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, MarkDeleted, UserID, Username, Password, PermissionID, LastLogin);

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

        public static void UpdateLastLoginAndAddedItToLoginsRegister(int UserID)
        {

            clsDataUser.UpdateLastLoginAndAddedItToLoginsRegister(UserID);

        }

        public bool HasPermission(enPermissions PermissionToCheck)
        {

            int userPermissionValue = clsDataUser.GetPermissions(this.PermissionID);

            if (userPermissionValue == AdminPermissions)
                return true;

            return ((userPermissionValue & (int)PermissionToCheck) == (int)PermissionToCheck);

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


        public static DataTable ListLoginsRegister()
        {

            return clsDataUser.ListLoginsRegister();

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
