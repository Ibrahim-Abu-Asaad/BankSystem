using BankSystemDAL;
using System.Data.SqlClient;
using System.Data;
using System;

public class clsDataRole
{
    private static string _connectionString =
        clsDataAccessSettings.ConnectionString;

    public static DataTable ListAllRoles()
    {
        DataTable dt = new DataTable();

        SqlConnection connection = new SqlConnection(_connectionString);
        string query = "SELECT ID, RoleName FROM Roles";
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
}