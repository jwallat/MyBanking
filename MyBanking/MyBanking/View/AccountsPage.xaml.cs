using System.Collections.Generic;
using System.Diagnostics;
using Windows.UI;
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

            List<Account> accounts = (List<Account>) e.Parameter;
            if (accounts != null)
            { 
                foreach (Account a in accounts)
                {
                    ListViewItem i = new ListViewItem();
                    i.Content = a.Name;
                    accountsList.Items.Add(i);
                    Debug.WriteLine("ListViewItem added " + a.Name);
                }

                //accountsList.Items.Add(accounts);
            }
            
            
        }

        private void accountsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
