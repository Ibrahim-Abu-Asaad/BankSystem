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

    public static string GetRoleNameByID(int RoleID)
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






















}