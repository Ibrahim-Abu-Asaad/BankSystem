using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataCurrency
    {


        public static DataTable GetAllCurrencies()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID, Name FROM Currencies";

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

        public static DataTable GetAmericanAndSyrianCurrencies()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID, Name FROM Currencies WHERE Code = 'USD' OR Code = 'SYP'";

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

        public static DataTable GetAmericanCurrency()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT ID, Name FROM Currencies WHERE Code = 'USD'";

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
