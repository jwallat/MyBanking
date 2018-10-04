using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Composition.Interactions;
using Windows.UI.Xaml.Controls;
using MyBanking.Model;
using MyBanking.View;
using MySql.Data.MySqlClient;

namespace MyBanking.Util
{
    class DatabaseHandler
    {
        private const string ConnectionString =
            "Server=swizzlepi.ddns.net;Database=mybanking;Uid=mybanking;Pwd=mybanking;";

        private const string _user = "Jonas";

        public DatabaseHandler()
        {

        }

        /// <summary>
        /// Fetches and returns a list of all transactions of the user contained in the database.
        /// </summary>
        /// <returns>List of transactions</returns>
        public List<Transaction> GetTransactions()
        {
            List<Transaction> transactions = new List<Transaction>();

            // fetch list of accounts 
            var accounts = GetAccounts();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Retrieve all transactions of the user
                    MySqlCommand getTransactionsCommand = connection.CreateCommand();
                    foreach (Account a in accounts)
                    {
                        string accountName = a.Name;
                        getTransactionsCommand.CommandText =
                            "SELECT * FROM Transaction t WHERE t.sender = '" + accountName + "' OR t.reciever = '" +
                            accountName + "'";
                        using (MySqlDataReader reader2 = getTransactionsCommand.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                String senderName = reader2.GetString("sender");
                                String recieverName = reader2.GetString("reciever");
                                Account sendingAccount;
                                Account recievingAccount;
                                if (senderName.Equals(a.Name))
                                {
                                    sendingAccount = a;
                                    recievingAccount = accounts.Find(x => x.Name.Equals(recieverName));
                                }
                                else
                                {
                                    recievingAccount = a;
                                    sendingAccount = accounts.Find(x => x.Name.Equals(senderName));
                                }

                                double amount = Double.Parse(reader2.GetString("amount"));
                                DateTime date = DateTime.Parse(reader2.GetString("date"));
                                Transaction t = new Transaction(sendingAccount, recievingAccount, amount, date);
                                t.Info = reader2.GetString("info");
                                a.AddTransaction(t);
                                Debug.WriteLine("Added: " + t);
                            }
                        }
                    }
                }

                return transactions;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Fechtes and returns a list of all accounts of the user, that are stored in the database.
        /// </summary>
        /// <returns>List of all accounts</returns>
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // Retrieve all accounts
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM Account a WHERE a.owner = '" + _user + "'";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            String accountName = reader.GetString("name");
                            Account a = new Account(accountName, 0);
                            accounts.Add(a);
                            Debug.WriteLine("Account " + accountName + " created");
                        }
                    }
                    connection.Close();
                }
                return accounts;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
                return null;
            }
        }

        /// <summary>
        /// Adds a new account to the database.
        /// </summary>
        public void AddAcount(Account account)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Account (name, owner) VALUES(?name, ?owner)";
                    command.Parameters.AddWithValue("?name", account.Name);
                    command.Parameters.AddWithValue("?owner", _user);
                    command.ExecuteNonQueryAsync();
                    connection.Close();
                }            
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Adds a new transaction to the database.
        /// </summary>
        /// <param name="t">Transaction to be added</param>
        public void AddTransaction(Transaction t)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    MySqlCommand command = connection.CreateCommand();
                    command.CommandText = "INSERT INTO Transaction (id, sender, reciever, date, amount, reoccuring, frequency, info) " +
                                             " VALUES (?id, ?sender, ?reciever, ?date, ?amount, ?reoccuring, ?frequency, ?info);";
                    command.Parameters.AddWithValue("?id", t.Id);
                    command.Parameters.AddWithValue("?sender", t.Sender);
                    command.Parameters.AddWithValue("?reciever", t.Reciever);
                    command.Parameters.AddWithValue("?date", t.Date);
                    command.Parameters.AddWithValue("?amount", t.Amount);
                    command.Parameters.AddWithValue("?reoccuring", 0);
                    command.Parameters.AddWithValue("?frequency", 0);
                    command.Parameters.AddWithValue("?info", t.Info);
                    //command.ExecuteNonQuery();
                    command.ExecuteNonQueryAsync();
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }

    }
}
