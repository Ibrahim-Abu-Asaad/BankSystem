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

            int ID = -1;

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
                    ID = UserIDFound;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }
            return ID;
        }

        public static int IsUserExist(string Username)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT UserID FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);



            try
            {

                connection.Open();
                object obj = command.ExecuteScalar();

                if (obj != null && int.TryParse(obj.ToString(), out int UserIDFound))
                    ID = UserIDFound;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }
            return ID;
        }

        public static bool IsUserExist(int ID)
        {

            //int UserID = -1;
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE ID = @ID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);



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

        public static bool GetUserByUserID(ref int PersonID, ref string Name, ref string Email, ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID, ref string Phone, ref int MarkDeleted, int ID, ref string Username, ref string Password, ref int PermissionID, ref DateTime LastLogin)
        {

            //int UserID = -1;
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.ID, Users.Username, Users.Password, Users.PermissionID, Users.LastLogin, Users.PersonID,
                             Persons.Name, Persons.Email, Persons.BirthDate , Persons.Address, Persons.ImagePath, Persons.CountryID, Persons.Phone, Persons.MarkDeleted
                             FROM Persons INNER JOIN Users ON Persons.ID = Users.PersonID 
                             WHERE Users.ID = @ID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            

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
                    CountryID = (int)reader["CountryID"];
                    Phone = (reader["Phone"] != DBNull.Value) ? reader["Phone"].ToString() : "";
                    MarkDeleted = (int)reader["MarkDeleted"];

                    Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    PermissionID = (int)reader["PermissionID"];
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

        public static bool GetUserByUsername(ref int PersonID, ref string Name, ref string Email, ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID, ref string Phone, ref int MarkDeleted, ref int ID, string Username, ref string Password, ref int PermissionID, ref DateTime LastLogin)
        {

            // FINISH EDIT
            //int UserID = -1;
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Users.ID, Users.Username, Users.Password, Users.PermissionID, Users.LastLogin, Users.PersonID,
                             Persons.Name, Persons.Email, Persons.BirthDate , Persons.Address, Persons.ImagePath, Persons.CountryID, Persons.Phone, Persons.MarkDeleted
                             FROM Persons INNER JOIN Users ON Persons.ID = Users.PersonID 
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
                    CountryID = (int)reader["CountryID"];
                    Phone = (reader["Phone"] != DBNull.Value) ? reader["Phone"].ToString() : "";
                    MarkDeleted = (int)reader["MarkDeleted"];

                    ID = (int)reader["ID"];
                    //Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    PermissionID = (int)reader["PermissionID"];
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
            string query = @"SELECT Users.ID, Users.Username, Users.LastLogin, Persons.Name, Countries.Name AS Country, Roles.RoleName
                             FROM Users INNER JOIN
                             Persons ON Users.PersonID = Persons.ID INNER JOIN
                             Permissions ON Users.PermissionID = Permissions.ID INNER JOIN
                             Roles ON Permissions.RoleID = Roles.ID INNER JOIN
                             Countries ON Persons.CountryID = Countries.ID
                             WHERE Persons.MarkDeleted = 0";

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

        public static void UpdateLastLoginAndAddedItToLoginsRegister(int ID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Users SET LastLogin = GETDATE() WHERE ID = @ID;
                             INSERT INTO LoginsRegister ([Date], [UserID]) VALUES (GETDATE(), @ID);";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);



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

            int UserCount = 0;

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

            int AdminCount = 0;

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

        public static int GetPermissions(int PermissionID)
        {

            int PermissionLevel = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Permissions.PermissionLevel FROM Users INNER JOIN Permissions ON Users.PermissionID = Permissions.ID WHERE Permissions.ID = @PermissionID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);


            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int perLevel))
                    PermissionLevel = perLevel;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return PermissionLevel;

        }

        public static DataTable ListLoginsRegister()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LoginsRegister.Date, Users.Username, Roles.RoleName, Persons.Name FROM LoginsRegister INNER JOIN
                             Users ON LoginsRegister.UserID = Users.ID INNER JOIN
                             Persons ON Users.PersonID = Persons.ID INNER JOIN
                             Permissions ON Users.PermissionID = Permissions.ID INNER JOIN
                             Roles ON Permissions.RoleID = Roles.ID";

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

        public static bool DeleteUser(int ID)
        {

            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"UPDATE Persons SET Persons.MarkDeleted = 1 WHERE ID = @ID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {

                connection.Open();
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                    IsDeleted = true;

            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return IsDeleted;

        }

        public static bool IsAdmin(int ID)
        {

            bool IsAdmin = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT LOWER(Roles.RoleName)
                             FROM Users INNER JOIN
                             Permissions ON Users.PermissionID = Permissions.ID INNER JOIN
                             Roles ON Permissions.RoleID = Roles.ID
                             WHERE Users.ID = @ID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);


            try
            {

                connection.Open();
                object result = command.ExecuteScalar();

                string RoleName = result.ToString();
                if (RoleName == "admin")
                    IsAdmin = true;



            }
            catch (Exception ex)
            {

                string errorMessage = ex.Message;

            }
            finally
            {

                connection.Close();

            }

            return IsAdmin;

        }

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ID, Name FROM Countries";

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

        public static bool IsUsernameExist(string Username)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Users WHERE Username = @Username";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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
        public static bool IsUsernameExist(string Username, int UserID)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Users WHERE Username = @Username AND ID != @UserID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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


        public static bool IsEmailExist(string Email)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Persons WHERE Email = @Email";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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

        public static bool IsEmailExist(string Email, int PersonID)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Persons WHERE Email = @Email AND ID != @PersonID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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


        public static bool IsPhoneExist(string Phone)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Persons WHERE Phone = @Phone";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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

        public static bool IsPhoneExist(string Phone, int PersonID)
        {

            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"DELETE FROM Users WHERE ID = @ID";
            string query = @"SELECT 1 FROM Persons WHERE Phone = @Phone AND ID != @PersonID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
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

        public static bool IsPermissionLevelExist(int PermissionLevel)
        {

            bool IsPermissionLevelExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM [Permissions] WHERE PermissionLevel = @PermissionLevel";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionLevel", PermissionLevel);

            try
            {

                connection.Open();

                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected > 0)
                    IsPermissionLevelExist = true;



            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return IsPermissionLevelExist;


        }


        ///////////////////////////////////////////////////////

        // Add New User {INSERT}

        private static int _AddInfoInPersonTable(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, string Username, string Password, int PermissionID)
        {

            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Persons (Name, Email, BirthDate, Address, ImagePath, Phone, MarkDeleted, CountryID)
                             VALUES (@Name, @Email, @Birthdate, @Address, @ImagePath, @Phone, 0, @CountryID);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Birthdate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedPerson))
                    PersonID = insertedPerson;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return PersonID;

        }

        public static int AddNewUser(string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone, string Username, string Password, int PermissionID)
        {

            int PersonID = _AddInfoInPersonTable(Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, Username, Password, PermissionID);

            int UserID = -1;
            

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Users(Username, Password, PersonID, PermissionID)
                             VALUES(@Username, @Password, @PersonID, @PermissionID);
                             SELECT SCOPE_IDENTITY();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);


            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedUser))
                    UserID = insertedUser;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return UserID;

        }

        /*
         
         
         
         */

        private static bool _UpdateInfoInPersonTable(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone)
        {

            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Persons
                             SET [Name] = @Name
                             ,[Email] = @Email
                             ,[BirthDate] = @Birthdate
                             ,[Address] = @Address
                             ,[ImagePath] = @ImagePath
                             ,[Phone] = @Phone
                             ,[MarkDeleted] = 0
                             ,[CountryID] = @CountryID
                             WHERE ID = @PersonID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Birthdate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                    IsUpdated = true;




            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return IsUpdated;

        }


        public static bool UpdateUser(int PersonID, string Name, string Email, DateTime BirthDate, string Address, string ImagePath, int CountryID, string Phone,int UserID, string Username, string Password, int PermissionID)
        {

            //bool IsPersonUpdated = _UpdateInfoInPersonTable(PersonID, Name, Email, BirthDate, Address, ImagePath, CountryID, Phone);

            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = @"UPDATE Users
            //                 SET
            //                  [Username] = @Username
            //                 ,[Password] = @Password
            //                 ,[PersonID] = @PersonID
            //                 ,[PermissionID] = @PermissionID
            //                 WHERE ID = @UserID;";


            string query = @"UPDATE Persons
                             SET [Name] = @Name
                             ,[Email] = @Email
                             ,[BirthDate] = @BirthDate
                             ,[Address] = @Address
                             ,[ImagePath] = @ImagePath
                             ,[Phone] = @Phone
                             ,[MarkDeleted] = 0
                             ,[CountryID] = @CountryID
                             WHERE ID = @PersonID;
                             UPDATE Users
                             SET
                              [Username] = @Username
                             ,[Password] = @Password
                             ,[PersonID] = @PersonID
                             ,[PermissionID] = @PermissionID
                             WHERE ID = @UserID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);
           
            
            try
            {

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                //if (rowsAffected > 0)
                //    IsUpdated = true;
                IsUpdated = true;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return IsUpdated;

        }









    }

}
