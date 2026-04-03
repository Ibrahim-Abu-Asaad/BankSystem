using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataCountry
    {

        public static DataTable GetAllCountries()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID, Name FROM Countries";

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




    }
}
