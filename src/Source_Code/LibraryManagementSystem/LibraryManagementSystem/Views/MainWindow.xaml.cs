using System;
using System.Windows;
using System.Data.SqlClient;
using LibraryManagementSystem.Helpers;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((tbLibrarianUsername.Text != string.Empty || pbLibrarianPassword.Password != string.Empty) || (tbLibrarianUsername.Text != string.Empty && pbLibrarianPassword.Password != string.Empty))
            {
                try
                {
                    if(DatabaseHelpers.validateLibrarianLogin(tbLibrarianUsername.Text, pbLibrarianPassword.Password))
                    {
                        alertAdmin.Content = "Login Successful";
                    }
                    else
                    {
                        alertAdmin.Content = "Invalid Credentials";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Exception Occured - "+ex.Message);
                }
            }
            else
            {
                alertAdmin.Content = "Username/Password cannot be empty";
            }
        }
    }
}
