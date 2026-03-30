using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataPermission
    {

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
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return IsPermissionLevelExist;


        }

        public static int AddNewPermission(int PermissionLevel)
        {

            int PermissionID = -1;
            int RoleID = -1;

            if (PermissionLevel == 31)
                RoleID = 1;
            else RoleID = 2;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [Permissions] (PermissionLevel, RoleID) VALUES (@PermissionLevel,@RoleID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionLevel", PermissionLevel);
            command.Parameters.AddWithValue("@RoleID", RoleID);

            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedPermission))
                    PermissionID = insertedPermission;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return PermissionID;

        }

        public static int GetPermissionIDByPermissionLevel(int PermissionLevel)
        {

            int PermissionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID FROM [Permissions] WHERE PermissionLevel = @PermissionLevel";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionLevel", PermissionLevel);

            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedPermission))
                    PermissionID = insertedPermission;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return PermissionID;

        }

        public static int GetPermissionLevelByPermissionID(int PermissionID)
        {

            int PermissionLevel = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PermissionLevel FROM [Permissions] WHERE ID = @PermissionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionID", PermissionID);

            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedPermission))
                    PermissionLevel = insertedPermission;


            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                connection.Close();
            }


            return PermissionLevel;

        }


        /*
         
        
         
         */

        /*
         
         
        -- Step 1: Insert General Information
                   INSERT INTO Persons (Name, Email, BirthDate, Address, Phone, MarkDeleted, CountryID)
                   VALUES ('John Doe', 'john@example.com', '1995-01-01', 'Amman', '0791234567', 0, 194);

        -- Step 2: Insert Permissions (Assuming RoleID 2 is 'User')
                   INSERT INTO [Permissions] (PermissionLevel, RoleID)
                   VALUES (31, 2); 

        -- Step 3: Insert Login Credentials 
        -- (Using ID 7 assuming it's the next ID generated from the steps above)
                   INSERT INTO Users (Username, Password, LastLogin, PersonID, PermissionID)
                   VALUES ('john_d', 'pass123', GETDATE(), 7, 7);
         
         
         */




    }
}
