using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDAL
{
    public class clsDataTransaction
    {

        public static bool Withdraw(int ClientID, decimal Ammount)
        {

            bool IsSuccess = false;
            string TransactionType = "Withdraw";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" UPDATE Clients
                              SET Balance -= @Ammount
                              WHERE ID = @ClientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@Ammount", Ammount);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            if (IsSuccess)
                TransactionsRegister(ClientID, -1, Ammount, 22, TransactionType);

            return IsSuccess;

        }

        public static bool Deposite(int ClientID, decimal Ammount)
        {

            bool IsSuccess = false;
            string TransactionType = "Deposite";

            //decimal newBalance = 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" UPDATE Clients
                              SET Balance += @Ammount
                              WHERE ID = @ClientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ClientID", ClientID);
            command.Parameters.AddWithValue("@Ammount", Ammount);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            if (IsSuccess)
                TransactionsRegister(-1, ClientID, Ammount, 22, TransactionType);

            return IsSuccess;

        }

        public static bool Transfer(int FromClientID, int ToClientID, decimal Ammount)
        {

            //bool IsSuccess = Withdraw(FromClientID, Ammount, false) && Deposite(ToClientID, Ammount, false);

            //if (IsSuccess)
            //    TransactionsRegister(FromClientID, ToClientID, Ammount, 22, "Transfer");

            //return IsSuccess;

            bool IsSuccess = false;
            string TransactionType = "Transfer";

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE Clients
                             SET Balance += @Ammount
                             WHERE ID = @ToClientID;
                             UPDATE Clients
                             SET Balance -= @Ammount
                             WHERE ID = @FromClientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FromClientID", FromClientID);
            command.Parameters.AddWithValue("@ToClientID", ToClientID);
            command.Parameters.AddWithValue("@Ammount", Ammount);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            if (IsSuccess)
                TransactionsRegister(FromClientID, ToClientID, Ammount, 22, TransactionType);

            return IsSuccess;

        }

        public static bool TransactionsRegister(int FromClientID = -1, int ToClientID = -1, decimal Amount = 0, int CurrencyID = 22, string TransactionType = "")
        {

            //string _TransactionType = TransactionType;
            
            bool IsSaved = false;

            //decimal newBalance = 

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO [Transactions] ([Amount],[Date],[TransactionType],[CurrencyID],[FromClientID],[ToClientID])
                             VALUES(@Amount,GETDATE(),@TransactionType,@CurrencyID,@FromClientID,@ToClientID)";
            

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@TransactionType", TransactionType);
            command.Parameters.AddWithValue("@CurrencyID", CurrencyID);
            command.Parameters.AddWithValue("@FromClientID", (FromClientID == -1) ? (object)DBNull.Value : FromClientID);
            command.Parameters.AddWithValue("@ToClientID", (ToClientID == -1) ? (object)DBNull.Value : ToClientID);


            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                IsSaved = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                //System.Diagnostics.Debug.WriteLine("Error in TransactionsRegister: " + ex.Message);
                
            }
            finally
            {
                connection.Close();
            }

            return IsSaved;

        }

        public static DataTable ListTransactionsRegister()
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            //string query = @"SELECT * FROM Clients";

            string query = @"SELECT 
                             T.ID AS TransactionID,
                             T.Amount, 
                             T.TransactionType, 
                             T.Date,
                             ISNULL(C_From.AccountNO, 'N/A') AS FromAccount, 
                             ISNULL(P_From.Name, 'Bank/External') AS FromPersonName,
                             ISNULL(C_To.AccountNO, 'N/A') AS ToAccount,
                             ISNULL(P_To.Name, 'Bank/External') AS ToPersonName,
                             Curr.Name AS CurrencyName
                             FROM Transactions T
                             LEFT JOIN Clients C_From ON T.FromClientID = C_From.ID
                             LEFT JOIN Persons P_From ON C_From.PersonID = P_From.ID
                             LEFT JOIN Clients C_To ON T.ToClientID = C_To.ID
                             LEFT JOIN Persons P_To ON C_To.PersonID = P_To.ID
                             INNER JOIN Currencies Curr ON T.CurrencyID = Curr.ID
                             ORDER BY T.Date DESC;";


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
