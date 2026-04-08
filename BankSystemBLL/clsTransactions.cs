using BankSystemDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsTransactions
    {

        public static bool Withdraw(int ClientID, decimal Ammount)
            => clsDataTransaction.Withdraw(ClientID, Ammount);

        public static bool Deposite(int ClientID, decimal Ammount)
            => clsDataTransaction.Deposite(ClientID, Ammount);

        public static bool Transfer(int FromClientID, int ToClientID, decimal Ammount)
            => clsDataTransaction.Transfer(FromClientID, ToClientID, Ammount);

        public static bool TransactionsRegister(int FromClientID = -1, int ToClientID = -1, decimal Amount = 0, int CurrencyID = 22, string TransactionType = "")
            => clsDataTransaction.TransactionsRegister(FromClientID, ToClientID, Amount, CurrencyID, TransactionType);

        public static DataTable ListTransactionsRegister()
            => clsDataTransaction.ListTransactionsRegister();



    }
}
