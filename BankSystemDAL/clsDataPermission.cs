using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDAL
{
    public class clsDataPermission
    {
        private static string _connectionString = clsDataAccessSettings.ConnectionString;


        public static bool GetPermissionNameByID(int ID, ref string PermissionName)
        {

            bool IsPermissionOfThisIDExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT PermissionName FROM Permissions WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null)
                {
                    IsPermissionOfThisIDExist = true;
                    PermissionName = result.ToString();
                }
                    

            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return IsPermissionOfThisIDExist;


        }

        public static int GetPermissionIDByName(string PermissionName)
        {

            int ID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ID
                            FROM Permissions
                            WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {

                connection.Open();

                object result = command.ExecuteScalar();

                if (ID != -1 && int.TryParse(result.ToString(),out int IDofPermission))
                    ID = IDofPermission;



            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return ID;





        }

        public static int AddNewPermission(string PermissionName)
        {
            int PermissionID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Permissions (PermissionName)
                             VALUES (@PermissionName);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionName", PermissionName);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PermissionID = insertedID;
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return PermissionID;
        }

        public static bool UpdatePermission(int ID, string PermissionName)
        {

            bool isUpdated = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" UPDATE Permissions
        SET PermissionName = @PermissionName
        WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@PermissionName", PermissionName);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isUpdated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return isUpdated;

        }

        public static bool DeletePermission(int ID)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "DELETE FROM Permissions WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isDeleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
        }

        public static bool IsPermissionExist(int ID)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(*) FROM Permissions WHERE ID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                isExist = count > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }

        public static bool IsPermissionExist(string PermissionName)
        {
            bool isExist = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT COUNT(*) FROM Permissions WHERE PermissionName = @PermissionName";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PermissionName", PermissionName);

            try
            {
                connection.Open();
                int count = Convert.ToInt32(command.ExecuteScalar());
                isExist = count > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return isExist;
        }

        public static DataTable ListAllPermissions()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID, PermissionName FROM Permissions";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        





    }
}
