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

        public static DataTable ListAllRoles()
            => clsDataRole.ListAllRoles();

        //public enum enRoles
        //{

        //    Admin,
        //    AccountManager,
        //    FinanceManager,
        //    StandardUser

        //}

        //public static string Admin = "Admin";
        //public static string AccountManager = "Account Manager";
        //public static string FinanceManager = "Finance Manager";
        //public static string StandardUser = "Standard User";

        public static bool HasPermission(int ID, int PermissionID)
            => clsDataRole.HasPermission(ID, PermissionID);

        public static int GetRoleIDByRoleName(string RoleName)
            => clsDataRole.GetRoleIDByRoleName(RoleName);

        public static string GetRoleNameByID(int ID)
            => clsDataRole.GetRoleNameByID(ID);


    }
}
