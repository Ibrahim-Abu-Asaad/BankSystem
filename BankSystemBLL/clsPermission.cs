using System;
using System.Collections.Generic;
using System.Data;
using BankSystemDAL;

namespace BankSystemBLL
{
    public class clsPermission
    {

        public int ID { get; set; }
        public string PermissionName { get; set; }

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
            this.ID = -1;
            this.PermissionName = "";
        }

        private clsPermission(int ID, string PermissionName)
        {
            this.ID = ID;
            this.PermissionName = PermissionName;
        }

        // Private 

        private bool _AddNewPermission()
        {
            this.ID = clsDataPermission.AddNewPermission(this.PermissionName);
            return this.ID != -1;
        }

        private bool _UpdatePermission()
            => clsDataPermission.UpdatePermission(this.ID, this.PermissionName);

        public static bool _DeletePermission(int ID)
            => clsDataPermission.DeletePermission(ID);

        public static int GetPermissionIDByName(string PermissionName)
        {

            int ID = -1;

            if (clsDataPermission.GetPermissionIDByName(PermissionName) != -1)
                ID = clsDataPermission.GetPermissionIDByName(PermissionName);

            return ID;
        }


        public static bool IsPermissionExist(int PermissionID)
            => clsDataPermission.IsPermissionExist(PermissionID);

        public static bool IsPermissionExist(string PermissionName)
            => clsDataPermission.IsPermissionExist(PermissionName);

        public static DataTable ListAllPermissions()
            => clsDataPermission.ListAllPermissions();

    }
}