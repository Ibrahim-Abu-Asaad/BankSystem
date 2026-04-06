using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            string query = @"SELECT * FROM Clients";

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
}
