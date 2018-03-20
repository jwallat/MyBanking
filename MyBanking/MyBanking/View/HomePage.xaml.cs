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

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace MyBanking
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        private const string ConnectionString =
            "Server=swizzlepi.ddns.net;Database=mybanking;Uid=mybanking;Pwd=mybanking;";

        public HomePage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Click");
            try
            {

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    DBConnectionTextBlock.Text = connection.State.ToString();
                    MySqlCommand getCommand = connection.CreateCommand();
                    getCommand.CommandText = "SELECT * FROM Transaction t WHERE t.reciever = \"Emsland\"";
                    using (MySqlDataReader reader = getCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBConnectionTextBlock.Text += reader.GetString("info");
                            Debug.WriteLine(reader.GetString("info"));
                        }
                    }
                    connection.Close();
                }
            }
            catch (MySqlException ex)
            {
                // Handle it :) 
                Debug.WriteLine(ex.StackTrace);
            }

        }
    }
}
