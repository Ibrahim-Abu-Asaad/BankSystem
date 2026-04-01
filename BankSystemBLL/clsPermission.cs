using System;
using System.Collections.Generic;
using System.Data;
using BankSystemDAL;

namespace BankSystemBLL
{
    public class clsPermission
    {

        public int PermissionID { get; set; }
        public string PermissionName { get; set; }


        public enum enMode { Create, Update }
        public enMode Mode;

        public enum enPermissions
        {
            User_AccessPage,
            User_Create,
            User_Edit,
            User_Delete,

            Client_AccessPage,
            Client_Create,
            Client_Edit,
            Client_Delete,

            Transaction_AccessPage,
            Transaction_Withdraw,
            Transaction_Deposit,
            Transaction_Transfer,

            Currency_AccessPage,

            LoginsRegister_AccessPage
        }

        //  Constructors

        public clsPermission()
        {
            this.PermissionID = -1;
            this.PermissionName = "";
            this.Mode = enMode.Create;
        }

        private clsPermission(int PermissionID, string PermissionName)
        {
            this.PermissionID = PermissionID;
            this.PermissionName = PermissionName;
            this.Mode = enMode.Update;
        }

        // Private 

        private bool _AddNewPermission()
        {
            this.PermissionID = clsDataPermission.AddNewPermission(this.PermissionName);
            return this.PermissionID != -1;
        }

        private bool _UpdatePermission()
        {
            return clsDataPermission.UpdatePermission(this.PermissionID, this.PermissionName);
        }

        public static clsPermission GetPermissionByID(int PermissionID)
        {
            string PermissionName = "";
            if (clsDataPermission.GetPermissionByID(PermissionID, ref PermissionName))
                return new clsPermission(PermissionID, PermissionName);
            return null;
        }

        public static clsPermission GetPermissionByName(string PermissionName)
        {
            int PermissionID = -1;
            if (clsDataPermission.GetPermissionByName(PermissionName, ref PermissionID))
                return new clsPermission(PermissionID, PermissionName);
            return null;
        }


        public static bool IsPermissionExist(int PermissionID)
            => clsDataPermission.IsPermissionExist(PermissionID);

        public static bool IsPermissionExist(string PermissionName)
            => clsDataPermission.IsPermissionExist(PermissionName);

        public static bool DeletePermission(int PermissionID)
            => clsDataPermission.DeletePermission(PermissionID);

        public static DataTable ListAllPermissions()
            => clsDataPermission.ListAllPermissions();



        public static List<string> GetAllPermissionsOfUser(int UserID)
            => clsDataPermission.GetAllPermissionsOfUser(UserID);

        public static bool SetPermissionsForUser(int UserID, List<string> PermissionNames)
            => clsDataPermission.SetPermissionsForUser(UserID, PermissionNames);

        public static bool AddPermissionToUser(int UserID, string PermissionName)
            => clsDataPermission.AddPermissionToUser(UserID, PermissionName);

        public static bool RemovePermissionFromUser(int UserID, string PermissionName)
            => clsDataPermission.RemovePermissionFromUser(UserID, PermissionName);

        public static bool UserHasPermission(int UserID, enPermissions Permission)
            => clsDataPermission.UserHasPermission(UserID, Permission.ToString());

        // SAVE

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Create: return _AddNewPermission();
                case enMode.Update: return _UpdatePermission();
            }
            return false;
        }
    }
}