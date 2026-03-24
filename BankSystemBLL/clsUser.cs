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

        int UserID { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        int Permissions { get; set; }
        DateTime LastLogin { get; set; }


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
            //base();

        }

        private clsUser(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, string Country, string Username, string Password, int Permissions, DateTime LastLogin) : base(Name, Email, BirthDate, Address, ImagePath, Country)
        {

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





    }
}
