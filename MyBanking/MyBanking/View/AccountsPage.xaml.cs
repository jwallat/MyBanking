using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace MyBanking.View
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class AccountsPage : Page
    {
        public AccountsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            foreach (Account a in BankingModel.Accounts)
            {
                AddAccountToListView(a);
            }

                //accountsList.Items.Add(accounts);
        }

        private void AddAccountToListView(Account a)
        {
            ListViewItem i = new ListViewItem();
            i.Content = a.Name + "\t\t\t" + "Balance: " + a.Balance;
            AccountsList.Items.Add(i);
            Debug.WriteLine("ListViewItem added " + a.Name + ", Balance: " + a.Balance);
        }

        private void UpdateAccountsListView()
        {
            AccountsList.Items.Clear();
            foreach (Account a in BankingModel.Accounts)
            {
                AddAccountToListView(a);
            }
        }

        private void AccountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Selection changed");
            if (AccountsList.SelectedItem != null)
            {
                string name = (string) ((ListViewItem) AccountsList.SelectedItem).Content;
                name = name.Split("\t")[0];
                SelectedAccountTextBlock.Text = name;
            }
            else
            {
                SelectedAccountTextBlock.Text = "";
            }
        }

        private void AddAccount(object sender, RoutedEventArgs e)
        { 
            string name = AccountNameTextBox.Text;
            if (name.Equals(""))
            {
                Debug.WriteLine("Please specify an account name!");
            }
            else
            {
                Account a = new Account(name, 0);
                BankingModel.AddAccount(a);
                UpdateAccountsListView();
                Debug.WriteLine("Account added: " + a.Name);
            }
        }

        private void DeleteAccount(object sender, RoutedEventArgs e)
        {
            string name = SelectedAccountTextBlock.Text;
            name = name.Split("\t")[0];
            Account a = BankingModel.Accounts.Find(x => x.Name.Equals(name));
            BankingModel.DeleteAccount(a);

            UpdateAccountsListView();
        }
    }
}
