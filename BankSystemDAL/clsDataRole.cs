using BankSystemDAL;
using System.Data.SqlClient;
using System.Data;
using System;

public class clsDataRole
{
    private static string ConnectionString = clsDataAccessSettings.ConnectionString;

    public static DataTable ListAllRoles()
    {

        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(ConnectionString);

        string query = "SELECT ID, RoleName FROM Roles";

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

    public static DataTable ListAllRolesWithoutAdmin()
    {

        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(ConnectionString);

        string query = "SELECT ID, RoleName AS Role FROM Roles WHERE LOWER(RoleName) != 'admin'";

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

    public static int GetRoleIDByRoleName(string RoleName)
    {

        int ID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"SELECT ID FROM Roles WHERE RoleName = @RoleName";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleName", RoleName);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int id))
            {
                ID = id;
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

        return ID;

    }

    public static string GetRoleNameByRoleID(int RoleID)
    {

        string RoleName = "";

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"SELECT RoleName FROM Roles WHERE ID = @RoleID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleID", RoleID);

        try
        {
            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null)
            {
                RoleName = result.ToString();
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

        return RoleName;

    }

    public static bool HasPermission(int RoleID, int PermissionID)
    {

        bool HasPermission = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"SELECT *
                         FROM Roles INNER JOIN
                         RolePermissions ON Roles.ID = RolePermissions.RoleID INNER JOIN
                         Permissions ON RolePermissions.PermissionID = Permissions.ID
				         WHERE Roles.ID = @RoleID AND Permissions.ID = @PermissionID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@PermissionID", PermissionID);
        command.Parameters.AddWithValue("@RoleID", RoleID);

        try
        {

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                HasPermission = true;

        }
        catch (Exception ex)
        {
            string errorMessage = ex.Message;
        }
        finally
        {
            connection.Close();
        }


        return HasPermission;

    }

    public static int AddNewRole(string RoleName)
    {

        int RoleID = -1;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"INSERT INTO Roles (RoleName)
                         VALUES (@RoleName);
                         SELECT SCOPE_IDENTITY();";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleName", RoleName);

        try
        {

            connection.Open();

            object result = command.ExecuteScalar();

            if (result != null && int.TryParse(result.ToString(), out int insertedID))
                RoleID = insertedID;

        }
        catch (Exception ex)
        {
            string errorMessage = ex.Message;
        }
        finally
        {
            connection.Close();
        }

        return RoleID;

    }

    public static bool UpdateRole(int ID, string RoleName)
    {

        int rowsAffected = 0;
        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"UPDATE Roles
                         SET RoleName = @RoleName
                         WHERE ID = @ID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleName", RoleName);
        command.Parameters.AddWithValue("@ID", ID);

        try
        {

            connection.Open();

            rowsAffected = command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            connection.Close();
        }

        return (rowsAffected > 0);

    }

    public static bool DeleteRole(int ID)
    {

        int rowsAffected = 0;
        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"DELETE Roles WHERE ID = @ID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ID", ID);

        try
        {

            connection.Open();

            rowsAffected = command.ExecuteNonQuery();

        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            connection.Close();
        }

        return (rowsAffected > 0);

    }

    public static DataTable GetRolePermissions(int RoleID)
    {

        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(ConnectionString);

        string query = "SELECT PermissionID FROM RolePermissions WHERE RoleID = @RoleID";

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

    public static bool IsRoleExist(string RoleName)
    {

        SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);

        bool IsRoleExist = false;
        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"SELECT Found=1 FROM Roles WHERE RoleName = @RoleName";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleName", RoleName);

        try
        {

            connection.Open();

            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
                IsRoleExist = true;


        }
        catch (Exception ex)
        {
            string msg = ex.Message;
        }
        finally
        {
            connection.Close();
        }

        return IsRoleExist;



    }

    public static bool IsRoleAdmin(int RoleID)
    {

        bool IsRoleAdmin = false;

        SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

        string query = @"SELECT Found=1 FROM Roles WHERE RoleName = 'Admin' AND ID = @RoleID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@RoleID", RoleID);

        try
        {

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                IsRoleAdmin = true;

        }
        catch (Exception ex)
        {
            string errorMessage = ex.Message;
        }
        finally
        {
            connection.Close();
        }


        return IsRoleAdmin;

    }















}