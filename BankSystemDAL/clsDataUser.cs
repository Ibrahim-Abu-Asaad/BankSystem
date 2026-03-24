using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataUser
    {
        
        // This Function Make Sure That The User Is Exist And If Exist It return His ID , Otherwise It Return -1
        public static int IsUserExist(string Username, string Password)
        {

            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT UserID FROM Users WHERE Username = @Username AND Password = @Password";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);



            try
            {

                connection.Open();
                object obj = command.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int UserIDFound))
                    UserID = UserIDFound;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return UserID;



        }



    }
}
