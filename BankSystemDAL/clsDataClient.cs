using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataClient
    {

        private static string ConnectionString = clsDataAccessSettings.ConnectionString;

        public static DataTable ListAllClients()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"SELECT * FROM Clients";

            string query = @"SELECT Clients.ID, Persons.Name, Countries.Name AS Country, Clients.AccountNO, Clients.Balance, Currencies.Name AS 'Currency Name', Currencies.Code
                             FROM Persons INNER JOIN
                             Clients ON Persons.ID = Clients.PersonID INNER JOIN
                             Countries ON Persons.CountryID = Countries.ID INNER JOIN
                             Currencies ON Clients.CurrencyID = Currencies.ID
                             WHERE MarkDeleted = 0";


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

        public static DataTable ListAllClientsWithoutThisClient(int ClientID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"SELECT * FROM Clients";

            string query = @"SELECT Clients.ID, Persons.Name, Countries.Name AS Country, Clients.AccountNO, Clients.Balance, Currencies.Name AS 'Currency Name', Currencies.Code
                             FROM Persons INNER JOIN
                             Clients ON Persons.ID = Clients.PersonID INNER JOIN
                             Countries ON Persons.CountryID = Countries.ID INNER JOIN
                             Currencies ON Clients.CurrencyID = Currencies.ID
                             WHERE MarkDeleted = 0 AND Clients.ID != @ClientID";


            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", ClientID);

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

        public static bool IsClientExist(string AccountNO, string PINcode)
        {

            bool IsClientExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Clients WHERE AccountNO = @AccountNO AND PINcode = @PINcode";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);
            command.Parameters.AddWithValue("@PINcode", PINcode);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null)
                    IsClientExist = true;

            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsClientExist;

        }

        public static bool IsClientExist(string AccountNO)
        {

            bool IsClientExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Clients WHERE AccountNO = @AccountNO";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null)
                    IsClientExist = true;

            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsClientExist;
        }

        public static bool IsClientExist(int ID)
        {
            bool IsClientExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT Found=1 FROM Clients WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                object obj = command.ExecuteScalar();
                if (obj != null)
                    IsClientExist = true;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsClientExist;
        }


        public static bool GetClientByClientID(ref int PersonID, ref string Name, ref string Email,
            ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID,
            ref string Phone, ref int MarkDeleted, ref string Gender, int ID, ref string AccountNO,
            ref string PINcode, ref decimal Balance, ref int CurrencyID)
        {

            bool IsFoundClient = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT c.ID, c.AccountNO, c.PINcode, c.Balance, c.CurrencyID, c.CreatedAt, c.PersonID,
                                    p.Name, p.Email, p.BirthDate, p.Address, p.ImagePath,
                                    p.CountryID, p.Phone, p.MarkDeleted, p.Gender
                             FROM Clients c
                             INNER JOIN Persons p ON c.PersonID = p.ID
                             WHERE c.ID = @ID AND p.MarkDeleted = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFoundClient = true;

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

                    AccountNO = reader["AccountNO"].ToString();
                    PINcode = reader["PINcode"].ToString();
                    Balance = (decimal)reader["Balance"];
                    CurrencyID = (int)reader["CurrencyID"];
                    //CreatedAt = (reader["CreatedAt"] != DBNull.Value) ? (DateTime)reader["CreatedAt"] : DateTime.Now;
                }
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsFoundClient;
        }

        public static bool GetClientByAccountNO(ref int PersonID, ref string Name, ref string Email,
            ref DateTime BirthDate, ref string Address, ref string ImagePath, ref int CountryID,
            ref string Phone, ref int MarkDeleted, ref string Gender, ref int ID, string AccountNO,
            ref string PINcode, ref decimal Balance, ref int CurrencyID)
        {

            bool IsFoundClient = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT c.ID, c.AccountNO, c.PINcode, c.Balance, c.CurrencyID, c.CreatedAt, c.PersonID,
                                    p.Name, p.Email, p.BirthDate, p.Address, p.ImagePath,
                                    p.CountryID, p.Phone, p.MarkDeleted, p.Gender
                             FROM Clients c
                             INNER JOIN Persons p ON c.PersonID = p.ID
                             WHERE c.AccountNO = @AccountNO AND c.MarkDeleted = 0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFoundClient = true;

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

                    AccountNO = reader["AccountNO"].ToString();
                    PINcode = reader["PINcode"].ToString();
                    Balance = (decimal)reader["Balance"];
                    CurrencyID = (int)reader["CurrencyID"];
                    //CreatedAt = (reader["CreatedAt"] != DBNull.Value) ? (DateTime)reader["CreatedAt"] : DateTime.Now;
                }
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return IsFoundClient;
        }

        public static int GetClientCount()
        {
            int ClientCount = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT COUNT(Clients.ID)
                             FROM Clients INNER JOIN
                             Persons ON Clients.PersonID = Persons.ID
                             WHERE Persons.MarkDeleted = 0";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int Count))
                    ClientCount = Count;
            }
            catch (Exception ex) { string errorMessage = ex.Message; }
            finally { connection.Close(); }

            return ClientCount;
        }

        public static bool CheckIfPINcodeRight(int ClientID, string PINcode)
        {
            bool IsPasswordRight = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Clients WHERE PINcode = @PINcode AND ID = @ClientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PINcode", PINcode);
            command.Parameters.AddWithValue("@ClientID", ClientID);

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

        public static bool IsAccountExist(string AccountNO)
        {
            bool IsExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT 1 FROM Clients WHERE AccountNO = @AccountNO";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);

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

        //public static bool IsAccountExist(string AccountNO, int ClientID)
        //{
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT 1 FROM Clients WHERE AccountNO = @AccountNO AND ID != ClientID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@AccountNO", AccountNO);
        //    command.Parameters.AddWithValue("@ClientID", ClientID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //            IsExist = true;
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return IsExist;
        //}

        //public static bool IsEmailExist(string Email)
        //{
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT 1 FROM Persons WHERE Email = @Email";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Email", Email);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //            IsExist = true;
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return IsExist;
        //}

        //public static bool IsEmailExist(string Email, int PersonID)
        //{
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT 1 FROM Persons WHERE Email = @Email AND ID != @PersonID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Email", Email);
        //    command.Parameters.AddWithValue("@PersonID", PersonID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //            IsExist = true;
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return IsExist;
        //}

        //public static bool IsPhoneExist(string Phone)
        //{
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT 1 FROM Persons WHERE Phone = @Phone";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Phone", Phone);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //            IsExist = true;
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return IsExist;
        //}

        //public static bool IsPhoneExist(string Phone, int PersonID)
        //{
        //    bool IsExist = false;

        //    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        //    string query = "SELECT 1 FROM Persons WHERE Phone = @Phone AND ID != @PersonID";

        //    SqlCommand command = new SqlCommand(query, connection);
        //    command.Parameters.AddWithValue("@Phone", Phone);
        //    command.Parameters.AddWithValue("@PersonID", PersonID);

        //    try
        //    {
        //        connection.Open();
        //        SqlDataReader reader = command.ExecuteReader();
        //        if (reader.HasRows)
        //            IsExist = true;
        //    }
        //    catch (Exception ex) { string errorMessage = ex.Message; }
        //    finally { connection.Close(); }

        //    return IsExist;
        //}



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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

        public static int AddNewClient(string Name, string Email, DateTime BirthDate, string Address,
            string ImagePath, int CountryID, string Phone, string Gender,
            string AccountNO, string PINcode, decimal Balance, int CurrencyID)
        {
            int PersonID = _AddInfoInPersonTable(Name, Email, BirthDate, Address, ImagePath, CountryID, Phone, Gender);

            if (PersonID == -1) return -1;

            int ClientID = -1;



            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Clients (AccountNO, PINcode, PersonID, Balance, CurrencyID)
                             VALUES (@AccountNO, @PINcode, @PersonID, @Balance, @CurrencyID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);
            command.Parameters.AddWithValue("@PINcode", PINcode);
            command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Balance;
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedClient))
                    ClientID = insertedClient;
            }
            catch (Exception ex) { string message = ex.Message; }
            finally { connection.Close(); }

            return ClientID;
        }


        public static bool UpdateClient(int PersonID, string Name, string Email, DateTime BirthDate,
            string Address, string ImagePath, int CountryID, string Phone, string Gender,
            int ClientID, string AccountNO, string PINcode, decimal Balance, int CurrencyID)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Persons
                             SET [Name] = @Name, [Email] = @Email, [BirthDate] = @BirthDate,
                                 [Address] = @Address, [ImagePath] = @ImagePath, [Phone] = @Phone,
                                 [MarkDeleted] = 0, [CountryID] = @CountryID, [Gender] = @Gender
                             WHERE ID = @PersonID;
                             UPDATE Clients
                             SET [AccountNO] = @AccountNO, [PINcode] = @PINcode,
                                 [PersonID] = @PersonID, [Balance] = @Balance, [CurrencyID] = @CurrencyID
                             WHERE ID = @ClientID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@ImagePath", (object)ImagePath ?? DBNull.Value);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@AccountNO", AccountNO);
            command.Parameters.AddWithValue("@PINcode", PINcode);
            command.Parameters.Add("@Balance", SqlDbType.Decimal).Value = Balance;
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                IsUpdated = true;
            }
            catch (Exception ex) { string message = ex.Message; }
            finally { connection.Close(); }

            return IsUpdated;
        }

        public static bool DeleteClient(int ID)
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
