using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BankSystemDAL
{
    public class clsDataPermission
    {
        private static string _connectionString = clsDataAccessSettings.ConnectionString;


        public static bool GetPermissionByID(int PermissionID, ref string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT PermissionName
                FROM Permissions
                WHERE ID = @PermissionID", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionID", PermissionID);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PermissionName = reader["PermissionName"].ToString();
                    return true;
                }
                return false;
            }
        }

        public static bool GetPermissionByName(string PermissionName, ref int PermissionID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT ID
                FROM Permissions
                WHERE PermissionName = @PermissionName", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    PermissionID = (int)reader["ID"];
                    return true;
                }
                return false;
            }
        }

        public static int AddNewPermission(string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO Permissions (PermissionName)
                VALUES (@PermissionName);
                SELECT SCOPE_IDENTITY();", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                var result = cmd.ExecuteScalar();
                return (result != null) ? Convert.ToInt32(result) : -1;
            }
        }


        public static bool UpdatePermission(int PermissionID, string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                UPDATE Permissions
                SET PermissionName = @PermissionName
                WHERE ID = @PermissionID", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionID", PermissionID);
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public static bool DeletePermission(int PermissionID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                DELETE FROM Permissions
                WHERE ID = @PermissionID", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionID", PermissionID);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public static bool IsPermissionExist(int PermissionID)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Permissions
                WHERE ID = @PermissionID", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionID", PermissionID);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        public static bool IsPermissionExist(string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM Permissions
                WHERE PermissionName = @PermissionName", conn))
            {
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }


        public static DataTable ListAllPermissions()
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                "SELECT ID, PermissionName FROM Permissions", conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
        }


        public static List<string> GetAllPermissionsOfUser(int UserID)
        {
            var permissions = new List<string>();

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT p.PermissionName
                FROM UserPermissions up
                JOIN Permissions p ON up.PermissionID = p.ID
                WHERE up.UserID = @UserID", conn))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    permissions.Add(reader["PermissionName"].ToString());
            }
            return permissions;
        }

        public static bool SetPermissionsForUser(int UserID, List<string> PermissionNames)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        var del = new SqlCommand(
                            "DELETE FROM UserPermissions WHERE UserID = @UserID",
                            conn, tx);
                        del.Parameters.AddWithValue("@UserID", UserID);
                        del.ExecuteNonQuery();

                        foreach (var name in PermissionNames)
                        {
                            var ins = new SqlCommand(@"
                                INSERT INTO UserPermissions (UserID, PermissionID)
                                SELECT @UserID, ID
                                FROM Permissions
                                WHERE PermissionName = @Name",
                                conn, tx);
                            ins.Parameters.AddWithValue("@UserID", UserID);
                            ins.Parameters.AddWithValue("@Name", name);
                            ins.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        return false;
                    }
                }
            }
        }


        public static bool AddPermissionToUser(int UserID, string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                INSERT INTO UserPermissions (UserID, PermissionID)
                SELECT @UserID, ID
                FROM Permissions
                WHERE PermissionName = @PermissionName
                AND NOT EXISTS (
                    SELECT 1 FROM UserPermissions
                    WHERE UserID = @UserID
                    AND PermissionID = (
                        SELECT ID FROM Permissions
                        WHERE PermissionName = @PermissionName)
                )", conn))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public static bool RemovePermissionFromUser(int UserID, string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                DELETE FROM UserPermissions
                WHERE UserID = @UserID
                AND PermissionID = (
                    SELECT ID FROM Permissions
                    WHERE PermissionName = @PermissionName
                )", conn))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        public static bool UserHasPermission(int UserID, string PermissionName)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(@"
                SELECT COUNT(*)
                FROM UserPermissions up
                JOIN Permissions p ON up.PermissionID = p.ID
                WHERE up.UserID = @UserID
                AND p.PermissionName = @PermissionName", conn))
            {
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@PermissionName", PermissionName);
                conn.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }
    }
}
