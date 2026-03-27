using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static int IsUserExist(string Username)
        {

            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT UserID FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);



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

        public static bool IsUserExist(int UserID)
        {

            //int UserID = -1;
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE UserID = @UserID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);



            try
            {

                connection.Open();
                object obj = command.ExecuteScalar();

                if (obj != null)
                    IsExist = true;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }
            return IsExist;
        }

        public static bool GetUserByUserID(ref int PersonID, ref string Name, ref string Email, ref DateTime BirthDate, ref string Address, ref string ImagePath, ref string Country, ref string Phone, int UserID, ref string Username, ref string Password, ref int Permissions, ref DateTime LastLogin)
        {

            //int UserID = -1;
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID, Users.Username, Users.Password, Users.Permissions, Users.LastLogin, Users.PersonID,
                             Persons.Name, Persons.Email, Persons.BirthDate , Persons.Address, Persons.ImagePath, Persons.Country, Persons.Phone
                             FROM Persons INNER JOIN Users ON Persons.PersonID = Users.PersonID 
                             WHERE Users.UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFoundUser = true;

                    PersonID = (int)reader["PersonID"];
                    Name = reader["Name"].ToString();
                    Email = reader["Email"].ToString();
                    BirthDate = (reader["BirthDate"] != DBNull.Value) ? (DateTime)reader["BirthDate"] : DateTime.MinValue;
                    Address = (reader["Address"] != DBNull.Value) ? reader["Address"].ToString() : "";
                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? reader["ImagePath"].ToString() : "";
                    Country = (reader["Country"] != DBNull.Value) ? reader["Country"].ToString() : "";
                    Phone = (reader["Phone"] != DBNull.Value) ? reader["Phone"].ToString() : "";

                    Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    Permissions = (int)reader["Permissions"];
                    LastLogin = (reader["LastLogin"] != DBNull.Value) ? (DateTime)reader["LastLogin"] : DateTime.MinValue;

                }


            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return IsFoundUser;



        }

        public static bool GetUserByUsername(ref int PersonID, ref string Name, ref string Email, ref DateTime BirthDate, ref string Address, ref string ImagePath, ref string Country, ref string Phone, ref int UserID, string Username, ref string Password, ref int Permissions, ref DateTime LastLogin)
        {

            //int UserID = -1;
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID, Users.Username, Users.Password, Users.Permissions, Users.LastLogin, Users.PersonID,
                             Persons.Name, Persons.Email, Persons.BirthDate , Persons.Address, Persons.ImagePath, Persons.Country, Persons.Phone
                             FROM Persons INNER JOIN Users ON Persons.PersonID = Users.PersonID 
                             WHERE Users.Username = @Username;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);



            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    IsFoundUser = true;

                    PersonID = (int)reader["PersonID"];
                    Name = reader["Name"].ToString();
                    Email = reader["Email"].ToString();
                    BirthDate = (reader["BirthDate"] != DBNull.Value) ? (DateTime)reader["BirthDate"] : DateTime.MinValue;
                    Address = (reader["Address"] != DBNull.Value) ? reader["Address"].ToString() : "";
                    ImagePath = (reader["ImagePath"] != DBNull.Value) ? reader["ImagePath"].ToString() : "";
                    Country = (reader["Country"] != DBNull.Value) ? reader["Country"].ToString() : "";
                    Phone = (reader["Phone"] != DBNull.Value) ? reader["Phone"].ToString() : "";

                    UserID = (int)reader["UserID"];
                    //Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    Permissions = (int)reader["Permissions"];
                    LastLogin = (reader["LastLogin"] != DBNull.Value) ? (DateTime)reader["LastLogin"] : DateTime.MinValue;

                }


            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return IsFoundUser;



        }

        public static DataTable ListUsers()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.UserID, Users.Username, Users.Password, Users.Permissions, Users.LastLogin,
                             Persons.Name, Persons.Email, Persons.Country, Persons.Phone
                             FROM Persons INNER JOIN Users ON Persons.PersonID = Users.PersonID";

            SqlCommand command = new SqlCommand(query, connection);



            try
            {

                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                
                adapter.Fill(dt);
                

            }
            catch (Exception ex)
            {
                
                string errorMessage = ex.Message;
                
            }
            finally
            {

                connection.Close();

            }

            return dt;

        }

        public static void UpdateLastLogin(int UserID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET LastLogin = GETDATE() WHERE UserID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                connection.Open();
                command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

        }

        public static int GetUserCount()
        {

            int UserCount = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*) FROM Users";
            
            SqlCommand command = new SqlCommand(query, connection);


            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                    UserCount = Count;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return UserCount;

        }

        public static int GetAdminCount()
        {

            int AdminCount = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(*) FROM Users WHERE Permissions = 31";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                    AdminCount = Count;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return AdminCount;

        }

        public static bool CheckIfPasswordRight(int UserID, string Password)
        {

            bool IsPasswordRight = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 1 FROM Users WHERE Password = @Password AND UserID = @UserID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@UserID", UserID);



            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                    IsPasswordRight = true;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return IsPasswordRight;



        }







    }






    
}
