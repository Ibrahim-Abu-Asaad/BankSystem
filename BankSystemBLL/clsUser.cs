using BankSystemDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemBLL
{
    public class clsUser : clsPerson
    {

        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public int RoleID { get; set; }
        //public List<string> PermissionNames { get; set; } = new List<string>();

        public enum enMode { Create, Update }
        public enMode Mode;


        // Constructors
        public clsUser() : base()
        {
            this.UserID = -1;
            this.Username = "";
            this.Password = "";
            this.LastLogin = DateTime.Now;
            this.RoleID = -1;
            //this.PermissionNames = new List<string>();

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

        private clsUser(int PersonID, string Name, string Email,
                        DateTime BirthDate, string Address, string ImagePath,
                        int CountryID, string Phone, int MarkDeleted, string Gender,
                        int UserID, string Username, string Password,
                        DateTime LastLogin, int RoleID)
            : base(PersonID, Name, Email, BirthDate, Address,
                   ImagePath, CountryID, Phone, MarkDeleted, Gender)
        {
            this.UserID = UserID;
            this.Username = Username;
            this.Password = Password;
            this.LastLogin = LastLogin;
            this.RoleID = RoleID;

            //this.PermissionNames = clsPermission.GetAllPermissionsOfUser(UserID);
        }


        // Private Func
        private static bool _CreateNewUser(clsUser User)
        {

            int newUserID = clsDataUser.AddNewUser(
                User.Name, User.Email, User.BirthDate.Value,
                User.Address, User.ImagePath, User.CountryID,
                User.Phone, User.Gender,
                User.Username, User.Password, User.RoleID);

            return (newUserID != -1);

            //return clsPermission.SetPermissionsForUser(newUserID, User.PermissionNames);
        }

        private static bool _UpdateUser(clsUser User)
        {
            bool updated = clsDataUser.UpdateUser(
                User.PersonID, User.Name, User.Email, User.BirthDate.Value,
                User.Address, User.ImagePath, User.CountryID, User.Phone, User.Gender,
                User.UserID, User.Username, User.Password, User.RoleID);

            return updated;

            //return clsPermission.SetPermissionsForUser(User.UserID, User.PermissionNames);
        }



        // Public Func

        //public bool HasPermission(clsPermission.enPermissions Permission)
        //{
        //    return PermissionNames.Contains(Permission.ToString());
        //}

        public static bool DeleteUser(int ID)
        {

            clsUser User = clsUser.GetUserByUserID(ID);
            return clsDataUser.DeleteUser(User.PersonID);

        }


        public bool HasPermission(int RoleID, int PermissionID)
            => clsRole.HasPermission(RoleID, PermissionID);

        public static clsUser GetUserByUserID(int ID)
        {
            int PersonID = -1, CountryID = -1, MarkDeleted = 0, RoleID = -1;
            string Name = "", Email = "", Address = "", ImagePath = "",
                   Phone = "", Username = "", Password = "", Gender = "";
            DateTime BirthDate = DateTime.Now, LastLogin = DateTime.Now;

            if (clsDataUser.GetUserByUserID(
                    ref PersonID, ref Name, ref Email, ref BirthDate,
                    ref Address, ref ImagePath, ref CountryID, ref Phone,
                    ref MarkDeleted, ref Gender, ID, ref Username, ref Password,
                    ref RoleID, ref LastLogin))
            {
                return new clsUser(PersonID, Name, Email, BirthDate,
                                   Address, ImagePath, CountryID, Phone,
                                   MarkDeleted, Gender, ID, Username, Password,
                                   LastLogin, RoleID);
            }
            return null;
        }

        public static clsUser GetUserByUsername(string Username)
        {
            int PersonID = -1, UserID = -1, CountryID = -1, MarkDeleted = 0, RoleID = -1;
            string Name = "", Email = "", Address = "", ImagePath = "",
                   Phone = "", Password = "", Gender = "";
            DateTime BirthDate = DateTime.Now, LastLogin = DateTime.Now;

            if (clsDataUser.GetUserByUsername(
                    ref PersonID, ref Name, ref Email, ref BirthDate,
                    ref Address, ref ImagePath, ref CountryID, ref Phone,
                    ref MarkDeleted, ref Gender, ref UserID, Username, ref Password,
                    ref RoleID, ref LastLogin))
            {
                return new clsUser(PersonID, Name, Email, BirthDate,
                                   Address, ImagePath, CountryID, Phone,
                                   MarkDeleted, Gender, UserID, Username, Password,
                                   LastLogin, RoleID);
            }
            return null;
        }


        // re do it 
        //public static List<string> GetAllPermissionsOfUser(int UserID)
        //    => clsPermission.GetAllPermissionsOfUser(UserID);


        public static int IsUserExist(string Username, string Password)
            => clsDataUser.IsUserExist(Username, Password);

        public static int IsUserExist(string Username)
            => clsDataUser.IsUserExist(Username);

        public static bool IsUserExist(int UserID)
            => clsDataUser.IsUserExist(UserID);

        // Handling The Same Data Problem And The Edit Form Problem
        public static bool IsUsernameExist(string Username)
            => clsDataUser.IsUsernameExist(Username);

        public static bool IsUsernameExist(string Username, int UserID)
            => clsDataUser.IsUsernameExist(Username, UserID);

        public static bool IsEmailExist(string Email)
            => clsDataUser.IsEmailExist(Email);

        public static bool IsEmailExist(string Email, int PersonID)
            => clsDataUser.IsEmailExist(Email, PersonID);

        public static bool IsPhoneExist(string Phone)
            => clsDataUser.IsPhoneExist(Phone);

        public static bool IsPhoneExist(string Phone, int PersonID)
            => clsDataUser.IsPhoneExist(Phone, PersonID);
        /////////////////////////////////////////////////////////////////
        

        public static void UpdateLastLoginAndAddedItToLoginsRegister(int UserID)
            => clsDataUser.UpdateLastLoginAndAddedItToLoginsRegister(UserID);

        public static bool CheckIfPasswordRight(int UserID, string PasswordHash)
            => clsDataUser.CheckIfPasswordRight(UserID, PasswordHash);

        public static DataTable ListUsers()
            => clsDataUser.ListUsers();

        public static DataTable ListUsersWithoutAdmin()
            => clsDataUser.ListUsersWithoutAdmin();

        public static DataTable ListLoginsRegister()
            => clsDataUser.ListLoginsRegister();

        public static int GetUserCount()
            => clsDataUser.GetUserCount();

        public static int GetAdminCount()
            => clsDataUser.GetAdminCount();

        //public static DataTable GetAllCountries()
        //    => clsDataUser.GetAllCountries();


        // SAVE
        public bool Save()
        {


            switch (Mode)
            {
                case enMode.Create: return _CreateNewUser(this);
                case enMode.Update: return _UpdateUser(this);
            }
            this.Password = clsCryptography.HashPassword(this.Password);
            return false;


            //if (Mode == enMode.Create)
            //    this.Password = clsCryptography.HashPassword(this.Password);

            //switch (Mode)
            //{
            //    case enMode.Create:
            //        if (_CreateNewUser(this))
            //        {
            //            Mode = enMode.Update;
            //            return true;
            //        }
            //        return false;

            //    case enMode.Update:
            //        return _UpdateUser(this);

            //    default:
            //        return false;
            //}


        }

    }
}


