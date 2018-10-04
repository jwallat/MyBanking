using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBanking.Model;
using MyBanking.Util;

namespace MyBanking
{
    public static class BankingModel
    {
        private static readonly DatabaseHandler DbHandler = new DatabaseHandler();

        //List of accounts, containing the savings boxes

        public static List<Account> Accounts { get; set; }

        public static List<Transaction> Transactions { get; set; }

        //add transactions (and re-occuring transaction) (maybe also in the MainPage.xaml.cs)
        public static void AddTransaction(Transaction t)
        {
            Transactions.Add(t);
            DbHandler.AddTransaction(t);
        }

        public static void AddAccount(Account a)
        {
            Accounts.Add(a);
            DbHandler.AddAcount(a);
        }
    }
}
