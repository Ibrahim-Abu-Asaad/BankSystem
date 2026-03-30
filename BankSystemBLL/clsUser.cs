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

            return clsDataUser.AddNewUser(User.Name, User.Email, User.BirthDate.Value, User.Address, User.ImagePath, User.CountryID, User.Phone, User.Username, User.Password, User.PermissionID) != -1;

        }

        private static bool _UpdateUser(clsUser User)
        {

            return clsDataUser.UpdateUser(User.PersonID, User.Name, User.Email, User.BirthDate.Value, User.Address, User.ImagePath, User.CountryID, User.Phone, User.UserID, User.Username, User.Password, User.PermissionID);

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

        public static bool IsAdmin(int ID)
        {

            return clsDataUser.IsAdmin(ID);
        
        }
        
        public static bool IsUsernameExist(string Username)
        {

            return clsDataUser.IsUsernameExist(Username);

        }

        public static bool IsUsernameExist(string Username, int UserID)
        {

            return clsDataUser.IsUsernameExist(Username, UserID);

        }

        public static bool IsEmailExist(string Email)
        {

            return clsDataUser.IsEmailExist(Email);

        }

        public static bool IsEmailExist(string Email, int PersonID)
        {

            return clsDataUser.IsEmailExist(Email, PersonID);

        }

        public static bool IsPhoneExist(string Phone)
        {

            return clsDataUser.IsPhoneExist(Phone);

        }
        public static bool IsPhoneExist(string Phone, int PersonID)
        {

            return clsDataUser.IsPhoneExist(Phone, PersonID);

        }

        public static bool DeleteUser(int ID)
        {

            clsUser User = clsUser.GetUserByUserID(ID);
            //int PeronsID = User.PersonID;

            return clsDataUser.DeleteUser(User.PersonID);
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


        // This functions should written in its own class
        public static DataTable GetAllCountries()
        {

            return clsDataUser.GetAllCountries();

        }

        // And this one
        public static int GetPermissionIDByPermissionLevel(int PermissionLevel)
        {

            return clsDataPermission.GetPermissionIDByPermissionLevel(PermissionLevel);

        }

        // And this one
        public static int AddNewPermission(int PermissionLevel)
        {

            return clsDataPermission.AddNewPermission(PermissionLevel);

        }

        // And this one
        public static bool IsPermissionLevelExist(int PermissionLevel)
        {

            return clsDataPermission.IsPermissionLevelExist(PermissionLevel);

        }


    }
}
