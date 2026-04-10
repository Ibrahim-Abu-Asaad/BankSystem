using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDAL
{
    public class clsDataUser
    {

        public static int IsUserExist(string Username, string Password)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID FROM Users WHERE Username = @Username AND Password = @Password";

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return ID;
        }

        public static int IsUserExist(string Username)
        {
            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null && int.TryParse(obj.ToString(), out int UserIDFound))
                    ID = UserIDFound;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return ID;
        }

        public static bool IsUserExist(int ID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null)
                    IsExist = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }


        public static bool GetUserByUserID(ref int PersonID, ref string Name, ref string Email,
            ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID,
            ref string Phone, ref int MarkDeleted, ref string Gender, int ID, ref string Username,
            ref string Password, ref int RoleID, ref DateTime LastLogin)
        {
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT u.ID, u.Username, u.Password, u.RoleID, u.LastLogin, u.PersonID,
                                    p.Name, p.Email, p.BirthDate, p.Address, p.ImagePath,
                                    p.CountryID, p.Phone, p.MarkDeleted, p.Gender
                             FROM Users u
                             INNER JOIN Persons p ON u.PersonID = p.ID
                             WHERE u.ID = @ID";

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
                    Gender = reader["Gender"].ToString();

                    Username = reader["Username"].ToString();
                    Password = reader["Password"].ToString();
                    RoleID = (int)reader["RoleID"];
                    LastLogin = (reader["LastLogin"] != DBNull.Value) ? (DateTime)reader["LastLogin"] : DateTime.MinValue;
                }
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsFoundUser;
        }


        public static bool GetUserByUsername(ref int PersonID, ref string Name, ref string Email,
            ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID,
            ref string Phone, ref int MarkDeleted, ref string Gender, ref int ID, string Username,
            ref string Password, ref int RoleID, ref DateTime LastLogin)
        {
            bool IsFoundUser = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT u.ID, u.Username, u.Password, u.RoleID, u.LastLogin, u.PersonID,
                                    p.Name, p.Email, p.BirthDate, p.Address, p.ImagePath,
                                    p.CountryID, p.Phone, p.MarkDeleted, p.Gender
                             FROM Users u
                             INNER JOIN Persons p ON u.PersonID = p.ID
                             WHERE u.Username = @Username AND p.MarkDeleted = 0";

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
                    Gender = reader["Gender"].ToString();

                    ID = (int)reader["ID"];
                    Password = reader["Password"].ToString();
                    RoleID = (int)reader["RoleID"];
                    LastLogin = (reader["LastLogin"] != DBNull.Value) ? (DateTime)reader["LastLogin"] : DateTime.MinValue;
                }
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsFoundUser;
        }


        public static DataTable ListUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT u.ID, u.Username, u.LastLogin,
                                    p.Name, c.Name AS Country, r.RoleName
                             FROM Users u
                             INNER JOIN Persons p ON u.PersonID = p.ID
                             INNER JOIN Countries c ON p.CountryID = c.ID
                             INNER JOIN Roles r ON u.RoleID = r.ID
                             WHERE p.MarkDeleted = 0";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return dt;
        }

        public static DataTable ListUsersWithoutAdmin()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT u.ID, u.Username, u.LastLogin AS 'Last Login',
                                    p.Name, c.Name AS Country, r.RoleName AS Role
                             FROM Users u
                             INNER JOIN Persons p ON u.PersonID = p.ID
                             INNER JOIN Countries c ON p.CountryID = c.ID
                             INNER JOIN Roles r ON u.RoleID = r.ID
                             WHERE p.MarkDeleted = 0 AND RoleName != 'Admin'";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return dt;



        }


        public static DataTable ListLoginsRegister()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT lr.Date, u.Username, r.RoleName AS Role, p.Name
                             FROM LoginsRegister lr
                             INNER JOIN Users u ON lr.UserID = u.ID
                             INNER JOIN Persons p ON u.PersonID = p.ID
                             INNER JOIN Roles r ON u.RoleID = r.ID";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }
        }

        public static int GetUserCount()
        {
            int UserCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(Users.ID)
                             FROM Users INNER JOIN
                             Persons ON Users.PersonID = Persons.ID
                             WHERE Persons.MarkDeleted = 0 AND Users.RoleID != 3";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                    UserCount = Count;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return UserCount;
        }

        public static int GetAdminCount()
        {
            int AdminCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"SELECT COUNT(*)
            //                 FROM Users u
            //                 INNER JOIN Roles r ON u.RoleID = r.ID
            //                 WHERE LOWER(r.RoleName) = 'admin' AND ";

            string query = @"SELECT COUNT(Users.ID)
                              FROM Users INNER JOIN
                              Roles ON Users.RoleID = Roles.ID INNER JOIN
                              Persons ON Users.PersonID = Persons.ID
                              WHERE LOWER(Roles.RoleName) = 'admin' AND Persons.MarkDeleted = 0";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                    AdminCount = Count;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return AdminCount;
        }

        public static bool CheckIfPasswordRight(int UserID, string Password)
        {
            bool IsPasswordRight = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE Password = @Password AND ID = @UserID";

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsPasswordRight;
        }

        public static bool IsAdmin(int ID)
        {
            bool IsAdmin = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LOWER(r.RoleName)
                             FROM Users u
                             INNER JOIN Roles r ON u.RoleID = r.ID
                             WHERE u.ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && result.ToString() == "admin")
                    IsAdmin = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsAdmin;
        }

        public static bool IsUsernameExist(string Username)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE Username = @Username";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", Username);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    IsExist = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        public static bool IsUsernameExist(string Username, int UserID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Users WHERE Username = @Username AND ID != @UserID";

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        public static bool IsEmailExist(string Email)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Persons WHERE Email = @Email";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", Email);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    IsExist = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        public static bool IsEmailExist(string Email, int PersonID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Persons WHERE Email = @Email AND ID != @PersonID";

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        public static bool IsPhoneExist(string Phone)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Persons WHERE Phone = @Phone";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Phone", Phone);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    IsExist = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        public static bool IsPhoneExist(string Phone, int PersonID)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Persons WHERE Phone = @Phone AND ID != @PersonID";

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
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsExist;
        }

        //public static DataTable GetAllCountries()
        //{
        //    DataTable dt = new DataTable();

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT ID, Name FROM Countries";

        //    SqlCommand command = new SqlCommand(query, connection);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataAdapter adapter = new SqlDataAdapter(command);
        //        adapter.Fill(dt);
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return dt;
        //}

        private static int _AddInfoInPersonTable(string Name, string Email, DateTime BirthDate,
            string Address, string ImagePath, int CountryID, string Phone, string Gender)
        {
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Persons (Name, Email, BirthDate, Address, ImagePath, Phone, MarkDeleted, CountryID, Gender)
                             VALUES (@Name, @Email, @BirthDate, @Address, @ImagePath, @Phone, 0, @CountryID, @Gender);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Gender", Gender);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedPerson))
                    PersonID = insertedPerson;
            }
            catch (Exception ex) { string message = ex.Message; }
            finally { connection.Close(); }

            return PersonID;
        }

        public static int AddNewUser(string Name, string Email, DateTime BirthDate, string Address,
            string ImagePath, int CountryID, string Phone, string Gender,
            string Username, string Password, int RoleID)
        {
            int PersonID = _AddInfoInPersonTable(Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, Gender);
            int UserID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Users (Username, Password, PersonID, RoleID)
                             VALUES (@Username, @Password, @PersonID, @RoleID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedUser))
                    UserID = insertedUser;
            }
            catch (Exception ex) { string message = ex.Message; }
            finally { connection.Close(); }

            return UserID;
        }

        public static bool UpdateUser(int PersonID, string Name, string Email, DateTime BirthDate,
            string Address, string ImagePath, int CountryID, string Phone, string Gender,
            int UserID, string Username, string Password, int RoleID)
        {

            //bool IsUpdated = false;

            //SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            //string query = @"UPDATE Persons
            //                 SET [Name] = @Name, [Email] = @Email, [BirthDate] = @BirthDate,
            //                     [Address] = @Address, [ImagePath] = @ImagePath, [Phone] = @Phone,
            //                     [MarkDeleted] = 0, [CountryID] = @CountryID, [Gender] = @Gender
            //                 WHERE ID = @PersonID;
            //                 UPDATE Users
            //                 SET [Username] = @Username, [Password] = @Password,
            //                     [PersonID] = @PersonID, [RoleID] = @RoleID
            //                 WHERE ID = @UserID;";

            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@PersonID", PersonID);
            //command.Parameters.AddWithValue("@Name", Name);
            //command.Parameters.AddWithValue("@Email", Email);
            //command.Parameters.AddWithValue("@BirthDate", BirthDate);
            //command.Parameters.AddWithValue("@Address", Address);
            //command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            //command.Parameters.AddWithValue("@Phone", Phone);
            //command.Parameters.AddWithValue("@CountryID", CountryID);
            //command.Parameters.AddWithValue("@Gender", Gender);
            //command.Parameters.AddWithValue("@UserID", UserID);
            //command.Parameters.AddWithValue("@Username", Username);
            //command.Parameters.AddWithValue("@Password", Password);
            //command.Parameters.AddWithValue("@RoleID", RoleID);

            //try
            //{
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    IsUpdated = true;
            //}
            //catch (Exception ex) { string message = ex.Message; }
            //finally { connection.Close(); }

            //return IsUpdated;


            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            // ✅ Step 1: Build query dynamically
            string query = @"UPDATE Persons
                     SET [Name] = @Name, [Email] = @Email, [BirthDate] = @BirthDate,
                         [Address] = @Address, [ImagePath] = @ImagePath, [Phone] = @Phone,
                         [MarkDeleted] = 0, [CountryID] = @CountryID, [Gender] = @Gender
                     WHERE ID = @PersonID;

                     UPDATE Users
                     SET [Username] = @Username, ";

            // ✅ Step 2: Only update password if provided
            if (!string.IsNullOrEmpty(Password))
            {
                query += "[Password] = @Password, ";
            }

            query += @"[PersonID] = @PersonID, [RoleID] = @RoleID
               WHERE ID = @UserID;";

            SqlCommand command = new SqlCommand(query, connection);

            // Parameters
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@Username", Username);

            // ✅ Add password param ONLY if used
            if (!string.IsNullOrEmpty(Password))
            {
                command.Parameters.AddWithValue("@Password", Password);
            }

            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
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

        public static bool DeleteUser(int ID)
        {
            bool IsDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "UPDATE Persons SET MarkDeleted = 1 WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                    IsDeleted = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsDeleted;
        }



    }
}

