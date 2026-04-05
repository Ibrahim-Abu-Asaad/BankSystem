using System;
using System.Collections.Generic;
using System.Data;
using BankSystemDAL;
using static BankSystemBLL.clsUser;

namespace BankSystemBLL
{
    public class clsPermission
    {

        public int ID { get; set; }
        public string PermissionName { get; set; }

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

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

            LoginsRegister_AccessPage,

            RolesAndPermissions_AccessPage,

            Role_Create,
            Role_Edit,
            Role_Delete,
            
            Permission_Create,
            Permission_Edit,
            Permission_Delete,



        }

        //  Constructors

        public clsPermission()
        {
            this.ID = -1;
            this.PermissionName = "";
            Mode = enMode.AddNew;
        }

        private clsPermission(int ID, string PermissionName)
        {
            this.ID = ID;
            this.PermissionName = PermissionName;
            Mode = enMode.Update;
        }

        // Private 

        private bool _AddNewPermission()
        {
            this.ID = clsDataPermission.AddNewPermission(this.PermissionName);
            return this.ID != -1;
        }

        private bool _UpdatePermission()
            => clsDataPermission.UpdatePermission(this.ID, this.PermissionName);

        


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPermission())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePermission();
            }

            return false;
        }

        public static bool DeletePermission(int ID)
            => clsDataPermission.DeletePermission(ID);

        public static int GetPermissionIDByName(string PermissionName)
            => clsDataPermission.GetPermissionIDByName(PermissionName);

        public static bool GetPermissionNameByID(int ID, ref string PermissionName)
            => clsDataPermission.GetPermissionNameByID(ID, ref PermissionName);

        public static bool IsPermissionExist(int PermissionID)
            => clsDataPermission.IsPermissionExist(PermissionID);

        public static bool IsPermissionExist(string PermissionName)
            => clsDataPermission.IsPermissionExist(PermissionName);

        public static DataTable ListAllPermissions()
            => clsDataPermission.ListAllPermissions();

        public static DataTable GetAllPermissionsWithoutRolePermissions()
            => clsDataPermission.GetAllPermissionsWithoutRolePermissions();



        public static bool UpdateRolePermissions(int RoleID, List<int> SelectedPermissionIDs)
        {
            if (clsDataPermission.DeleteAllRolePermissions(RoleID))
            {
                if (SelectedPermissionIDs.Count == 0) return true;

                foreach (int PermissionID in SelectedPermissionIDs)
                {
                    if (!clsDataPermission.AddPermissionToRole(RoleID, PermissionID))
                        return false;
                }
                return true;
            }
            return false;
        }

    }
}