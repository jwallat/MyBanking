using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using MySql.Data.MySqlClient;
using MyBanking.Model;
using MyBanking.Util;
using MyBanking.View;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace MyBanking
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private List<Account> _accounts = new List<Account>();
        private DatabaseHandler _dbHandler = new DatabaseHandler();

        public HomePage()
        {
            this.InitializeComponent();
        }

        /**
         * Loads all the saved information into the app.
         */
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click");

            BankingModel.Accounts = _dbHandler.GetAccounts();
            BankingModel.Transactions = _dbHandler.GetTransactions();
            
            Frame.Navigate(typeof(AccountsPage));
        }
    }
}
