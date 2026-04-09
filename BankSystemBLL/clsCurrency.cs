using BankSystemDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemBLL
{
    public class clsCurrency
    {







        public static DataTable GetAllCurrencies()
            => clsDataCurrency.GetAllCurrencies();

        public static DataTable GetAllCurrenciesAndRateToShowItInDGV()
            => clsDataCurrency.GetAllCurrenciesAndRateToShowItInDGV();

        public static DataTable GetAmericanAndSyrianCurrencies()
            => clsDataCurrency.GetAmericanAndSyrianCurrencies();

        public static DataTable GetAmericanCurrency()
            => clsDataCurrency.GetAmericanCurrency();



    }
}
