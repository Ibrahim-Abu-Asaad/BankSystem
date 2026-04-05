using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsRole
    {

        public int ID { get; set; }
        public string RoleName { get; set; }
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        public clsRole()
        {
            this.ID = -1;
            this.RoleName = "";
            Mode = enMode.AddNew;
        }

        private clsRole(int ID, string RoleName)
        {
            this.ID = ID;
            this.RoleName = RoleName;
            Mode = enMode.Update;
        }

        public static DataTable ListAllRoles()
            => clsDataRole.ListAllRoles();

        public static DataTable ListAllRolesWithoutAdmin()
            => clsDataRole.ListAllRolesWithoutAdmin();
        public static bool HasPermission(int ID, int PermissionID)
            => clsDataRole.HasPermission(ID, PermissionID);

        public static int GetRoleIDByRoleName(string RoleName)
            => clsDataRole.GetRoleIDByRoleName(RoleName);

        public static string GetRoleNameByRoleID(int ID)
            => clsDataRole.GetRoleNameByRoleID(ID);

        public static bool Find(int ID)
            => clsDataRole.GetRoleNameByRoleID(ID) != null;
                   
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRole())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateRole();
            }

            return false;
        }

        private bool _AddNewRole()
            => clsDataRole.AddNewRole(this.RoleName) != -1;


        private bool _UpdateRole()
            => clsDataRole.UpdateRole(this.ID, this.RoleName);


        public static bool DeleteRole(int ID)
            => clsDataRole.DeleteRole(ID);

        public static DataTable GetPermissionsByRoleID(int RoleID)
            => clsDataRole.GetRolePermissions(RoleID);
















    }
}
